using FluentValidation.AspNetCore;
using HRPersonnelSystem.BLL.Abstract.IServices;
using HRPersonnelSystem.BLL.Concrete.Services;
using HRPersonnelSystem.BLL.FluentValidations;
//using HRPersonnelSystem.BLL.ImageHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;
using System.Reflection;

namespace HRPersonnelSystem.BLL.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtension(this IServiceCollection services)
        {
            var assembly=Assembly.GetExecutingAssembly();


            services.AddScoped<IEmployeeService, EmployeeService>();
            //services.AddScoped<IImageHelper, ImageHelper>();
            services.AddScoped<IExpenditureService, ExpenditureService>();
            services.AddScoped<IPermissionService, PermissionService>();
            services.AddScoped<ICompanyDirectorService, CompanyDirectorService>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<IUserRole ,UserRoleService>();
            services.AddScoped<IPasswordResetService, PasswordResetService>();

            services.AddScoped<IAdvancePaymentService, AdvancePaymentService>();
            //services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICompanyDirectorForEmployeeListService, CompanyDirectorForEmployeeListService>();
            services.AddScoped<IAdminForCompanyListService, AdminForCompanyListService>();
            services.AddScoped<IAdminForCompanyDirectorListService, AdminForCompanyDirectorListService>();

			services.AddAutoMapper(assembly);


            services.AddControllersWithViews()
               .AddFluentValidation(opt =>
               {
                   opt.RegisterValidatorsFromAssemblyContaining<EmployeeValidator>();
                   opt.DisableDataAnnotationsValidation = true;
                   opt.ValidatorOptions.LanguageManager.Culture = new CultureInfo("tr");
               });

            return services;

        }
    }
}
