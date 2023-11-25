using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Models.DTOs.AdminDTOs
{
    public class AdminUpdateDTO
    {
        public Guid Id { get; set; }
        public IFormFile? Photo { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
    }
}
