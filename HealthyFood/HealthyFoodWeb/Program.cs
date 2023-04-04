using Data.Fake.Repositories;
using Data.Interface.Repositories;
using Data.Sql;
using Data.Sql.Repositories;
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
builder.Services.AddScoped<IWikiMCService>(
    diContainer => new WikiMCService(diContainer.GetService<IWikiMcRepository>()));
builder.Services.AddScoped<IGameCatalogService>(
     diContainer => new GameCatalogService(diContainer.GetService<IGameCategoryRepository>()));


builder.Services.AddScoped<IGameFruitConnectTwoService>(
     diContainer => new GameFruitConnectTwoService(diContainer.GetService<ISimilarGameRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);


builder.Services.AddSingleton<IGameRepository>(x => new GameRepositoryFake());
builder.Services.AddSingleton<ICartRepository>(x => new CartRepositoryFake());
//builder.Services.AddSingleton<IUserRepository>(x => new UserRepositoryFake());
builder.Services.AddScoped<IUserRepository>(x => new UserRepository(x.GetService<WebContext>()));
builder.Services.AddScoped<IGameCategoryRepository>(x => new GameCategoryRepository(x.GetService<WebContext>()));
builder.Services.AddScoped<ISimilarGameRepository>(x => new SimilarGameRepository(x.GetService<WebContext>()));
builder.Services.AddSingleton<IUserRepository>(x => new UserRepositoryFake());
builder.Services.AddScoped<IWikiMcRepository>(x => new WikiMCImgRepository(x.GetService<WebContext>()));

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
