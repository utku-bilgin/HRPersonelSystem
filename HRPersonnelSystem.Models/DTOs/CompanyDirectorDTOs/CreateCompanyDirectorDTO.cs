using HRPersonnelSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Models.DTOs.CompanyDirectorDTOs
{
    public class CreateCompanyDirectorDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public string? SecondLastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        //public string Email { get; set; }
        public DateTime DateOfHire { get; set; }
        public DateTime? DateOfTermination { get; set; }
        public string BirthPlace { get; set; }
        public string Phone { get; set; }
        public string Job { get; set; }
        public string Departman { get; set; }
        public double Salary { get; set; }
        public string TCNumber { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public bool IsActive { get; set; } = true;
        //public string Role { get; set; }
        public string? ImagePath { get; set; }
       


    }
}
