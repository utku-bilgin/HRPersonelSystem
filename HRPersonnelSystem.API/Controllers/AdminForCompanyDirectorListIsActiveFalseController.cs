using HRPersonnelSystem.BLL.Abstract.IServices;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminForCompanyDirectorListIsActiveFalseController : ControllerBase
    {
        private readonly IAdminForCompanyDirectorListService _adminForCompanyDirectorListService;

        public AdminForCompanyDirectorListIsActiveFalseController(IAdminForCompanyDirectorListService adminForCompanyDirectorListService)
        {
            _adminForCompanyDirectorListService = adminForCompanyDirectorListService;
        }

        // GET: api/<AdminForCompanyDirectorListIsActiveFalseController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var admin = await _adminForCompanyDirectorListService.GetAllCompanyDirectorIsActiveFalseAsync();
            return Ok(admin);
        }

        
    }
}
