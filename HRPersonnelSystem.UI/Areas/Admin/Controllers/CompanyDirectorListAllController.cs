using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HRPersonnelSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyDirectorListAllController : Controller
    {
        private readonly HttpClient _httpClient;

        public CompanyDirectorListAllController(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }


        // GET: CompanyDirectorListAllController
        public async Task<IActionResult> IndexIsActiveTrue()
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

        // GET: CompanyDirectorListAllController
        public async Task<IActionResult> IndexIsActiveFalse()
        {
            var response = await _httpClient.GetAsync("api/AdminForCompanyDirectorListIsActiveFalse");

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

        // GET: CompanyDirectorListAllController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyDirectorListAllController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyDirectorListAllController/Create
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

        // GET: CompanyDirectorListAllController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyDirectorListAllController/Edit/5
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

        // GET: CompanyDirectorListAllController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyDirectorListAllController/Delete/5
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
