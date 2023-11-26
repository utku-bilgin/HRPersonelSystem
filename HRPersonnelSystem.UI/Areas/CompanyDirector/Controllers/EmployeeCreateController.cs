using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.Controllers
{
    [Area("CompanyDirector")]
    public class EmployeeCreateController : Controller
    {

        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;

        public EmployeeCreateController(ImageHelper imageHelper)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
            _imageHelper = imageHelper;
        }

        public async Task<ActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = responseTask.Content.ReadAsAsync<EmployeeEntity>();
                return View(readTask.Result);
            }
            return View();
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormFile photo, CreateEmployeeDTO createEmployeeDTO)
        {
            try
            {
                if (photo != null)
                {

                    var imageUpload = await _imageHelper.Upload(Guid.NewGuid().ToString(), photo, ImageType.Employee);
                    createEmployeeDTO.ImagePath = imageUpload.ImagePath;
                }


                var postTask = await _httpClient.PostAsJsonAsync("api/employee", createEmployeeDTO);
                var responseTask = await _httpClient.GetAsync($"api/employee");
                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = responseTask.Content.ReadAsAsync<List<EmployeeEntity>>();
                    createEmployeeDTO.Id = readTask.Result.Where(x=>x.FirstName == createEmployeeDTO.FirstName).First().Id;
                }
                var postTask1 = await _httpClient.PostAsJsonAsync("api/userrole", createEmployeeDTO);


                if (postTask.IsSuccessStatusCode && postTask1.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexIsActiveTrue","EmployeeAll");
                }
                else
                {
                    return View(createEmployeeDTO);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

    }
}
