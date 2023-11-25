using FluentValidation;
using HRPersonnelSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.BLL.FluentValidations
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(3)
                   .MaximumLength(40)
                   .WithName("Ad");

            RuleFor(x => x.MiddleName)
                  .MinimumLength(3)
                  .MaximumLength(40)
                  .WithName("İkinci Ad");

            RuleFor(x => x.LastName)
                  .NotEmpty()
                  .NotNull()
                  .MinimumLength(3)
                  .MaximumLength(40)
                  .WithName("Soyad");

            RuleFor(x => x.SecondLastName)
                  .MinimumLength(3)
                  .MaximumLength(40)
                  .WithName("İkinci Soyad");

            RuleFor(x => x.TCNumber)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(11)
                   .WithName("TC No");

            RuleFor(x => x.BirthDate)
                   .NotEmpty()
                   .NotNull()
                   .WithName("Doğum Tarihi");

            RuleFor(x => x.BirthPlace)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(3)
                   .MaximumLength(70)
                   .WithName("Doğum Yeri");

            //RuleFor(x => x.CompanyName)
            //       .NotEmpty()
            //       .NotNull()
            //       .MinimumLength(2)
            //       .MaximumLength(100)
            //       .WithName("Şirket Adı"); 

            RuleFor(x => x.Department)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(2)
                   .MaximumLength(30)
                   .WithName("Bölüm");

            RuleFor(x => x.Job)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(2)
                   .MaximumLength(30)
                   .WithName("Meslek");

            RuleFor(x => x.DateOfHire)
                   .NotEmpty()
                   .NotNull()
                   .WithName("İşe Giriş Tarihi");

            RuleFor(x => x.DateOfTermination)
                  .Null()
                  .WithName("İşe Çıkış Tarihi");

            RuleFor(x => x.Address)
                   .NotEmpty()
                   .NotNull()
                   .MinimumLength(2)
                   .MaximumLength(100)
                   .WithName("Adres");

            RuleFor(x => x.Salary)
                   .NotEmpty()
                   .NotNull()
                   .GreaterThanOrEqualTo(11500)
                   .WithName("Maaş");

            RuleFor(x => x.IsActive)
                   .NotEmpty()
                   .NotNull()
                   .WithName("Aktif mi?");

            RuleFor(x => x.Email)
                   .NotEmpty()
                   .NotNull();

            RuleFor(x => x.PhoneNumber)
                   .NotEmpty()
                   .NotNull()
                   .WithName("Telefon Numarası");

        }
    }
}
