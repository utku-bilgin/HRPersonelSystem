using HRPersonnelSystem.UI.Areas.Admin.Models.AdminDTOs;
using Microsoft.AspNetCore.Mvc;

namespace HRPersonnelSystem.UI.Areas.Admin.ViewComponents
{
    public class AdminDashboardHeaderViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;

        public AdminDashboardHeaderViewComponent()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7085");
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var responseTask = await _httpClient.GetAsync($"api/Admin/{userId}");
            var readTask = await responseTask.Content.ReadAsAsync<AdminDTO>();

            AdminDTO admin = new AdminDTO
            {
                FirstName = readTask.FirstName,
                LastName = readTask.LastName,
                ImagePath = readTask.ImagePath
            };

            return View(admin);
        }
    }
}
