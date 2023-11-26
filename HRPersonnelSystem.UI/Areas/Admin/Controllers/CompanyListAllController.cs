using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;
using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.EmployeeAllDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace HRPersonnelSystem.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyListAllController : Controller
    {
        private readonly HttpClient _httpClient;

        public CompanyListAllController(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }

        // GET: CompanyListAllController/IndexIsActiveTrue
        public async Task<IActionResult> IndexIsActiveTrue()
        {
            var response = await _httpClient.GetAsync("api/AdminForCompanyListIsActiveTrue");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var activeCompanies = JsonConvert.DeserializeObject<List<CompanyAllDTO>>(content);
                return View(activeCompanies);
            }
            else
            {
                return View(new List<CompanyAllDTO>());
            }
        }

        // GET: CompanyListAllController/IndexIsActiveFalse
        public async Task<IActionResult> IndexIsActiveFalse()
        {
            var response = await _httpClient.GetAsync("api/AdminForCompanyListIsActiveFalse");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var activeCompanies = JsonConvert.DeserializeObject<List<CompanyAllDTO>>(content);
                return View(activeCompanies);
            }
            else
            {
                return View(new List<CompanyAllDTO>());
            }
        }

        // GET: CompanyListAllController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CompanyListAllController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompanyListAllController/Create
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

        // GET: CompanyListAllController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CompanyListAllController/Edit/5
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

        // GET: CompanyListAllController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CompanyListAllController/Delete/5
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
