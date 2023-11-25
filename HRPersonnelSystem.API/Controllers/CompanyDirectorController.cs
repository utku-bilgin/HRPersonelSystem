using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDirectorController : ControllerBase
    {
        private readonly ICompanyDirectorService _directorService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IUnitOfWork _unitOfWork;

        public CompanyDirectorController(ICompanyDirectorService directorService, IMapper mapper,  UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IUnitOfWork unitOfWork)
        {
            
            _directorService = directorService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        // GET api/<CompanyDirectorController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var director = await _directorService.GetDirectorByIdAsync(id);
            var map = _mapper.Map<CompanyDirectorDTO>(director);
            return Ok(map);
        }

        // POST api/<CompanyDirectorController>
        [HttpPost]
        public async Task<IActionResult> Post(CreateCompanyDirectorDTO createCompanyDirectorDTO)
        {
            try
            {
                var director = await _directorService.CreateDirectorAsync(createCompanyDirectorDTO);
                CreateCompanyDirectorDTO map = _mapper.Map<CreateCompanyDirectorDTO>(director);

                return Ok(map);
            }
            catch (Exception ex)
            {



                return StatusCode(500, "Bir hata oluştu: " + ex.Message);
            }
        }

        // PUT api/<CompanyDirectorController>/5
        [HttpPut]
        public async Task<IActionResult> Put(CompanyDirectorUpdateDTO companyDirectorUpdateDTO)
        {
            await _directorService.UpdateCompanyDirectorAsync(companyDirectorUpdateDTO);
            return Ok(companyDirectorUpdateDTO);
        }

        // DELETE api/<CompanyDirectorController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
