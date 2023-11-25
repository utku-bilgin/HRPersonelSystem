using HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs;
using HRPersonnelSystem.Models.DTOs.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface IPasswordResetService
    {
        Task<string> GenerateRandomPasswordAsync();
        //Task<bool> SendPasswordResetEmailAsync(string email, string newPassword);
        Task<bool> ResetCompanyDirectorPasswordAsync(Guid Id);
        Task<bool> ResetEmployeePasswordAsync(Guid Id);
        Task<string> GenerateEmail(CreateCompanyDirectorDTO createCompanyDirectorDTO);
        Task<string> GenerateEmailEmployee(CreateEmployeeDTO createEmployeeDTO);
        Task<bool> SendPasswordResetEmailAsync(CreateCompanyDirectorDTO createCompanyDirectorDTO);
        Task<bool> SendPasswordResetEmailAsyncEmployee(CreateEmployeeDTO createEmployeeDTO);
        string HashPassword(string password);
        bool VerifyPassword(string hashedPassword, string password);
    }
}
