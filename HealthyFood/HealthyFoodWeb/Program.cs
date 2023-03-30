using Data.Fake.Repositories;
using Data.Interface.Repositories;
using Data.Sql;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSingleton<IGameService>(
    diContainer => new RecomendateGameService(diContainer.GetService<IGameRepository>()));
builder.Services.AddSingleton<ICartService>(
    diContainer => new CartService(diContainer.GetService<ICartRepository>()));
builder.Services.AddSingleton<IUserService>(
    diContainer => new UserService(diContainer.GetService<IUserRepository>()));
builder.Services.AddSingleton<IGameCatalogService>(
     diContainer => new GameCatalogService(diContainer.GetService<ICatalogRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);


builder.Services.AddSingleton<IGameRepository>(x => new GameRepositoryFake());
builder.Services.AddSingleton<ICartRepository>(x => new CartRepositoryFake());
builder.Services.AddSingleton<IUserRepository>(x => new UserRepositoryFake());
builder.Services.AddSingleton<ICatalogRepository>(x => new CatalogRepositoryFake());
var app = builder.Build();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
