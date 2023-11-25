using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.BLL.ImageHelpers;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdvancePayment;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
	public class AdvancePaymentService : IAdvancePaymentService
	{
		private readonly IUnitOfWork unitOfWork;
		private readonly IMapper mapper;

		public AdvancePaymentService(IUnitOfWork unitOfWork,IMapper mapper)
        {
			this.unitOfWork = unitOfWork;
			this.mapper = mapper;
			
		}

		public async Task<AdvancePayment> CreateAdvancePaymentAsync(AdvancePaymentCreateDTO paymentCreateDTO)
		{
			try
			{
				AdvancePayment advancePayment =   mapper.Map<AdvancePayment>(paymentCreateDTO);
				await  unitOfWork.GetRepository<AdvancePayment>().AddAsync(advancePayment);
                await unitOfWork.SaveAsync();
                return advancePayment;
			}
			catch (Exception ex)
			{
				throw ; 
			}
		}

		public async Task<AdvancePayment> DeleteAdvancePaymentAsync(Guid id)
		{
			try
			{
				AdvancePayment advancePayment = await unitOfWork.GetRepository<AdvancePayment>().GetByIdAsync(id);
				//var map = mapper.Map<AdvancePayment>(advancePayment);
				await unitOfWork.GetRepository<AdvancePayment>().HardDeleteAsync(advancePayment);
				await unitOfWork.SaveAsync();
				return advancePayment;

            }
			catch (Exception ex)
			{
				throw;
			}
		}

		public async Task<AdvancePayment> GetAdvancePaymentAsync(Guid id)
		{
			try
			{
				var payment = await unitOfWork.GetRepository<AdvancePayment>().GetByIdAsync(id);
				return payment;
			}
			catch (Exception)
			{

				throw;
			}
		}

		public async Task<List<AdvancePayment>> GetAllAdvancePaymentAsync()
		{
			try
			{
				var listPayment = await unitOfWork.GetRepository<AdvancePayment>().GetAllAsync();
				return listPayment;
			}
			catch (Exception)
			{

				throw;
			}
		}
		public async Task<AdvancePayment> UpdatePaymentAsync(AdvancePaymentDTO advancePaymentDTO)
		{
			//var advancePayment = await unitOfWork.GetRepository<AdvancePayment>().GetAsync(x=>x.Id == advancePaymentDTO.Id);

			var map = mapper.Map<AdvancePayment>(advancePaymentDTO);

			await unitOfWork.GetRepository<AdvancePayment>().UpdateAsync(map);
			await unitOfWork.SaveAsync();
			//var map=_mapper.Map<CompanyDirector>(companyDirectorUpdateDTO);
			return map;
		}
	}
}
