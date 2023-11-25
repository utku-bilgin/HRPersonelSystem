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
    public class UserRoleTypeConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            //builder.HasKey(r => new { r.UserId, r.RoleId });

            // Maps to the AspNetUserRoles table
            //builder.ToTable("AspNetUserRoles");

            builder.HasData(
                new AppUserRole { UserId = Guid.Parse("7DB5918A-64B7-4D74-8D16-BB52FA969631"), RoleId = Guid.Parse("CBA7D3C3-51E2-4694-9003-4177B2C43808")}, 
                new AppUserRole { UserId = Guid.Parse("FB944AE2-E89B-4F8E-B17B-B7FE1ECE2EAD"), RoleId = Guid.Parse("B452C8E5-2D3C-4806-94B1-AD8E464DDBFE")}, 
                new AppUserRole { UserId = Guid.Parse("D6AAB0EB-0052-48BD-A830-37A8E5E67F86"), RoleId = Guid.Parse("2A56646D-1CE3-452C-9AEE-F64CEF46892A") },
                new AppUserRole { UserId = Guid.Parse("B7ACC710-C1B9-4AE4-9A6B-EFDA8160CF4F"), RoleId = Guid.Parse("CBA7D3C3-51E2-4694-9003-4177B2C43808") },
                new AppUserRole { UserId = Guid.Parse("0575FC0A-FB5C-42C3-AE76-8CD847642EF3"), RoleId = Guid.Parse("CBA7D3C3-51E2-4694-9003-4177B2C43808") },
                new AppUserRole { UserId = Guid.Parse("A7A6EA39-8204-4AFE-9253-B44124605F1C"), RoleId = Guid.Parse("B452C8E5-2D3C-4806-94B1-AD8E464DDBFE") }
                );
        }
    }
}
