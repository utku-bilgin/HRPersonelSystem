using HRPersonnelSystem.Core.BaseEntities;
using HRPersonnelSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Entities
{
	public class Admin : AppUser, IBaseEntity
	{
		public string FirstName { get; set; }
		public string? MiddleName { get; set; } //ikinci adı
		public string LastName { get; set; }
		public string? SecondLastName { get; set; } //ikinci soyadı
		public string TCNumber { get; set; }
		public Gender Gender { get; set; }
		public DateTime? BirthDate { get; set; }
		public string BirthPlace { get; set; }
		public string? CompanyName { get; set; }
		public string? Department { get; set; }
		public string Job { get; set; }
		public DateTime DateOfHire { get; set; } //işe giriş tarihi
		public DateTime? DateOfTermination { get; set; } //işten çıkış tarihi
		public string Address { get; set; }
		public double Salary { get; set; }
		public bool IsActive { get; set; }
		public string? ImagePath { get; set; }
    }
}
