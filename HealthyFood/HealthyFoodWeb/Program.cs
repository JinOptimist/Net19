using Data.Interface.Repositories;
using HealthyFoodWeb.Services;
using HealthyFoodWeb.Services.FakeDb;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddScoped<IGameService>(
    diContainer => new RecomendateGameService(diContainer.GetService<IGameRepository>()));

builder.Services.AddScoped<IGameRepository>(x => new GameRepositoryFake());

builder.Services.AddScoped<IWikiMCService>(
    diContainer => new WikiMCService(diContainer.GetService<IWikiMCRepository>()));

builder.Services.AddScoped<IWikiMCRepository>(x => new WikiMCRepositoryFake());


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
