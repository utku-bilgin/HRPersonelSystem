using HRPersonnelSystem.UI.Areas.CompanyDirector.Models.CompanyDirectorDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.ViewComponents
{
    public class CompanyDirectorDashboardHeaderViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public CompanyDirectorDashboardHeaderViewComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://hrmanagementsystemapi.azurewebsites.net");
        }

        public async Task<IViewComponentResult> InvokeAsync() 
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/CompanyDirector/{userId}");
            var readTask = await responseTask.Content.ReadAsAsync<CompanyDirectorDTO>();

            CompanyDirectorDTO director = new CompanyDirectorDTO 
            { 
                FirstName = readTask.FirstName,
                LastName = readTask.LastName,
                ImagePath = readTask.ImagePath
            };

            return View(director);
        }
    }
}
