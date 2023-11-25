using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
//using HRPersonnelSystem.BLL.ImageHelpers;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.Employees;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        //private readonly IImageHelper _imageHelper;
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeController(IEmployeeService employeeService, IMapper mapper, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, /*IImageHelper imageHelper,*/ IUnitOfWork unitOfWork)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            //_imageHelper = imageHelper;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employee = await _unitOfWork.GetRepository<Employee>().GetAllAsync();
            var map = _mapper.Map<List<EmployeeDetailDTO>>(employee);
            return Ok(map);
        }

        // GET api/<MovieController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            // Kullanıcının JWT token'ından rollerini kontrol edin
            //var userRoles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            //if (!userRoles.Contains("Employee"))
            //{
            //    return Unauthorized("Bu işlemi gerçekleştirmek için gerekli izne sahip değilsiniz.");
            //}

            var employee = await _employeeService.GetEmployeeIsActiveAsync(id);
            return Ok(employee);
        }


        // PUT api/<MovieController>/5
        [HttpPut]
        public async Task<IActionResult> Put(EmployeeUptadeDTO employeeUptadeDTO)
        {
            // Kullanıcının JWT token'ından rollerini kontrol edin
            //var userRoles = User.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            //if (!userRoles.Contains("Employee"))
            //{
            //    return Unauthorized("Bu işlemi gerçekleştirmek için gerekli izne sahip değilsiniz.");
            //}

            //if (id != employeeUptadeDTO.Id)
            //{
            //    return BadRequest("İstek gövdesindeki ID ile URI'deki ID uyuşmuyor.");
            //}

            await _employeeService.UpdateEmployeeAsync(employeeUptadeDTO);

            return Ok(employeeUptadeDTO);
        }


        [HttpPost]
        public async Task<IActionResult> Post(CreateEmployeeDTO createEmployeeDTO)
        {
            try
            {
                var employee = await _employeeService.CreateEmployeeAsync(createEmployeeDTO);
                CreateEmployeeDTO map = _mapper.Map<CreateEmployeeDTO>(employee);



                return Ok(map);
            }
            catch (Exception ex)
            {



                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }



        }
    }
}
