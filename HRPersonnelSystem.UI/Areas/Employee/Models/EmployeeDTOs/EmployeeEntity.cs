using HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;
using HRPersonnelSystem.UI.Areas.Employee.Models.Images;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs
{
    public class EmployeeEntity
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } //ikinci adı
        public string LastName { get; set; }
        public string? SecondLastName { get; set; } //ikinci soyadı
        public string TCNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public DateTime DateOfHire { get; set; } //işe giriş tarihi
        public DateTime? DateOfTermination { get; set; } //işten çıkış tarihi
        public string Address { get; set; }
        public double Salary { get; set; } //maaş
        //public string? ImageFileName { get; set; }
        //public Image Image { get; set; }
        public bool IsActive { get; set; }
        public Gender Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public Guid CompanyId { get; set; }
        public string? ImagePath { get; set; }

    }
}
