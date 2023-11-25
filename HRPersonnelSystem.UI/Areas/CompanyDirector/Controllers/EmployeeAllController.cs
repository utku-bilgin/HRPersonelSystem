using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.EmployeeAllDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.AdvancePaymentDTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.Controllers
{
    [Area("CompanyDirector")]
    public class EmployeeAllController : Controller
    {
        private readonly HttpClient _httpClient;

        public EmployeeAllController(HttpClient httpClient)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://hrmanagementsystemapi.azurewebsites.net");


        }





        // GET: EmployeeAllController/IndexIsActiveTrue
        public async Task<IActionResult> IndexIsActiveTrue()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var response = await _httpClient.GetAsync($"api/CompanyDirectorForEmployeeListIsActiveTrue?Id={userId}");





            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var activeEmployees = JsonConvert.DeserializeObject<List<EmployeeAllDTO>>(content);
                return View(activeEmployees);
            }
            else
            {
                return View(new List<EmployeeAllDTO>());
            }
        }



        // GET: EmployeeAllController/IndexIsActiveFalse
        public async Task<IActionResult> IndexIsActiveFalse()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var response = await _httpClient.GetAsync($"api/CompanyDirectorForEmployeeListIsActiveFalse?Id={userId}");



            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var inactiveEmployees = JsonConvert.DeserializeObject<List<EmployeeAllDTO>>(content);
                return View(inactiveEmployees);
            }
            else
            {
                return View(new List<EmployeeAllDTO>());
            }
        }

        // GET: EmployeeAllController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeeAllController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeAllController/Create
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

        // GET: EmployeeAllController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeeAllController/Edit/5
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

        // GET: EmployeeAllController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeAllController/Delete/5
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
