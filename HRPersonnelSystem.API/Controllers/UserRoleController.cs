using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdvancePayment;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.Employees;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRole userRole;
        private readonly IMapper mapper;

        public UserRoleController(IUserRole userRole, IMapper mapper)
        {
            this.userRole = userRole;
            this.mapper = mapper;
        }
        // GET: api/<UserRoleController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var x = await userRole.GetAllUserRoleAsync();
            return Ok(x);
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDTO createEmployeeDTO)
        {
            var addPayment = await userRole.CreateUserRoleAsync(createEmployeeDTO.Id);
            return Ok(addPayment);
        }
        [HttpPut]
        public async Task<IActionResult> Put(CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            var addPayment = await userRole.CreateUserRoleCDAsync(createCompanyDirectorDTO.Id);
            return Ok(addPayment);
        }
    }
}
