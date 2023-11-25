using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdminDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class AdminForCompanyDirectorListService : IAdminForCompanyDirectorListService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminForCompanyDirectorListService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<AdminForCompanyDirectorListDTO>> GetAllCompanyDirectorIsActiveTrueAsync()
        {
            var companyDirectors = await _unitOfWork.GetRepository<CompanyDirector>().GetAllAsync(x => x.IsActive == true);

            var mappedData = new List<AdminForCompanyDirectorListDTO>();

            foreach (var companyDirector in companyDirectors)
            {
                var dto = _mapper.Map<AdminForCompanyDirectorListDTO>(companyDirector);

                // Şirket bilgisi alınması
                var company = await _unitOfWork.GetRepository<Company>().GetByIdAsync(companyDirector.CompanyId ?? Guid.Empty);
                if (company != null)
                {
                    dto.CompanyName = company.CompanyName;
                }

                mappedData.Add(dto);
            }

            return mappedData;
        }


        //public async Task<List<AdminForCompanyDirectorListDTO>> GetAllCompanyDirectorIsActiveFalseAsync()
        //{
        //    var threeYearsAgo = DateTime.Now.AddYears(-3);

        //    var companyDirector = await _unitOfWork.GetRepository<CompanyDirector>().GetAllAsync(x => x.IsActive == false && x.DateOfTermination >= threeYearsAgo);
        //    var map = _mapper.Map<List<AdminForCompanyDirectorListDTO>>(companyDirector);
        //    return map;
        //}

        public async Task<List<AdminForCompanyDirectorListDTO>> GetAllCompanyDirectorIsActiveFalseAsync()
        {
            var threeYearsAgo = DateTime.Now.AddYears(-3);

            var companyDirectors = await _unitOfWork.GetRepository<CompanyDirector>().GetAllAsync(x => x.IsActive == false && x.DateOfTermination >= threeYearsAgo);

            var mappedData = new List<AdminForCompanyDirectorListDTO>();

            foreach (var companyDirector in companyDirectors)
            {
                var dto = _mapper.Map<AdminForCompanyDirectorListDTO>(companyDirector);

                // Şirket bilgisi alınması
                var company = await _unitOfWork.GetRepository<Company>().GetByIdAsync(companyDirector.CompanyId ?? Guid.Empty);
                if (company != null)
                {
                    dto.CompanyName = company.CompanyName;
                }

                mappedData.Add(dto);
            }

            return mappedData;
        }
    }
}
