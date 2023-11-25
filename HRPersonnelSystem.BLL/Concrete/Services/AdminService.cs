using AutoMapper;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using HRPersonnelSystem.Models.DTOs.AdminDTOs;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Concrete.Services
{
    public class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Admin> GetAdminByIdAsync(Guid id)
        {
            try
            {
                Admin admin = await _unitOfWork.GetRepository<Admin>().GetByIdAsync(id);
                return admin;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Admin> AdminUpdateAsync(AdminUpdateDTO adminUpdateDTO)
        {
            var admin=await _unitOfWork.GetRepository<Admin>().GetAsync(x=> x.IsActive && x.Id==adminUpdateDTO.Id);

            admin.ImagePath = adminUpdateDTO.ImagePath;
            admin.Address = adminUpdateDTO.Address;
            admin.PhoneNumber = adminUpdateDTO.PhoneNumber;

            await _unitOfWork.GetRepository<Admin>().UpdateAsync(admin);
            await _unitOfWork.SaveAsync();
            //var map= _mapper.Map<Admin>(adminUpdateDTO);
            return admin;
        }


    }
}
