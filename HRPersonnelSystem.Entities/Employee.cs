using HRPersonnelSystem.Core.BaseEntities;
using HRPersonnelSystem.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.Entities
{
    public class Employee : AppUser,IBaseEntity
    {
        public string FirstName { get; set; }
        public string? MiddleName { get; set; } //ikinci adı
        public string LastName { get; set; }
        public string? SecondLastName { get; set; } //ikinci soyadı
        public string TCNumber { get; set; }
        public Gender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        //public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Job { get; set; }
        public DateTime DateOfHire { get; set; } //işe giriş tarihi
        public DateTime? DateOfTermination { get; set; } //işten çıkış tarihi
        public string Address { get; set; }
        public double Salary { get; set; } //maaş
        //public Guid? ImageId { get; set; }
        //public virtual Image? Image { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Permission> Permissions { get; set; }
        public ICollection<AdvancePayment> AdvancePayments { get; set; }
        public ICollection<Expenditure> Expenditures { get; set; }

        public string? ImagePath { get; set; }
        public Company? Company { get; set; }
        public Guid? CompanyId { get; set; }


        // email ve phone AppUser içerisinden gelicek

        public Employee()
        {
            Permissions = new List<Permission>();
            AdvancePayments = new List<AdvancePayment>();
            Expenditures = new List<Expenditure>();

        }
    }
}
