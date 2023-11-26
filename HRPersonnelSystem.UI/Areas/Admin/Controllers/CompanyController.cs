
using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;
using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;
       

        public CompanyController(ImageHelper imageHelper)
        {
           
            _imageHelper = imageHelper;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }


        // GET: CompanyController
        public async Task<ActionResult> Index()
        {
            try
            {
                var responseTask = await _httpClient.GetAsync("api/Company");

                if (responseTask.IsSuccessStatusCode)
                {
                    var readTask = await responseTask.Content.ReadAsAsync<List<CompanyDTO>>();
                    return View(readTask);
                }
                else
                {
                    // Handle the case when the API request is not successful, e.g., return an error view.
                    return View("Error");
                }
            }
            catch (Exception)
            {
                // Handle exceptions if they occur during the API request.
                return View("Error");
            }
        }

        // GET: CompanyController/Details/5
        public async Task<ActionResult> Details(Guid id)
        {
            var responseTask = await _httpClient.GetAsync($"api/Company/{id}");
            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsAsync<CompanyDTO>();
                return View(readTask);
            }
            return View();
        }

        // GET: CompanyController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormFile photo, CreateCompanyDTO createCompanyDTO)
        {
           

            try
            {
                if (photo != null)
                {
                   
                    var imageUpload = await _imageHelper.Upload(Guid.NewGuid().ToString(), photo, ImageType.Employee);
                    createCompanyDTO.ImagePath = imageUpload.ImagePath;
                }
               
                var postTask = await _httpClient.PostAsJsonAsync("api/Company", createCompanyDTO);

                if (postTask.IsSuccessStatusCode)
                {
                    
                    return RedirectToAction("IndexIsActiveTrue", "CompanyListAll");
                }
                else
                {
                    
                    return View(createCompanyDTO);
                }
            }
            catch (Exception)
            {
               
                return View("Error");
            }
        }

        // GET: CompanyController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyController/Edit/5
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

        // GET: CompanyController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyController/Delete/5
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
