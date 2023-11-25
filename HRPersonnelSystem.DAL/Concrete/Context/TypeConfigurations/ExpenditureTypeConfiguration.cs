using HRPersonnelSystem.Core.Enums;
using HRPersonnelSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRPersonnelSystem.DAL.Concrete.Context.TypeConfigurations
{
	public class ExpenditureTypeConfiguration : IEntityTypeConfiguration<Expenditure>
	{
		public void Configure(EntityTypeBuilder<Expenditure> builder)
		{
            builder.Property(x => x.ExpenditureType).HasConversion(new EnumToStringConverter<ExpenditureType>());
            builder.Property(x => x.CurrencyUnit).HasConversion(new EnumToStringConverter<CurrencyUnit>());
            builder.Property(x => x.ApprovalStatus).HasConversion(new EnumToStringConverter<ApprovalStatus>());

            builder.HasData(new Expenditure
			{
				Id = Guid.Parse("3397BFF8-1261-4603-8965-9D596246E4B8"),
				ExpenditureType = Core.Enums.ExpenditureType.Seyahat,
				Amount = 800,
				CurrencyUnit = Core.Enums.CurrencyUnit.TL,
				RequestDate = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()),
				ApprovalStatus = Core.Enums.ApprovalStatus.Bekleyen,
				EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
				//ImageId = Guid.Parse("20D926F4-CBCF-4148-BF41-BCE757DD8B9A")
            },
			new Expenditure
			{
				Id= Guid.Parse("2FFBE4D4-C782-4A19-BD89-0A8624BED3EE"),
				ExpenditureType = Core.Enums.ExpenditureType.Konaklama,
				Amount = 500,
				CurrencyUnit = Core.Enums.CurrencyUnit.TL,
				RequestDate = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()),
                ApprovalStatus = Core.Enums.ApprovalStatus.Reddedildi,
				EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631")
			});
		}
	}
}
