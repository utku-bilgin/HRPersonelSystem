using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;
using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.CompanyDirectorDTOs;
using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HRPersonnelSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyDirectorCreate : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly ImageHelper _imageHelper;


        public CompanyDirectorCreate(ImageHelper imageHelper)
        {
            _imageHelper = imageHelper;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }
        // GET: CompanyDirectorListAllController
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/AdminForCompanyDirectorListIsActiveTrue");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var activeCompanies = JsonConvert.DeserializeObject<List<CompanyDirectorListAllDTO>>(content);
                return View(activeCompanies);
            }
            else
            {
                return View(new List<CompanyDirectorListAllDTO>());
            }
        }
        public ActionResult Create()
        {
            return View();
        }



        // POST: CompanyDirectorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormFile photo, CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            try
            {
                if (photo != null)
                {

                    var imageUpload = await _imageHelper.Upload(Guid.NewGuid().ToString(), photo, ImageType.CompanyDirector);
                    createCompanyDirectorDTO.ImagePath = imageUpload.ImagePath;
                }
                var postTask = await _httpClient.PostAsJsonAsync("api/CompanyDirector", createCompanyDirectorDTO);
                
                var response = await _httpClient.GetAsync("api/AdminForCompanyDirectorListIsActiveTrue");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var activeCompanies = JsonConvert.DeserializeObject<List<CompanyDirectorListAllDTO>>(content);
                    createCompanyDirectorDTO.Id = activeCompanies.FirstOrDefault(x => x.FirstName == createCompanyDirectorDTO.FirstName).Id;
                }
                var postTask1 = await _httpClient.PutAsJsonAsync("api/userrole", createCompanyDirectorDTO);

                if (postTask.IsSuccessStatusCode && postTask1.IsSuccessStatusCode)
                {
                    return RedirectToAction("IndexIsActiveTrue", "CompanyDirectorListAll");
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
    }
}
