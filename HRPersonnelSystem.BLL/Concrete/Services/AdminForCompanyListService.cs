using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdminDTOs;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class AdminForCompanyListService : IAdminForCompanyListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminForCompanyListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AdminForCompanyListDTO>> GetAllCompanyIsActiveTrueAsync()
        {
            var company = await _unitOfWork.GetRepository<Company>().GetAllAsync(x => x.IsActive == true);

            var map = _mapper.Map<List<AdminForCompanyListDTO>>(company);
            return map;
        }

        public async Task<List<AdminForCompanyListDTO>> GetAllCompanyIsActiveFalseAsync()
        {
            var company = await _unitOfWork.GetRepository<Company>().GetAllAsync(x => x.IsActive == false);

            var map = _mapper.Map<List<AdminForCompanyListDTO>>(company);
            return map;
        }
    }
}
