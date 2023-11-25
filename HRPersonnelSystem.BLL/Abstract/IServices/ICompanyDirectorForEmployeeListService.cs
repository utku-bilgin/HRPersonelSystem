using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface ICompanyDirectorForEmployeeListService
    {
        Task<List<CompanyDirectorForEmployeeListDTO>> GetAllEmployeIsActiveTrueAsync(Guid Id);
        Task<List<CompanyDirectorForEmployeeListDTO>> GetAllEmployeIsActiveFalseAsync(Guid Id);
    }
}
