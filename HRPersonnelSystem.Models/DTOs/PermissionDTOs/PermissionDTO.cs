using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Models.DTOs.PermissionDTOs
{
    public class PermissionDTO
    {
        public Guid Id { get; set; }

        public PermissionType PermissionType { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate => StartDate.AddDays(CountOfDay);

        public DateTime RequestDate { get; set; } = DateTime.Now;

        public int CountOfDay { get; set; }

        public ApprovalStatus ApprovalStatus { get; set; } = ApprovalStatus.Bekleyen;

        public DateTime? DateOfReply { get; set; }

        public bool IsActive { get; set; } = true;

        public Guid? EmployeeId { get; set; }

        public Employee? EmployeeEntity { get; set; }

        public Gender Gender { get; set; }
    }
}
