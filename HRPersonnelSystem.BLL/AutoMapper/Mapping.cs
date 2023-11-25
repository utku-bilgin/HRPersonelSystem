using AutoMapper;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.Employees;
using HRPersonnelSystem.Models.DTOs.ExpenditureDTOs;
using HRPersonnelSystem.Models.DTOs.AdvancePayment;
using HRPersonnelSystem.Models.DTOs.PermissionDTOs;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.AdminDTOs;
using HRPersonnelSystem.Models.DTOs.CompanyDTOs;

namespace HRPersonnelSystem.BLL.AutoMapper
{
    public class Mapping:Profile
	{
        public Mapping()
        {
            CreateMap<EmployeeSummaryDTO, Employee>().ReverseMap();
			CreateMap<EmployeeDetailDTO, Employee>().ReverseMap();
			CreateMap<EmployeeUptadeDTO, Employee>().ReverseMap();
			CreateMap<EmployeeExpenditureDTO, Expenditure>().ReverseMap();
            CreateMap<AdvancePaymentDTO, AdvancePayment>().ReverseMap();          
            CreateMap<AdvancePaymentCreateDTO, AdvancePayment>().ReverseMap();          
            CreateMap<PermissionDTO, Permission>().ReverseMap();
            CreateMap<CompanyDirectorUpdateDTO, CompanyDirector>().ReverseMap();
            CreateMap<CompanyDirectorDTO, CompanyDirector>().ReverseMap();
            CreateMap<CreateEmployeeDTO, Employee>().ReverseMap();
            CreateMap<CompanyDirectorForEmployeeListDTO, Employee>().ReverseMap();
            CreateMap<CreateCompanyDirectorDTO, CompanyDirector>().ReverseMap();
            CreateMap<CompanyDtoForCompanyDirector, Company>().ReverseMap();

            CreateMap<AdminDTO, Admin>().ReverseMap();
            CreateMap<AdminUpdateDTO, Admin>().ReverseMap();
            CreateMap<AdminForCompanyListDTO, Company>().ReverseMap();
            CreateMap<AdminForCompanyDirectorListDTO, CompanyDirector>().ReverseMap();
            CreateMap<CompanyDTO, Company>().ReverseMap();
            CreateMap<CreateCompanyDTO, Company>().ReverseMap();

        }
    }
}
