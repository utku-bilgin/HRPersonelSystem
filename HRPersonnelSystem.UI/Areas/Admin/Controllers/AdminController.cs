using HRPersonnelSystem.UI.Areas.Admin.Models.AdminDTOs;
using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace HRPersonnelSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;

        public AdminController(ImageHelper imageHelper)
        {
            _httpClient = new HttpClient();
           
            _httpClient.BaseAddress = new Uri("https://localhost:7085");

            _imageHelper = imageHelper;
        }

        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/Admin/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<AdminDTO>();
                return View(readTask);
            }
            return View();
        }

        // GET: AdminController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/Admin/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<AdminDTO>();
                return View(readTask);
            }
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: AdminController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/Admin/{userId}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<AdminUpdateDTO>();
                return View(readTask);
            }
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AdminUpdateDTO adminUpdateDTO)
        {
            try
            {
                if (adminUpdateDTO.Photo == null)
                {
                    var userId = HttpContext.Session.GetString("UserId");
                    var responseTask = await _httpClient.GetAsync($"api/Admin/{userId}");
                    var readTask = responseTask.Content.ReadAsAsync<AdminUpdateDTO>();
                    adminUpdateDTO.ImagePath = readTask.Result.ImagePath;
                }
                else
                {
                    var imageUpload = await _imageHelper.Upload($"{adminUpdateDTO.Id}", adminUpdateDTO.Photo, ImageType.Employee);
                    adminUpdateDTO.ImagePath=imageUpload.ImagePath;
                    adminUpdateDTO.Photo = null;
                }

                if (!ModelState.IsValid)
                {
                    return View(adminUpdateDTO);
                }

                var putTask = await _httpClient.PutAsJsonAsync<AdminUpdateDTO>("api/Admin",adminUpdateDTO);
                if (putTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Details));
                }
                else if(putTask.StatusCode==HttpStatusCode.BadRequest)
                {
                    var errorMessage = await putTask.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage);
                    return View(adminUpdateDTO);
                }
                else
                {
                    return View(adminUpdateDTO);

                }
            }
            catch
            {
                return View(adminUpdateDTO);
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
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
