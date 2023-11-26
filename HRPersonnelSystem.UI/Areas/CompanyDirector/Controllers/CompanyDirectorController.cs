using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;
using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.CompanyDirectorDTOs;
using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.Controllers
{
    [Area("CompanyDirector")]
    public class CompanyDirectorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;

        public CompanyDirectorController(ImageHelper imageHelper)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
            _imageHelper = imageHelper;
        }

        // GET: CompanyDirectorController
        public async Task<ActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<CompanyDirectorDTO>();
                return View(readTask);
            }
            return View();
        }

        // GET: CompanyDirectorController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<CompanyDirectorDTO>();
				var responseComp = await _httpClient.GetAsync($"api/company/{readTask.CompanyId}");
				var responseGetComp = await responseComp.Content.ReadAsAsync<CompanyAllDTO>();
				readTask.CompanyName = responseGetComp.CompanyName;
				return View(readTask);
            }
            return View();
        }

        // GET: CompanyDirectorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyDirectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            try
            {
                var postTask = await _httpClient.PostAsJsonAsync("api/CompanyDirector", createCompanyDirectorDTO);

                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View(createCompanyDirectorDTO);
                }
            }
            catch (Exception)
            {
                return View("Error");
            }
        }

        // GET: CompanyDirectorController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");

            var responseTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<CompanyDirectorUpdateDTO>();
                return View(readTask);
            }
            return View();
        }

        // POST: CompanyDirectorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(CompanyDirectorUpdateDTO companyDirectorUpdateDTO)
        {
            try
            {
                if (companyDirectorUpdateDTO.Photo == null)
                {
                    var userId = HttpContext.Session.GetString("UserId");
                    var responseTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
                    var readTask = responseTask.Content.ReadAsAsync<CompanyDirectorUpdateDTO>();
                    companyDirectorUpdateDTO.ImagePath = readTask.Result.ImagePath;
                }
                else
                {
                    var imageUpload = await _imageHelper.Upload($"{companyDirectorUpdateDTO.Id}", companyDirectorUpdateDTO.Photo, ImageType.Employee);
                    companyDirectorUpdateDTO.ImagePath = imageUpload.ImagePath;
                    companyDirectorUpdateDTO.Photo = null;
                }


                if (!ModelState.IsValid)
                {
                    return View(companyDirectorUpdateDTO);
                }


                var putTask = await _httpClient.PutAsJsonAsync<CompanyDirectorUpdateDTO>("api/CompanyDirector", companyDirectorUpdateDTO);

                if (putTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Details));
                }
                else if (putTask.StatusCode == HttpStatusCode.BadRequest)
                {
                    var errorMessage = await putTask.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(companyDirectorUpdateDTO);
                }
                else
                {
                    return View(companyDirectorUpdateDTO);
                }
            }
            catch
            {
                return View(companyDirectorUpdateDTO);
            }
        }

        // GET: CompanyDirectorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyDirectorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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
    }
}
