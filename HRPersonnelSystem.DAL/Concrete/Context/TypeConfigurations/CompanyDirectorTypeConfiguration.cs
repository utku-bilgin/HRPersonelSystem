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
    public class CompanyDirectorTypeConfiguration : IEntityTypeConfiguration<CompanyDirector>
    {
        public void Configure(EntityTypeBuilder<CompanyDirector> builder)
        {

            var director = new CompanyDirector
            {
                Id = Guid.Parse("FB944AE2-E89B-4F8E-B17B-B7FE1ECE2EAD"),
                CompanyId = Guid.Parse("0C026BC4-E4D4-44FD-B210-02E7A6A172C9"),
                FirstName = "Gizem",
                LastName = "Altın",
                TCNumber = "12345678911",
                Gender = Core.Enums.Gender.Kadın,
                PhoneNumber = "0522222222",
                Email = "gizem.altin@bilgeadamboost.com",
                BirthDate= Convert.ToDateTime(DateTime.Now.AddYears(-32).ToShortDateString()),
                DateOfHire = Convert.ToDateTime(DateTime.Now.AddDays(-8).ToShortDateString()),
                BirthPlace = "Ankara",
                //CompanyName = "BilgeAdam",
                Department = "Bilişim Teknojileri",
                Job = "Ekip Lideri",
                Address = "Süründere Mah. Orkun Sok. No:55 Kızılay/Ankara",
                Salary = 47000,
                IsActive = true,
                ImagePath = "Gamze.jpg",
                UserName = "gizem.altin@bilgeadamboost.com",
                NormalizedUserName = "GIZEM.ALTIN@BILGEADAMBOOST.COM",
                NormalizedEmail = "GIZEM.ALTIN@BILGEADAMBOOST.COM",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp="1"
            };
            director.PasswordHash = CreatePasswordHash(director, "AAaa11**");

            builder.HasData(director);

            var newDirector = new CompanyDirector
            {
                Id = Guid.Parse("A7A6EA39-8204-4AFE-9253-B44124605F1C"),
                CompanyId = Guid.Parse("4F7F3B0E-0F1B-4C25-9FE8-79DFED7C3602"),
                FirstName = "Şeyma",
                LastName = "Açık",
                TCNumber = "12345678919",
                Gender = Core.Enums.Gender.Kadın,
                PhoneNumber = "0522222200",
                Email = "seyma.acik@bilgeadamboost.com",
                BirthDate = Convert.ToDateTime(DateTime.Now.AddYears(-45).ToShortDateString()),
                DateOfHire = Convert.ToDateTime(DateTime.Now.AddYears(-12).ToShortDateString()),
                BirthPlace = "Hakkari",
                //CompanyName = "BilgeAdam",
                Department = "Bilişim Teknojileri",
                Job = "Ekip Lideri",
                Address = "Pusula Mah. Çıkmaz Sok. No:18 Kızılay/Ankara",
                Salary = 51000,
                IsActive = true,
                ImagePath = "Seyma.jpg",
                UserName = "seyma.acik@bilgeadamboost.com",
                NormalizedUserName = "SEYMA.ACIK@BILGEADAMBOOST.COM",
                NormalizedEmail = "SEYMA.ACIK@BILGEADAMBOOST.COM",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                SecurityStamp = "1"
            };

            newDirector.PasswordHash = CreatePasswordHash(newDirector, "CCcc33**");

            builder.HasData(newDirector);

        }
        private string CreatePasswordHash(CompanyDirector companyDirector, string password)
        {
            var passwordHasher = new PasswordHasher<CompanyDirector>();
            return passwordHasher.HashPassword(companyDirector, password);
        }
    }
}
