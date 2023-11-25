using HRPersonnelSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.DAL.Concrete.Context.TypeConfigurations
{
    public class EmployeeTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            //builder.HasKey(x => x.Id);
            //builder.Property(x => x.Id).UseIdentityColumn();
            //eğer yemezse random guid olmalı bi yerde(new.Guid

            //builder.Property(x => x.FirstName).IsRequired().HasMaxLength(40);
            //builder.Property(x => x.LastName).IsRequired().HasMaxLength(40);
            //builder.Property(x => x.MiddleName).HasMaxLength(40);
            //builder.Property(x => x.SecondLastName).HasMaxLength(40);
            //builder.Property(x => x.TCNumber).IsRequired().HasMaxLength(11);
            //builder.Property(x => x.BirthDate).IsRequired();
            //builder.Property(x => x.DateOfHire).IsRequired();
            //builder.Property(x => x.BirthPlace).IsRequired().HasMaxLength(70);
            //builder.Property(x => x.CompanyName).IsRequired().HasMaxLength(100);
            //builder.Property(x => x.Department).IsRequired().HasMaxLength(30);
            //builder.Property(x => x.Job).IsRequired().HasMaxLength(30);
            //builder.Property(x => x.Address).IsRequired().HasMaxLength(100);
            //builder.Property(x => x.Salary).IsRequired().HasMaxLength(8);
            //builder.Property(x => x.IsActive).IsRequired();
            //builder.Property(x => x.Email).IsRequired();
            //builder.Property(x => x.PhoneNumber).IsRequired();
            //builder.HasIndex(x => x.TCNumber).IsUnique();
            //builder.HasIndex(x => x.PhoneNumber).IsUnique();
            //builder.HasIndex(x => x.Email).IsUnique();



            var employee = new Employee
            {
                Id = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                CompanyId = Guid.Parse("0C026BC4-E4D4-44FD-B210-02E7A6A172C9"),
                FirstName = "Burak",
                LastName = "Pekmez",
                TCNumber = "12345678910",
                Gender = Core.Enums.Gender.Erkek,
                PhoneNumber = "055555555",
                Email = "burak.pekmez@bilgeadamboost.com",
                //ImageId = Guid.Parse("20D926F4-CBCF-4148-BF41-BCE757DD8B9A"),
                BirthDate = Convert.ToDateTime(DateTime.Now.AddYears(-25).ToShortDateString()),
                DateOfHire = Convert.ToDateTime(DateTime.Now.AddDays(-10).ToShortDateString()),
                BirthPlace = "Bakırköy",
                //CompanyName = "BilgeAdam",
                Department = "Software",
                Job = "Developer",
                Address = " BilgeAdam Kadıköy. Adres. Caferağa Mah. Mühürdar Cad. No:76 Kadıköy / İSTANBUL​",
                Salary = 23000,
                IsActive = true,
                ImagePath = "Burak.jpg",
                UserName = "burak.pekmez@bilgeadamboost.com",
                NormalizedUserName = "BURAK.PEKMEZ@BILGEADAMBOOST.COM",
                NormalizedEmail = "BURAK.PEKMEZ@BILGEADAMBOOST.COM",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
               
                SecurityStamp = "1"
            };
            employee.PasswordHash = CreatePasswordHash(employee, "1234As.");


            builder.HasData(employee);


            var newEmployee = new Employee
            {
                Id = Guid.Parse("B7ACC710-C1B9-4AE4-9A6B-EFDA8160CF4F"),
                CompanyId= Guid.Parse("0C026BC4-E4D4-44FD-B210-02E7A6A172C9"),
                FirstName = "Hande",
                LastName = "Pekmez",
                TCNumber = "92345678910",
                Gender = Core.Enums.Gender.Kadın,
                PhoneNumber = "05001905222",
                Email = "hande.pekmez@bilgeadamboost.com",
                //ImageId = Guid.Parse("20D926F4-CBCF-4148-BF41-BCE757DD8B9A"),
                BirthDate = Convert.ToDateTime(DateTime.Now.AddYears(-26).ToShortDateString()),
                DateOfHire = Convert.ToDateTime(DateTime.Now.AddYears(-2).ToShortDateString()),
                BirthPlace = "Tuzla",
                //CompanyName = "BilgeAdam",
                Department = "Software",
                Job = "Developer",
                Address = " BilgeAdam Kadıköy. Adres. Caferağa Mah. Mühürdar Cad. No:76 Kadıköy / İSTANBUL​",
                Salary = 32000,
                IsActive = true,
                ImagePath = "Hande.jpg",
                UserName = "hande.pekmez@bilgeadamboost.com",
                NormalizedUserName = "HANDE.PEKMEZ@BILGEADAMBOOST.COM",
                NormalizedEmail = "HANDE.PEKMEZ@BILGEADAMBOOST.COM",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,

                SecurityStamp = "1"
            };
            newEmployee.PasswordHash = CreatePasswordHash(newEmployee, "1234Hp.");


            builder.HasData(newEmployee);


            var newEmployee1 = new Employee
            {
                Id = Guid.Parse("0575FC0A-FB5C-42C3-AE76-8CD847642EF3"),
                CompanyId = Guid.Parse("4F7F3B0E-0F1B-4C25-9FE8-79DFED7C3602"),
                FirstName = "Sinem",
                LastName = "Ünal",
                TCNumber = "92345678919",
                Gender = Core.Enums.Gender.Kadın,
                PhoneNumber = "05001905122",
                Email = "sinem.unal@bilgeadamboost.com",
                //ImageId = Guid.Parse("20D926F4-CBCF-4148-BF41-BCE757DD8B9A"),
                BirthDate = Convert.ToDateTime(DateTime.Now.AddYears(-29).ToShortDateString()),
                DateOfHire = Convert.ToDateTime(DateTime.Now.AddYears(-4).ToShortDateString()),
                BirthPlace = "İzmir",
                //CompanyName = "BilgeAdam",
                Department = "Software",
                Job = "Developer",
                Address = " BilgeAdam Kadıköy. Adres. Caferağa Mah. Mühürdar Cad. No:76 Kadıköy / İSTANBUL​",
                Salary = 37000,
                IsActive = true,
                ImagePath = "Sinem.jpg",
                UserName = "sinem.unal@bilgeadamboost.com",
                NormalizedUserName = "SINEM.UNAL@BILGEADAMBOOST.COM",
                NormalizedEmail = "SINEM.UNAL@BILGEADAMBOOST.COM",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,

                SecurityStamp = "1"
            };
            newEmployee1.PasswordHash = CreatePasswordHash(newEmployee1, "1234Su.");


            builder.HasData(newEmployee1);
        }

        private string CreatePasswordHash(Employee employee, string password)
        {
            var passwordHasher = new PasswordHasher<Employee>();
            return passwordHasher.HashPassword(employee, password);
        }
    }
}
