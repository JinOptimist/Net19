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


builder.Services.AddScoped<IGameService>(
    diContainer => new GameService(
        diContainer.GetService<IGameRepository>(), 
        diContainer.GetService<IAuthService>(),
        diContainer.GetService<IGameCategoryRepository>(),
        diContainer.GetService<IPagginatorService>(),
        diContainer.GetService<IWebHostEnvironment>()
        ));
builder.Services.AddScoped<IPagginatorService, PagginatorService>();
builder.Services.AddScoped<ICartService>(
    diContainer => new CartService(diContainer.GetService<ICartRepository>(), diContainer.GetService<IAuthService>()));
builder.Services.AddScoped<IUserService>(
    diContainer => new UserService(diContainer.GetService<IUserRepository>()));
builder.Services.AddScoped<IWikiMcService>(
    diContainer => new WikiMCService(diContainer.GetService<IWikiMcRepository>(), 
    diContainer.GetService<IAuthService>(), 
    diContainer.GetService<IWikiTagRepository>(),
	diContainer.GetService<IPagginatorService>()));
builder.Services.AddScoped<IGameCatalogService>(
     diContainer => new GameCatalogService(diContainer.GetService<IGameCategoryRepository>()));
builder.Services.AddScoped<IStoreCatalogueService>(
    diContainer => new StoreCatalogueService(diContainer.GetService<IStoreCatalogueRepository>(), diContainer.GetService<IManufacturerRepository>()));
builder.Services.AddScoped<IAuthService>(
     diContainer => new AuthService(
            diContainer.GetService<IUserService>(), 
            diContainer.GetService<IHttpContextAccessor>()));
builder.Services.AddScoped<IReviewService>(
    diContainer => new ReviewService(diContainer.GetService<IReviewRepository>(), diContainer.GetService<IAuthService>()));
builder.Services.AddScoped<IWikiBAAPageServices>(diContainer => new WikiBAAPageServices(diContainer.GetService<IWikiBaaRepository>(),
    diContainer.GetService<IAuthService>(),
    diContainer.GetService<IWikiBaaCommentRepository>()));

builder.Services.AddScoped<IGameFruitConnectTwoService>(
     diContainer => new GameFruitConnectTwoService(diContainer.GetService<ISimilarGameRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);

var diRegisterationHelper = new DiRegisterationHelper();
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

