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
    public class ImageTypeConfiguration : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.Employee)
            //       .WithOne(x => x.Image);

			//builder.HasOne(x => x.Expenditure)
			//	   .WithOne(x => x.Image);

			//builder.HasOne(x => x.AdvancePayment)
			//	   .WithOne(x => x.Image);

			builder.HasData(new Image
            {
                Id= Guid.Parse("20D926F4-CBCF-4148-BF41-BCE757DD8B9A"),
                FileName = "images/indir",
                FileType = "jpg",
                CreatedDate = DateTime.Now,
                IsDeleted = false,
                ImagePath= "uplads/imageapi.png"
            });

        }
    }
}
