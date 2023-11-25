using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.BLL.Concrete.Services;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.Employees;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDirectorForEmployeeListIsActiveTrueController : ControllerBase
    {
        private readonly ICompanyDirectorForEmployeeListService _companyDirectorForEmployeeListService;

        public CompanyDirectorForEmployeeListIsActiveTrueController(ICompanyDirectorForEmployeeListService companyDirectorForEmployeeListService)
        {
            _companyDirectorForEmployeeListService = companyDirectorForEmployeeListService;
        }


        // GET: api/<CompanyDirectorForEmployeeListIsActiveTrueController>
        [HttpGet]
        public async Task<IActionResult> Get(Guid Id)
        {
            var employees = await _companyDirectorForEmployeeListService.GetAllEmployeIsActiveTrueAsync(Id);
            return Ok(employees);
        }

        
    }
}
