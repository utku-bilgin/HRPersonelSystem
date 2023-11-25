using HRPersonnelSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface IUserRole
    {
        Task<List<AppUserRole>> GetAllUserRoleAsync();
        Task<AppUserRole> CreateUserRoleAsync(Guid id);
        Task<AppUserRole> CreateUserRoleCDAsync(Guid id);
    }
}
