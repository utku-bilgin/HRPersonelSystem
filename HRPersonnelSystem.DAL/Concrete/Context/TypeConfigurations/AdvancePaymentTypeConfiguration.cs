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
	public class AdvancePaymentTypeConfiguration : IEntityTypeConfiguration<AdvancePayment>
	{
		public void Configure(EntityTypeBuilder<AdvancePayment> builder)
		{
            builder.Property(x => x.AdvancePaymentType).HasConversion(new EnumToStringConverter<AdvancePaymentType>());

            builder.HasData(new AdvancePayment
			{
				Id= Guid.Parse("F8BD10CE-80D7-4211-9893-A943CB333338"),
				AdvancePaymentType = Core.Enums.AdvancePaymentType.Bireysel,
				Amount = 5000,
				CurrencyUnit = Core.Enums.CurrencyUnit.TL,
				RequestDate =Convert.ToDateTime(DateTime.Now.AddDays(-1).ToShortDateString()),
				ApprovalStatus = Core.Enums.ApprovalStatus.Bekleyen,
				Explain = "",
				EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631")

			});
		}
	}
}
