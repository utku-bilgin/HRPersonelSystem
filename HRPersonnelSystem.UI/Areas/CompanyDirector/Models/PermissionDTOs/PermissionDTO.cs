using HRPersonnelSystem.UI.Areas.Employee.Models.EmployeeDTOs;
using HRPersonnelSystem.UI.Areas.Employee.Models.Enums;

namespace HRPersonnelSystem.UI.Areas.CompanyDirector.Models.PermissionDTOs
{
    public class PermissionDTO
    {
        public Guid Id { get; set; }

        public PermissionType PermissionType { get; set; }

        public DateTime? StartDate { get; set; }

        public int? CountOfDay { get; set; }

        public DateTime? EndDate
        {
            get
            {
                if (StartDate.HasValue && CountOfDay.HasValue)
                {
                    return StartDate.Value.AddDays(CountOfDay.Value);
                }
                else
                {
                    return null;
                }
            }
        }

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;

        public DateTime? DateOfReply { get; set; } = DateTime.Now;

        public bool IsActive { get; set; } = true;

        public Guid EmployeeId { get; set; }

        public EmployeeEntity? EmployeeEntity { get; set; }

        public Gender Gender { get; set; }

        public string? FirstName { get; set; }
        
        public string? LastName { get; set; }
        
        public string? Department { get; set; }
    }
}
