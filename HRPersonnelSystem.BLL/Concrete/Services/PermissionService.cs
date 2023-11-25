using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.PermissionDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PermissionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Permission> CreatePermissionAsync(PermissionDTO permissionDTO)
        {
            try
            {
                var permission = _mapper.Map<Permission>(permissionDTO);
                await _unitOfWork.GetRepository<Permission>().AddAsync(permission);
                await _unitOfWork.SaveAsync();
                return permission;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Permission> DeletePermissionAsync(Guid id)
        {
            try
            {
                var permission = await _unitOfWork.GetRepository<Permission>().GetByIdAsync(id);
                await _unitOfWork.GetRepository<Permission>().HardDeleteAsync(permission);
                await _unitOfWork.SaveAsync();
                return permission;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Permission>> GetAllPermissionAsync()
        {
            try
            {
                var permissionList = await _unitOfWork.GetRepository<Permission>().GetAllAsync();
                return permissionList;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Permission> GetPermissionAsync(Guid id)
        {
            try
            {
                var permission = await _unitOfWork.GetRepository<Permission>().GetByIdAsync(id);
                return permission;
            }
            catch (Exception)
            {
                throw;
            }
        }

		public async Task<Permission> UpdatePermissionAsync(PermissionDTO permission)
		{
            var map = _mapper.Map<Permission>(permission);

			await _unitOfWork.GetRepository<Permission>().UpdateAsync(map);
			await _unitOfWork.SaveAsync();

			return map;
		}
	}
}
