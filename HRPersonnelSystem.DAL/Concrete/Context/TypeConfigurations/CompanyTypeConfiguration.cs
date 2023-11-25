using HRPersonnelSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.DAL.Concrete.Context.TypeConfigurations
{
	public class CompanyTypeConfiguration : IEntityTypeConfiguration<Company>
	{
		public void Configure(EntityTypeBuilder<Company> builder)
		{
			builder.HasData(new Company
			{
				Id= Guid.Parse("0C026BC4-E4D4-44FD-B210-02E7A6A172C9"),
				CompanyName = "BilgeAdam Teknoloji",
				CompanyTitle = "LTD.ŞTI.",
				MersisNumber = "0470000911900015",
				TaxNumber = "4700009119",
				TaxOffice = "Aksaray V.D",
				Email = "info@bilgeadam.com",
				Phone = "0212 473 88 88",
				Address = "Küçükyali merkez mh. oniki sk. No : 14 Ayazağa Plaza. Sarıyer / Istanbul",
				ImagePath = "indir.png",
				NumberOfEmployees = 88,
				IsActive = true,
				YearOfEstablishment = DateTime.Now.AddYears(-25),
				ContractStartDate = DateTime.Now.AddMonths(-8),
				ContractEndDate = DateTime.Now.AddYears(2),
				CreatedBy="Admin"
				
			},

            new Company
            {
                Id = Guid.Parse("4F7F3B0E-0F1B-4C25-9FE8-79DFED7C3602"),
                CompanyName = "Dijital Teknoloji",
                CompanyTitle = "LTD.ŞTI.",
                MersisNumber = "0490000911900015",
                TaxNumber = "4900009119",
                TaxOffice = "Aksaray V.D",
                Email = "info@dijitalteknoloji.com",
                Phone = "0212 473 99 99",
                Address = "Büyükyali merkez mh. onbir sk. No : 20 Saat Plaza. Çekmeköy / Istanbul",
                ImagePath = "Dijital.jpg",
                NumberOfEmployees = 20,
                IsActive = true,
                YearOfEstablishment = DateTime.Now.AddYears(-5),
                ContractStartDate = DateTime.Now.AddMonths(-1),
                ContractEndDate = DateTime.Now.AddYears(1),
                CreatedBy = "Admin"
            }
            );
		}
	}
}
