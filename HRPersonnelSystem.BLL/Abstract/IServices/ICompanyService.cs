using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.CompanyDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface ICompanyService
    {
        Task<Company> GetCompanyByIdAsync(Guid id);
        Task<Company> CreateCompanyAsync(CreateCompanyDTO createCompanyDTO);
        Task<List<Company>> GetAllCompanyAsync();
    }
}
