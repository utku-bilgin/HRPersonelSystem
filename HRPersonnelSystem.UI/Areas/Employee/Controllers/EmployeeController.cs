using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.AdvancePaymentDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Newtonsoft.Json;
using System.Net;
using System.Net.Mail;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;
using System.Text;
using System.Security.Claims;
using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;

namespace HRPersonnelSystem.UI.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;

        public EmployeeController(ImageHelper imageHelper)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
            _imageHelper = imageHelper;
        }

        // GET: EmployeeController
        //[Route("")]
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

        // GET: EmployeeController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
            
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<EmployeeEntity>();
				var responseComp = await _httpClient.GetAsync($"api/company/{readTask.CompanyId}");
                var responseGetComp = await responseComp.Content.ReadAsAsync<CompanyAllDTO>();
                readTask.CompanyName = responseGetComp.CompanyName;
				return View(readTask);
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

                if (postTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
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


        // GET: EmployeeController/Edit/5
        public async Task<ActionResult> Edit(Guid id)
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
			if (responseTask.IsSuccessStatusCode)
			{
				var readTask = await responseTask.Content.ReadAsAsync<EmployeeUptadeDTO>();
				return View(readTask);
			}
			return View();
		}

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EmployeeUptadeDTO employee)
        {
            try
            {
                if (employee.Photo == null)
                {
                    var userId = HttpContext.Session.GetString("UserId");
                    var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
                    var readTask = responseTask.Content.ReadAsAsync<EmployeeEntity>();
                    employee.ImagePath = readTask.Result.ImagePath;
                }
                else
                {
                    var imageUpload = await _imageHelper.Upload($"{employee.Id}", employee.Photo, ImageType.Employee);
                    employee.ImagePath = imageUpload.ImagePath;
                    employee.Photo = null;
                }
                if (!ModelState.IsValid)
                {
                    return View(employee);
                }
                var putTask = await _httpClient.PutAsJsonAsync<EmployeeUptadeDTO>("api/employee", employee);
                if (putTask.IsSuccessStatusCode)
                {
                    return RedirectToAction(nameof(Index));
                }
                else if (putTask.StatusCode == HttpStatusCode.BadRequest)
                {
                    // HTTP 400 hatası alındığında sunucu tarafından dönen hata mesajını alabilirsiniz.
                    var errorMessage = await putTask.Content.ReadAsStringAsync();
                    ModelState.AddModelError(string.Empty, errorMessage); // Hata mesajını modelinize ekleyebilirsiniz.
                    return View(employee);
                }
                else
                {
                    return View(employee);
                }
            }
            catch
            {
                return View(employee);
            }
        }



        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
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
