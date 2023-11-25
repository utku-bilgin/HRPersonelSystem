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
	public class PermissionTypeConfiguration : IEntityTypeConfiguration<Permission>
	{
		public void Configure(EntityTypeBuilder<Permission> builder)
		{
            builder.HasOne<Employee>(x => x.Employee)
     .WithMany(x => x.Permissions)
     .HasForeignKey(x => x.EmployeeId)
     .OnDelete(DeleteBehavior.NoAction);



            builder.Property(x => x.PermissionType).HasConversion(new EnumToStringConverter<PermissionType>());
            builder.Property(x => x.ApprovalStatus).HasConversion(new EnumToStringConverter<ApprovalStatus>());
            //builder.Property(x => x.Gender).HasConversion(new EnumToStringConverter<ApprovalStatus>());



            builder.HasData(
                new Permission
                {
                    Id = Guid.Parse("305EF3C8-FC05-46B2-B054-C49AD270BE26"),
                    PermissionType = Core.Enums.PermissionType.Askerlik,
                    StartDate = DateTime.Now.AddDays(20),
                    RequestDate = DateTime.Now,
                    CountOfDay = 21,
                    ApprovalStatus = Core.Enums.ApprovalStatus.Bekleyen,
                    EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                    IsActive = true,
                    Gender = Gender.Erkek
                },



                new Permission
                {
                    Id = Guid.Parse("230AE8D2-BE96-40BF-8639-566DE6BA3A73"),
                    PermissionType = Core.Enums.PermissionType.Babalık,
                    StartDate = DateTime.Now.AddDays(100),
                    RequestDate = DateTime.Now.AddDays(90),
                    CountOfDay = 5,
                    ApprovalStatus = Core.Enums.ApprovalStatus.Bekleyen,
                    EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                    IsActive = true,
                    Gender = Gender.Erkek
                },



                new Permission
                {
                    Id = Guid.Parse("7FE8E741-7E57-41EA-AE05-1697B1C18F77"),
                    PermissionType = Core.Enums.PermissionType.Hastalık,
                    StartDate = DateTime.Now,
                    RequestDate = DateTime.Now,
                    CountOfDay = 3,
                    ApprovalStatus = Core.Enums.ApprovalStatus.Onaylandı,
                    EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                    IsActive = true,
                    Gender = Gender.Erkek
                },



                new Permission
                {
                    Id = Guid.Parse("702DABB3-D6D4-4EC0-A6F1-AE329C81B649"),
                    PermissionType = Core.Enums.PermissionType.Evlilik,
                    StartDate = DateTime.Now.AddDays(325),
                    RequestDate = DateTime.Now.AddDays(300),
                    CountOfDay = 3,
                    ApprovalStatus = Core.Enums.ApprovalStatus.Onaylandı,
                    EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                    IsActive = true,
                    Gender = Gender.Erkek
                },



                new Permission
                {
                    Id = Guid.Parse("38B5F216-C008-4E81-9CAC-337F8AD7E283"),
                    PermissionType = Core.Enums.PermissionType.Yıllık,
                    StartDate = DateTime.Now.AddDays(275),
                    RequestDate = DateTime.Now.AddDays(270),
                    CountOfDay = 5,
                    ApprovalStatus = Core.Enums.ApprovalStatus.Reddedildi,
                    EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                    IsActive = true,
                    Gender = Gender.Erkek
                },



                new Permission
                {
                    Id = Guid.Parse("736B4A73-D1E5-4C87-80B7-8584824B4E57"),
                    PermissionType = Core.Enums.PermissionType.Refakat,
                    StartDate = DateTime.Now.AddDays(200),
                    RequestDate = DateTime.Now.AddDays(198),
                    CountOfDay = 10,
                    ApprovalStatus = Core.Enums.ApprovalStatus.Reddedildi,
                    EmployeeId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"),
                    IsActive = true,
                    Gender = Gender.Erkek
                });
        }
	}
}
