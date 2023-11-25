using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.BLL.Concrete.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminForCompanyListIsActiveTrueController : ControllerBase
    {
        private readonly IAdminForCompanyListService _adminForCompanyListService;

       public AdminForCompanyListIsActiveTrueController(IAdminForCompanyListService adminForCompanyListService)
        {
            _adminForCompanyListService = adminForCompanyListService;
        }

        // GET: api/<AdminForCompanyListIsActiveTrueController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var company = await _adminForCompanyListService.GetAllCompanyIsActiveTrueAsync();
            return Ok(company);
        }
    }
}
