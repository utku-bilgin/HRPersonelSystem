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
	public class AdminTypeConfiguration : IEntityTypeConfiguration<Admin>
	{
		public void Configure(EntityTypeBuilder<Admin> builder)
		{
			var admin = new Admin
			{
				Id= Guid.Parse("D6AAB0EB-0052-48BD-A830-37A8E5E67F86"),
				FirstName = "Erden",
				LastName="Timur",
				TCNumber="12345678900",
				Gender = Core.Enums.Gender.Erkek,
				Email="erden.timur@bilgeadam.com",
				BirthDate = Convert.ToDateTime(DateTime.Now.AddYears(-38).ToShortDateString()),
				DateOfHire = Convert.ToDateTime(DateTime.Now.AddDays(-5).ToShortDateString()),
				BirthPlace="Dolmabahçe",
				CompanyName="BilgeAdam",
				Department="Software",
				Job="Admin",
				Address = "Okul yolu sok. Zincertepe Apt. Bostancı / İstanbul",
				Salary=45000,
				IsActive=true,
				UserName = "erden.timur@bilgeadam.com",
				NormalizedUserName = "ERDEN.TIMUR@BILGEADAM.COM",
				NormalizedEmail = "ERDEN.TIMUR@BILGEADAM.COM",
				PhoneNumberConfirmed = true,
				EmailConfirmed = true,
				SecurityStamp = "1",
				ImagePath = "ErdenTimur.jpeg"
			};
			admin.PasswordHash = CreatePasswordHash(admin, "BBbb22**");
			builder.HasData(admin);
		}
		private string CreatePasswordHash(Admin admin, string password)
		{
			var passwordHasher = new PasswordHasher<Admin>();
			return passwordHasher.HashPassword(admin, password);
		}
	}
}
