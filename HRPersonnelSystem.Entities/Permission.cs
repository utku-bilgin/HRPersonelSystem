using HRPersonnelSystem.Core.BaseEntities;
using HRPersonnelSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Entities
{
	public class Permission : BaseEntity
	{
        public PermissionType PermissionType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate => StartDate.AddDays(CountOfDay);
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public int CountOfDay { get; set; } 
        public bool IsActive { get; set; } = true;
        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;
        public DateTime? DateOfReply { get; set; }
		
        public Guid? EmployeeId { get; set; }
		public Employee? Employee { get; set; }

        public Gender? Gender { get; set; }
    }
}
