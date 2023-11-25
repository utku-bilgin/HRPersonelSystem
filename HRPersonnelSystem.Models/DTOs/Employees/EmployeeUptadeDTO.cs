using HRPersonnelSystem.Entities;
using Microsoft.AspNetCore.Http;

namespace HRPersonnelSystem.Models.DTOs.Employees
{
    public class EmployeeUptadeDTO
    {
        public Guid Id { get; set; }
        //public Image? Image { get; set; }
        public IFormFile? Photo { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string? ImagePath { get; set; }
    }
}
