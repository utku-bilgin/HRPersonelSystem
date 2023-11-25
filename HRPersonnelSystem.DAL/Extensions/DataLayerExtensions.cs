using HRPersonnelSystem.DAL.Concrete.Context;
using HRPersonnelSystem.DAL.Repositories.Abstractions;
using HRPersonnelSystem.DAL.Repositories.Concretes;
using HRPersonnelSystem.DAL.UnitOfWorks;
using HRPersonnelSystem.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRPersonnelSystem.DAL.Extensions
{
    public static class DataLayerExtensions
    {
        public static IServiceCollection LoadDataLayerExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonnelSystemDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("ManagementSystemDB")));

            services.AddIdentityCore<AppUser>()
                    .AddRoles<AppRole>()
                    .AddEntityFrameworkStores<PersonnelSystemDbContext>();


            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUnitOfWork,UnitOfWork>();

            return services;
        }
    }
}
