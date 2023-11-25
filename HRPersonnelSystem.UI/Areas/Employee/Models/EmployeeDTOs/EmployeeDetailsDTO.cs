using HRPersonnelSystem.UI.Areas.Employee.Models.Images;

namespace HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs
{
	public class EmployeeDetailsDTO
    {
        public Guid Id { get; set; }
        //public Guid ImageId { get; set; }
        //public Image Image { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string SecondLastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string TCNumber { get; set; }
        public DateTime DateOfHire { get; set; }
        public DateTime DateOfTermination { get; set; }
        public string Job { get; set; }
        public string Department { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }
        public string Role { get; set; }
        //public string FileName { get; set; }
        public string? ImagePath { get; set; }
    }
}
