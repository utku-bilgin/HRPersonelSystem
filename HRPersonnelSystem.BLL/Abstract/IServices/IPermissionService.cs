using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.PermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface IPermissionService
    {
        Task<List<Permission>> GetAllPermissionAsync();

        Task<Permission> GetPermissionAsync(Guid id);

        Task<Permission> CreatePermissionAsync(PermissionDTO permissionDTO);

        Task<Permission> DeletePermissionAsync(Guid id);

        Task<Permission> UpdatePermissionAsync(PermissionDTO permission);

	}
}
