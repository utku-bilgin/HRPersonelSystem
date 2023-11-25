using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdvancePayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
	public interface IAdvancePaymentService
	{
		Task<AdvancePayment> GetAdvancePaymentAsync(Guid id);
		Task<AdvancePayment> CreateAdvancePaymentAsync(AdvancePaymentCreateDTO paymentCreateDTO);
		Task<AdvancePayment> DeleteAdvancePaymentAsync(Guid id);
		Task<AdvancePayment> UpdatePaymentAsync(AdvancePaymentDTO advancePaymentDTO);
		Task<List<AdvancePayment>> GetAllAdvancePaymentAsync();

	}
}
