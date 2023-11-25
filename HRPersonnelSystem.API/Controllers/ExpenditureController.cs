using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.Models.DTOs.ExpenditureDTOs;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpenditureController : ControllerBase
    {
        private readonly IExpenditureService _expenditureService;
        private readonly IMapper _mapper;


        public ExpenditureController(IExpenditureService expenditureService, IMapper mapper)
        {
            this._expenditureService = expenditureService;
            this._mapper = mapper;
        }



        // GET: api/<ExpenditureController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var expendituresList = await _expenditureService.GetAllExpenditureAsync();

            List<EmployeeExpenditureDTO> map = expendituresList.Select(item => _mapper.Map<EmployeeExpenditureDTO>(item)).ToList();

            return Ok(map);

        }

        // GET api/<ExpenditureController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ExpenditureController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeExpenditureDTO createExpenditureDTO)
        {
            var createExpenditure = await _expenditureService.CreateExpenditureAsync(createExpenditureDTO);
            return Ok(createExpenditure);
        }

        // PUT api/<ExpenditureController>/5
        [HttpPut]
        public async Task<IActionResult> Put(EmployeeExpenditureDTO employeeExpenditureDTO)
        {
            var updateExpenditure = await _expenditureService.UpdateExpenditureAsync(employeeExpenditureDTO);
            return Ok(updateExpenditure);
        }

        // DELETE api/<ExpenditureController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var deleteExpenditure = await _expenditureService.DeleteExpenditureAsync(id);
            return Ok(deleteExpenditure);
        }
    }
}
