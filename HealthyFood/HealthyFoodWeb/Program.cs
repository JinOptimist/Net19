using Data.Fake.Repositories;
using Data.Interface.Repositories;
using Data.Sql;
using Data.Sql.Repositories;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.WikiServices;
using HealthyFoodWeb.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IWikiBAAIPageRecomendateServices>(x => new WikiBAAPageRecomendateServices(x.GetService<WikiRepositoryBAA>()));
builder.Services.AddSingleton<WikiRepositoryBAA>(x => new WikiRepositoryBAA());


builder.Services.AddScoped<IGameService>(
    diContainer => new RecomendateGameService(diContainer.GetService<IGameRepository>()));
builder.Services.AddScoped<ICartService>(
    diContainer => new CartService(diContainer.GetService<ICartRepository>()));
builder.Services.AddScoped<IUserService>(
    diContainer => new UserService(diContainer.GetService<IUserRepository>()));

var dataSqlStartup = new Startup();
dataSqlStartup.RegisterDbContext(builder.Services);


builder.Services.AddSingleton<IGameRepository>(x => new GameRepositoryFake());
builder.Services.AddSingleton<ICartRepository>(x => new CartRepositoryFake());
//builder.Services.AddSingleton<IUserRepository>(x => new UserRepositoryFake());
builder.Services.AddScoped<IUserRepository>(x => new UserRepository(x.GetService<WebContext>()));


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
