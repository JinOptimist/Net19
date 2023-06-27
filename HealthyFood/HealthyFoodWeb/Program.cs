using Data.Interface.Repositories;
using Data.Sql;
using Data.Sql.Repositories;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.WikiServices;
using HealthyFoodWeb.Services.IServices;
using Microsoft.Extensions.DependencyInjection;
using HealthyFoodWeb.Utility;
using HealthyFoodWeb.Services.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services
    .AddAuthentication(AuthService.AUTH_NAME)
    .AddCookie(AuthService.AUTH_NAME, x=>
    {
        x.LoginPath = "/User/Login";
        x.AccessDeniedPath = "/User/AccessDenied";
    });

var diRegisterationHelper = new DiRegisterationHelper();
diRegisterationHelper.RegisterAllServices(builder.Services);

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);

diRegisterationHelper.RegisterAllRepositories(builder.Services);
diRegisterationHelper.RegisterAllServices(builder.Services);

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.Seed();
//SeedData.Seed(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Кто я?
app.UseAuthorization(); // Можно ли сюда?

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{name?}");

app.Run();

