using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.Models.DTOs.CompanyDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        // GET: api/<CompanyController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var company = await _companyService.GetAllCompanyAsync();
            List<CompanyDTO> map = company.Select(item => _mapper.Map<CompanyDTO>(item)).ToList();
            return Ok(map);
        }

        // GET api/<CompanyController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var company = await _companyService.GetCompanyByIdAsync(id);
            var map = _mapper.Map<CompanyDTO>(company);
            return Ok(map);

            

        }


        // POST api/<CompanyController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCompanyDTO createCompanyDTO)
        {
            var addCompany = await _companyService.CreateCompanyAsync(createCompanyDTO);
            return Ok(addCompany);
        }




        // PUT api/<CompanyController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CompanyController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
