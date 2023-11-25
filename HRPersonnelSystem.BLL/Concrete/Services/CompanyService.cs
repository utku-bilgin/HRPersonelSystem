using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CompanyService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Company> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO)
        {
            try
            {
                Company company = _mapper.Map<Company>(createCompanyDTO);
                await _unitOfWork.GetRepository<Company>().AddAsync(company);
                await _unitOfWork.SaveAsync();
                return company;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<List<Company>> GetAllCompanyAsync()
        {
            try
            {
                var listCompany = await _unitOfWork.GetRepository<Company>().GetAllAsync();

                return listCompany;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Company> GetCompanyByIdAsync(Guid id)
        {
            try
            {
                Company company = await _unitOfWork.GetRepository<Company>().GetByIdAsync(id);
                return company;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
