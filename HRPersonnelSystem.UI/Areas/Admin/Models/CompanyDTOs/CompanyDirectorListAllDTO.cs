using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;

namespace HRPersonnelSystem.UI.Areas.Admin.Models.CompanyDTOs
{
    public class CompanyDirectorListAllDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } //ikinci adı
        public string LastName { get; set; }
        public string? SecondLastName { get; set; } //ikinci soyadı
        public string TCNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        //public string BirthPlace { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public DateTime DateOfHire { get; set; } //işe giriş tarihi
        public DateTime? DateOfTermination { get; set; } //işten çıkış tarihi
        public string Address { get; set; }
        //public double Salary { get; set; } //maaş
        public bool IsActive { get; set; }

        //public string? ImagePath { get; set; }
        //public Company? Company { get; set; }
        //public Guid? CompanyId { get; set; }
    }
}
