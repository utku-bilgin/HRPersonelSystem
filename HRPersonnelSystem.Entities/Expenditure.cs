using HRPersonnelSystem.Core.BaseEntities;
using HRPersonnelSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Entities
{
	public class Expenditure : BaseEntity
	{
        public ExpenditureType ExpenditureType { get; set; }
        public decimal Amount { get; set; }

        public CurrencyUnit CurrencyUnit { get; set; }
		public DateTime RequestDate { get; set; }
		public ApprovalStatus ApprovalStatus { get; set; }
		public DateTime? DateOfReply { get; set; }
        public string? ImagePath { get; set; }
        //public Image? Image { get; set; }
        //public Guid? ImageId { get; set; }
        public Guid? EmployeeId { get; set; }
		public Employee? Employee { get; set; }
	}
}
