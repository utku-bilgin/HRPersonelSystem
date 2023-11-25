using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.ExpenditureDTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class ExpenditureService : IExpenditureService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public ExpenditureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Bütün harcamaları getiren metottur.
        /// </summary>
        /// <returns></returns>
        public async Task<List<Expenditure>> GetAllExpenditureAsync()
        {
            try
            {
                var listExpenditure = await _unitOfWork.GetRepository<Expenditure>().GetAllAsync();

                return listExpenditure;

            }
            catch (Exception)
            {

                throw;
            }          
        }

        /// <summary>
        /// ID ye göre tek bir harcama getiren metottur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Expenditure> GetExpenditureAsync(Guid id)
        {
            try
            {
                var expenditure = await _unitOfWork.GetRepository<Expenditure>().GetByIdAsync(id);               

                return expenditure;
            }
            catch (Exception)
            {

                throw;
            }          
        }

        /// <summary>
        /// Harcamayı silen metottur.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Expenditure> DeleteExpenditureAsync(Guid id)
        {
            try
            {
                var deleteExpenditure = await _unitOfWork.GetRepository<Expenditure>().GetByIdAsync(id);
                await _unitOfWork.GetRepository<Expenditure>().HardDeleteAsync(deleteExpenditure);
                await _unitOfWork.SaveAsync();
                var map = _mapper.Map<Expenditure>(deleteExpenditure);
                return map;
            }
            catch (Exception)
            {

                throw;
            }
          
        }

        /// <summary>
        /// Yeni bir harcama oluşturan metottur.
        /// </summary>
        /// <param name="employeeExpenditureDTO"></param>
        /// <returns></returns>
        public async Task<Expenditure> CreateExpenditureAsync(EmployeeExpenditureDTO createExpenditureDTO)
        {
            try
            {
                Expenditure expenditure = _mapper.Map<Expenditure>(createExpenditureDTO);

                await _unitOfWork.GetRepository<Expenditure>().AddAsync(expenditure);

                await _unitOfWork.SaveAsync();
                return expenditure;
            }
            catch (Exception)
            {

                throw;
            }          

        }

        public async Task<Expenditure> UpdateExpenditureAsync(EmployeeExpenditureDTO updateExpenditureDTO)
        {
            var map = _mapper.Map<Expenditure>(updateExpenditureDTO);
            await _unitOfWork.GetRepository<Expenditure>().UpdateAsync(map);
            await _unitOfWork.SaveAsync();
            return map;
        }
    }
}
