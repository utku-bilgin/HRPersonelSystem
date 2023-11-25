using HRPersonnelSystem.BLL.Abstract.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminForCompanyListIsActiveFalseController : ControllerBase
    {
        private readonly IAdminForCompanyListService _adminForCompanyListService;

        public AdminForCompanyListIsActiveFalseController(IAdminForCompanyListService adminForCompanyListService)
        {
            _adminForCompanyListService = adminForCompanyListService;
        }

        // GET: api/<AdminForCompanyListIsActiveFalseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _adminForCompanyListService.GetAllCompanyIsActiveFalseAsync();
            return Ok(employees);
        }
    }
}
