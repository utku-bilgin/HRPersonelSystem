using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using HRPersonnelSystem.UI.Areas.Employee.Models.PermissionDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.UI.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class PermissionController : Controller
    {
        private readonly HttpClient _httpClient;

        public PermissionController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }

        // GET: PermissionController
        public async Task<ActionResult> Index()
        {
            return View();
        }

        public async Task<ActionResult> UncertainApprovals()
        {
            var userId = HttpContext.Session.GetString("UserId");

            List<PermissionEntityDTO> uncertainApprovals = new List<PermissionEntityDTO>();
            
            var getTask = await _httpClient.GetAsync("api/permission");
            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<List<PermissionEntityDTO>>();
                foreach (var item in readTask)
                {
                    if (item.ApprovalStatus == ApprovalStatus.Bekleyen && item.EmployeeId.ToString() == userId)
                    {
                        uncertainApprovals.Add(item);
                    }
                }
                return View(uncertainApprovals);
            }
            return View();
        }

        public async Task<ActionResult> ApprovedApprovals()
        {
            var userId = HttpContext.Session.GetString("UserId");

            List<PermissionEntityDTO> approvedApprovals = new List<PermissionEntityDTO>();
            
            var getTask = await _httpClient.GetAsync("api/Permission");
            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<List<PermissionEntityDTO>>();
                foreach (var item in readTask)
                {
                    if (item.ApprovalStatus == ApprovalStatus.Onaylandı && item.EmployeeId.ToString() == userId)
                    {
                        approvedApprovals.Add(item);
                    }
                }
                return View(approvedApprovals);
            }

            return View();
        }

        public async Task<ActionResult> RejectedApprovals()
        {
            var userId = HttpContext.Session.GetString("UserId");

            List<PermissionEntityDTO> rejectedApprovals = new List<PermissionEntityDTO>();
            
            var getTask = await _httpClient.GetAsync("api/Permission");
            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<List<PermissionEntityDTO>>();
                foreach (var item in readTask)
                {
                    if (item.ApprovalStatus == ApprovalStatus.Reddedildi && item.EmployeeId.ToString() == userId)
                    {
                        rejectedApprovals.Add(item);
                    }
                }
                return View(rejectedApprovals);
            }

            return View();
        }

        // GET: PermissionController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PermissionController/Create
        public async Task<ActionResult> Create()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<EmployeeEntity>();

                PermissionEntityDTO permission = new PermissionEntityDTO();
                permission.Gender = readTask.Result.Gender;

                return View(permission);
            }
            return View();
        }

        // POST: PermissionController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PermissionEntityDTO permission)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(permission);
                }

                var userId = HttpContext.Session.GetString("UserId");
                var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
                var readTask = await responseTask.Content.ReadAsAsync<EmployeeEntity>();

                permission.EmployeeId = Guid.Parse(userId);
                permission.Gender = readTask.Gender;

                if (permission.ApprovalStatus == ApprovalStatus.Bekleyen)
                {
                    var getTask = await _httpClient.GetAsync("api/permission");
                    var listTask = await getTask.Content.ReadAsAsync<List<PermissionEntityDTO>>();

                    if (listTask.Any(x => x.ApprovalStatus == ApprovalStatus.Bekleyen && x.PermissionType.ToString() == permission.PermissionType.ToString() && x.EmployeeId.ToString() == userId))
                    {
                        ModelState.AddModelError("", $"Seçmiş olduğunuz {permission.PermissionType} türünde onay bekleyen izin talebiniz mevcuttur. Aynı türde yeni bir izin talebinde bulunamazsınız.");
                        return View(permission);
                    }
                }

                if ((permission.PermissionType.ToString() == PermissionTypeFemale.Yıllık.ToString() || permission.PermissionType.ToString() == PermissionTypeMale.Yıllık.ToString()))
                {
                    DateTime startDate = readTask.DateOfHire;
                    DateTime endDate = DateTime.Now;
                    TimeSpan totalDays = endDate - startDate;
                    double doubleTotalDays = totalDays.TotalDays;

                    if (doubleTotalDays < 365)
                    {
                        ModelState.AddModelError("", "Çalışma süreniz 1 yıldan az olduğu için yıllık ücretli izin hakkınız bulunmamaktadır.");
                        return View(permission);
                    }

                    if ((doubleTotalDays >= 365 && doubleTotalDays < 2190) && (permission.CountOfDay <= 0 || permission.CountOfDay > 14))
                    {
                        ModelState.AddModelError("", "İzin hakkınız 1-14 gün arası olmalı.");
                        return View(permission);
                    }

                    if (doubleTotalDays >= 2190 && (permission.CountOfDay <= 0 || permission.CountOfDay > 20))
                    {
                        ModelState.AddModelError("","İzin hakkınız 1-20 gün arası olmalı.");
                        return View(permission);
                    }
                }

                var postTask = await _httpClient.PostAsJsonAsync<PermissionEntityDTO>("api/Permission", permission);
                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(UncertainApprovals));
                }
                else
                {
                    return View(permission);
                }
                
            }
            catch
            {
                return View(permission);
            }
        }

        // GET: PermissionController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PermissionController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PermissionController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var task = await _httpClient.GetAsync("api/Permission");
            var readTask = await task.Content.ReadAsAsync<List<PermissionEntityDTO>>();
            PermissionEntityDTO permission = readTask.First(x => x.Id == id);

            return View(permission);
        }

        // POST: PermissionController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, PermissionEntityDTO permission)
        {
            try
            {
                var postTask = await _httpClient.DeleteAsync($"api/Permission/{id}");
                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(UncertainApprovals));
                }
                else
                {
                    return View(permission);
                }
            }
            catch
            {
                return View(permission);
            }
        }
    }
}
