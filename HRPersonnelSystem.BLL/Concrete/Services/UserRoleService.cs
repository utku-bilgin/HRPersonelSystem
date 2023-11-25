using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class UserRoleService : IUserRole
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserRoleService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;

        }
        public async Task<List<AppUserRole>> GetAllUserRoleAsync()
        {
            try
            {
                var listrole = await unitOfWork.GetRepository<AppUserRole>().GetAllAsync();
                return listrole;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AppUserRole> CreateUserRoleAsync(Guid id)
        {
            try
            {
                AppUserRole userRole = new AppUserRole
                {
                    RoleId = Guid.Parse("cba7d3c3-51e2-4694-9003-4177b2c43808"),
                    UserId = id
                };
                await unitOfWork.GetRepository<AppUserRole>().AddAsync(userRole);
                await unitOfWork.SaveAsync();
                return userRole;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public async Task<AppUserRole> CreateUserRoleCDAsync(Guid id)
        {
            try
            {
                AppUserRole userRole = new AppUserRole
                {
                    RoleId = Guid.Parse("b452c8e5-2d3c-4806-94b1-ad8e464ddbfe"),
                    UserId = id
                };
                await unitOfWork.GetRepository<AppUserRole>().AddAsync(userRole);
                await unitOfWork.SaveAsync();
                return userRole;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
