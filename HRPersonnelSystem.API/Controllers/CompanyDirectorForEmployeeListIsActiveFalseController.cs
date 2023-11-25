using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.BLL.Concrete.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDirectorForEmployeeListIsActiveFalseController : ControllerBase
    {
        private readonly ICompanyDirectorForEmployeeListService _companyDirectorForEmployeeListService;

        public CompanyDirectorForEmployeeListIsActiveFalseController(ICompanyDirectorForEmployeeListService companyDirectorForEmployeeListService)
        {
            _companyDirectorForEmployeeListService = companyDirectorForEmployeeListService;
        }

        // GET: api/<CompanyDirectorForEmployeeListIsActiveTrueController>
        [HttpGet]
        public async Task<IActionResult> Get(Guid Id)
        {
            var employees = await _companyDirectorForEmployeeListService.GetAllEmployeIsActiveFalseAsync(Id);
            return Ok(employees);
        }
    }
}
