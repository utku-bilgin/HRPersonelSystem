using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.ExpenditureDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using HRPersonnelSystem.UI.Areas.Employee.Models.PermissionDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;

namespace HRPersonnelSystem.UI.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ExpenditureController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;


        public ExpenditureController(ImageHelper imageHelper)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://hrmanagementsystemapi.azurewebsites.net");
            _imageHelper = imageHelper;
        }


        // GET: ExpenditureController
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> RejectedExpenditure()
        {
            var userId = HttpContext.Session.GetString("UserId");//giriş yapan kullanıcıyı çekiyoruz.
            List<EmployeeExpenditureDTO> rejectedList = new List<EmployeeExpenditureDTO>();//liste oluşturduk
            var getTask = await _httpClient.GetAsync("api/expenditure");


            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<List<EmployeeExpenditureDTO>>();
                foreach (var item in readTask)
                {
                    if (item.ApprovalStatus == ApprovalStatus.Reddedildi && item.EmployeeId.ToString() == userId)//Guid id string olduğu için ToString() yapıyoruz.
                    {
                        rejectedList.Add(item);//reddedilen harcamaları if içerisinde belirtilen şartlara göre çektik ve listeye ekledik.
                    }
                }
                return View(rejectedList);

            }
            return View();
        }


        public async Task<ActionResult> ApprovalPendingExpenditure()
        {
            var userId = HttpContext.Session.GetString("UserId");
            List<EmployeeExpenditureDTO> approvelPendingList = new List<EmployeeExpenditureDTO>();
            var getTask = await _httpClient.GetAsync("api/expenditure");

            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<List<EmployeeExpenditureDTO>>();
                foreach (var item in readTask)
                {
                    if (item.ApprovalStatus == ApprovalStatus.Bekleyen && item.EmployeeId.ToString() == userId)
                    {
                        approvelPendingList.Add(item);
                    }
                }
                return View(approvelPendingList);
            }
            return View();
        }


        public async Task<ActionResult> ApprovedExpenditure()
        {
            var userId = HttpContext.Session.GetString("UserId");
            List<EmployeeExpenditureDTO> approvedList = new List<EmployeeExpenditureDTO>();

            var getTask = await _httpClient.GetAsync("api/expenditure");

            if (getTask.IsSuccessStatusCode)
            {
                var readTask = await getTask.Content.ReadAsAsync<List<EmployeeExpenditureDTO>>();
                foreach (var item in readTask)
                {
                    if (item.ApprovalStatus == ApprovalStatus.Onaylandı && item.EmployeeId.ToString() == userId)
                    {
                        approvedList.Add(item);
                    }
                }
                return View(approvedList);
            }
            return View();
        }



        // GET: ExpenditureController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var responseTask = await _httpClient.GetAsync("api/expenditure");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<List<EmployeeExpenditureDTO>>();
                var expenditure = readTask.FirstOrDefault(x => x.Id == id);//okunan değere göre şartı döndürdük
                return View(expenditure);
            }
            return View();
        }





        // GET: ExpenditureController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: ExpenditureController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(EmployeeExpenditureDTO createExpenditureDTO)
        {
            try
            {
                var userId = HttpContext.Session.GetString("UserId");
                var responseTask = await _httpClient.GetAsync($"api/expenditure/{userId}");
                createExpenditureDTO.EmployeeId = Guid.Parse(userId);

                //aynı türde harcama oluşturmaması için
                if (createExpenditureDTO.ApprovalStatus == ApprovalStatus.Bekleyen)
                {
                    var getTask = await _httpClient.GetAsync("api/expenditure");
                    var readTask = await getTask.Content.ReadAsAsync<List<EmployeeExpenditureDTO>>();

                   
                    //eğer bu if ile db taraması yapıp içinde hiç bu veri var mı diye kontrol ederiz. Varsa uyarı mesajı döndürürüz.
                    if (readTask.Any(x => x.ApprovalStatus == ApprovalStatus.Bekleyen && x.ExpenditureType.ToString() == createExpenditureDTO.ExpenditureType.ToString() && x.EmployeeId.ToString()==userId))//(&& x.EmployeeId.ToString()==userId) ile db den gelen çalışan id si ile userId ye ait oluşan talep var mı kontrolü yapıldı.
                    {
                        ModelState.AddModelError("", $"Seçmiş olduğunuz {createExpenditureDTO.ExpenditureType} türünde onay bekleyen harcama talebiniz mevcuttur. Aynı türde yeni bir harcama talebinde bulunamazsınız.");
                        return View(createExpenditureDTO);
                    }
                }



                //resim kaydetmek için
                if (createExpenditureDTO.Photo != null)
                {
                    var imageUplod = await _imageHelper.Upload($"{createExpenditureDTO.Id}", createExpenditureDTO.Photo, ImageType.Employee);
                    createExpenditureDTO.ImagePath = imageUplod.ImagePath;
                    createExpenditureDTO.Photo = null;

                }

                if (!ModelState.IsValid)
                {
                    return View(createExpenditureDTO);
                }

                var postTask = await _httpClient.PostAsJsonAsync<EmployeeExpenditureDTO>("api/expenditure", createExpenditureDTO);
                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(ApprovalPendingExpenditure));
                }
                else
                {
                    return View(createExpenditureDTO);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }



        // GET: ExpenditureController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ExpenditureController/Edit/5
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

        // GET: ExpenditureController/Delete/5
        public async Task<ActionResult> Delete(Guid id)
        {
            var getTask = await _httpClient.GetAsync("api/expenditure");
            var readTask = await getTask.Content.ReadAsAsync<List<EmployeeExpenditureDTO>>();
            EmployeeExpenditureDTO deleteExpenditureDTO = readTask.FirstOrDefault(x => x.Id == id);

            return View(deleteExpenditureDTO);
        }

        // POST: ExpenditureController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(Guid id, EmployeeExpenditureDTO deleteExpenditureDTO)
        {
            var postTask = await _httpClient.DeleteAsync($"api/expenditure/{id}");
            if (postTask.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(ApprovalPendingExpenditure));
            }
            else
            {
                return View();
            }
        }
    }
}
