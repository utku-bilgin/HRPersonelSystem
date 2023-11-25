using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdminDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface IAdminService
    {
        Task<Admin> GetAdminByIdAsync(Guid id);
        Task<Admin> AdminUpdateAsync(AdminUpdateDTO adminUpdateDTO);
    }
}
