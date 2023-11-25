using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.Employees;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class CompanyDirectorForEmployeeListService : ICompanyDirectorForEmployeeListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;

        public CompanyDirectorForEmployeeListService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<AppUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _userManager = userManager;
        }


        public async Task<List<CompanyDirectorForEmployeeListDTO>> GetAllEmployeIsActiveTrueAsync(Guid Id)
        {
            var companyDirector = await _unitOfWork.GetRepository<CompanyDirector>().GetByIdAsync(Id);
            var companyId = companyDirector.CompanyId;


            var employees = await _unitOfWork.GetRepository<Employee>().GetAllAsync(x => x.IsActive && x.CompanyId == companyId);
            var map = _mapper.Map<List<CompanyDirectorForEmployeeListDTO>>(employees);
            return map;
        }



        public async Task<List<CompanyDirectorForEmployeeListDTO>> GetAllEmployeIsActiveFalseAsync(Guid Id)
        {
            var companyDirector = await _unitOfWork.GetRepository<CompanyDirector>().GetByIdAsync(Id);
            var companyId = companyDirector.CompanyId;
            var threeYearsAgo = DateTime.Now.AddYears(-3);


            var employee = await _unitOfWork.GetRepository<Employee>().GetAllAsync(x => x.IsActive == false && x.DateOfTermination >= threeYearsAgo && x.CompanyId == companyId);
            var map = _mapper.Map<List<CompanyDirectorForEmployeeListDTO>>(employee);
            return map;
        }
    }
}
