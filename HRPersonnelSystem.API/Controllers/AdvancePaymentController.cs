using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.Models.DTOs.AdvancePayment;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HRPersonnelSystem.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AdvancePaymentController : ControllerBase
	{
		private readonly IAdvancePaymentService paymentService;
		private readonly IMapper mapper;

		public AdvancePaymentController(IAdvancePaymentService paymentService,IMapper mapper)
        {
			this.paymentService = paymentService;
			this.mapper = mapper;
		}


		//GET api/<AdvancePaymentController>/5
		[HttpGet]
		public async Task<IActionResult> Get()
		{
			var payment = await paymentService.GetAllAdvancePaymentAsync();
            List<AdvancePaymentDTO> map = payment.Select(item => mapper.Map<AdvancePaymentDTO>(item)).ToList(); 
			return Ok(map);
		}

		// POST api/<AdvancePaymentController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] AdvancePaymentCreateDTO advancePaymentCreateDTO)
		{
			var addPayment = await paymentService.CreateAdvancePaymentAsync(advancePaymentCreateDTO);
			return Ok(addPayment);
		}

		[HttpPut]
		public async Task<IActionResult> Put(AdvancePaymentDTO advancePaymentDTO)
		{
			await paymentService.UpdatePaymentAsync(advancePaymentDTO);
			return Ok(advancePaymentDTO);
		}


		// DELETE api/<AdvancePaymentController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var itemToDelete = await paymentService.DeleteAdvancePaymentAsync(id);
			return Ok(itemToDelete);
		}
	}
}
