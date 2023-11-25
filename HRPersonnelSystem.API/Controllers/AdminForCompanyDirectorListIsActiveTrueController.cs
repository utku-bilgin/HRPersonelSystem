using HRPersonnelSystem.BLL.Abstract.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminForCompanyDirectorListIsActiveTrueController : ControllerBase
    {
        private readonly IAdminForCompanyDirectorListService _adminForCompanyDirectorListService;

        public AdminForCompanyDirectorListIsActiveTrueController(IAdminForCompanyDirectorListService adminForCompanyDirectorListService)
        {
            _adminForCompanyDirectorListService = adminForCompanyDirectorListService;    
        }

        // GET: api/<AdminForCompanyDirectorListIsActiveTrueController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var admin = await _adminForCompanyDirectorListService.GetAllCompanyDirectorIsActiveTrueAsync();
            return Ok(admin);
        }

        
    }
}
