﻿using HRPersonnelSystem.Models.DTOs.AdminDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.Abstract.IServices
{
    public interface IAdminForCompanyListService
    {
        Task<List<AdminForCompanyListDTO>> GetAllCompanyIsActiveTrueAsync();

        Task<List<AdminForCompanyListDTO>> GetAllCompanyIsActiveFalseAsync();
    }
}
