using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using Microsoft.AspNetCore.Mvc;


namespace HRPersonnelSystem.UI.Areas.Employee.ViewComponents
{
	public class DashboardHeaderViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public DashboardHeaderViewComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://hrmanagementsystemapi.azurewebsites.net");
        }

        public async Task<IViewComponentResult> InvokeAsync()    //Index'e karşılık gelen => InvokeAsync
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/employee/{userId}");
            var readTask = await responseTask.Content.ReadAsAsync<EmployeeEntity>();

            EmployeeDetailsDTO employee = new EmployeeDetailsDTO
            {
                FirstName = readTask.FirstName,
                LastName = readTask.LastName,
                ImagePath = readTask.ImagePath
            };
            return View(employee);
        }
    }
}
