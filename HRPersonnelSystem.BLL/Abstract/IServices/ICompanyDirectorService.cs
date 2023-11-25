using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface ICompanyDirectorService
    {
        Task<CompanyDirector> GetDirectorByIdAsync(Guid id);
        Task<CompanyDirector> UpdateCompanyDirectorAsync(CompanyDirectorUpdateDTO companyDirectorUpdateDTO);
        Task<CompanyDirector> CreateDirectorAsync(CreateCompanyDirectorDTO createCompanyDirectorDTO);
    }
}
