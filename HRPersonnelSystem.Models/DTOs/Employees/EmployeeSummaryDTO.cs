using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Models.DTOs.Employees
{
	public class EmployeeSummaryDTO
	{
		public Guid Id { get; set; }
		//public string ImageFileName { get; set; }
		public string FirstName { get; set; }
		public string? MiddleName { get; set; }
		public string LastName { get; set; }
		public string? SecondLastName { get; set; }
		public string Job { get; set; }
		public string Department { get; set; }
		public string Address { get; set; }

        public string? ImagePath { get; set; }

    }
}
