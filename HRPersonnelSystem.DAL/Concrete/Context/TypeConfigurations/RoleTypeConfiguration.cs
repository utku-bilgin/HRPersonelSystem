using HRPersonnelSystem.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRPersonnelSystem.DAL.Concrete.Context.TypeConfigurations
{
    public class RoleTypeConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            //builder.HasKey(r => r.Id);

            //builder.HasIndex(r => r.NormalizedName).HasName("RoleNameIndex").IsUnique();

            //builder.ToTable("AspNetRoles");

            //builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();

            //builder.Property(u => u.Name).HasMaxLength(100);
            //builder.Property(u => u.NormalizedName).HasMaxLength(100);

            //builder.HasMany<IdentityUserRole<Guid>>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();


            builder.HasData(
                new AppRole
                {
                    Id = Guid.Parse("CBA7D3C3-51E2-4694-9003-4177B2C43808"),
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
				new AppRole
				{
					Id = Guid.Parse("B452C8E5-2D3C-4806-94B1-AD8E464DDBFE"),
					Name = "CompanyDirector",
					NormalizedName = "COMPANYDIRECTOR",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				},
				new AppRole
				{
					Id = Guid.Parse("2A56646D-1CE3-452C-9AEE-F64CEF46892A"),
					Name = "Admin",
					NormalizedName = "ADMIN",
					ConcurrencyStamp = Guid.NewGuid().ToString()
				});
        }
    }
}
