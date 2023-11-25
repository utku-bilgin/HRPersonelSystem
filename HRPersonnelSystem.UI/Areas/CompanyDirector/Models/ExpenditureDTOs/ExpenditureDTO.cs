using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.Models.ExpenditureDTOs
{
    public class ExpenditureDTO
    {
        public Guid Id { get; set; }
        public ExpenditureType ExpenditureType { get; set; }
        public CurrencyUnit CurrencyUnit { get; set; }
        public decimal Amount { get; set; }
        public Guid EmployeeId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Department { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;
        public DateTime? DateOfReply { get; set; } = DateTime.Now;
        public string? ImagePath { get; set; }
    }
}
