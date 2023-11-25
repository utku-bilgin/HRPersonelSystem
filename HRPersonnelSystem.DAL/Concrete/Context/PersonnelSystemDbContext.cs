using HRPersonnelSystem.DAL.Concrete.Context.TypeConfigurations;
using HRPersonnelSystem.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace HRPersonnelSystem.DAL.Concrete.Context
{
    public class PersonnelSystemDbContext : IdentityDbContext<AppUser, AppRole, Guid, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken>
    {
        public virtual DbSet<Employee> Employees{ get; set; }
        public virtual DbSet<CompanyDirector> CompanyDirectors{ get; set; }
        //public virtual DbSet<Image> Images{ get; set; }


        public PersonnelSystemDbContext(DbContextOptions<PersonnelSystemDbContext> options) : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);.
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserClaimTypeConfiguration())
                        .ApplyConfiguration(new UserLoginTypeConfiguration())
                        .ApplyConfiguration(new RoleClaimTypeConfiguration())
                        .ApplyConfiguration(new RoleTypeConfiguration())
                        .ApplyConfiguration(new UserRoleTypeConfiguration())
                        .ApplyConfiguration(new UserTokenTypeConfiguration())
                        .ApplyConfiguration(new UserTypeConfiguration())
                        .ApplyConfiguration(new EmployeeTypeConfiguration())
                        .ApplyConfiguration(new AdvancePaymentTypeConfiguration())
                        .ApplyConfiguration(new ExpenditureTypeConfiguration())
                        .ApplyConfiguration(new CompanyDirectorTypeConfiguration())
                        .ApplyConfiguration(new AdminTypeConfiguration())
                        .ApplyConfiguration(new CompanyTypeConfiguration())
                        .ApplyConfiguration(new PermissionTypeConfiguration());
                        //.ApplyConfiguration(new ImageTypeConfiguration());




            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
