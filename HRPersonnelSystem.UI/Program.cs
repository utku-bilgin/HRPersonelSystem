using HRPersonnelSystem.UI.Areas.Employee.ImageHelpers;
using Microsoft.AspNetCore.CookiePolicy;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ImageHelper>();

builder.Services.AddHttpClient();


builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.None;
    options.HttpOnly = HttpOnlyPolicy.None;
    options.Secure = CookieSecurePolicy.Always; // Çerezlerin yalnýzca HTTPS üzerinden iletilmesini saðlar
});

builder.Services.AddDistributedMemoryCache(); // Oturum verilerini bellekte saklamak için önbellek hizmetini ekler
builder.Services.AddSession();

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	//app.UseExceptionHandler("/Home/Error");
	//// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	//app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "EmployeeArea",
        pattern: "{area:exists}/{controller=Employee}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute
       (
           name: "Employee",
           areaName: "Employee",
           pattern: "Employee/{Controller=Employee}/{action=Index}/{id?}"
       );

    endpoints.MapAreaControllerRoute
       (
           name: "CompanyDirector",
           areaName: "CompanyDirector",
           pattern: "CompanyDirector/{Controller=CompanyDirector}/{action=Index}/{id?}"
       );

    endpoints.MapAreaControllerRoute
       (
           name: "Admin",
           areaName: "Admin",
           pattern: "Admin/{Controller=Admin}/{action=Index}/{id?}"
       );

    //endpoints.MapAreaControllerRoute
    //   (
    //       name: "EmployeeAll",
    //       areaName: "CompanyDirector",
    //       pattern: "CompanyDirector/{Controller=EmployeeAll}/{action=Index}/{id?}"
    //   );


    endpoints.MapControllerRoute
    (
        name: "default", pattern: "{controller=Auth}/{action=Login}/{id?}"
    );

    endpoints.MapDefaultControllerRoute();
});

app.Run();
