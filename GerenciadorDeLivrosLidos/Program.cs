using GerenciadorDeLivrosLidos.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GerenciadorContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("GerenciadorContext"), builder =>
                        builder.MigrationsAssembly("GerenciadorDeLivrosLidos")));

builder.Services.AddScoped<SeedingService>();

var app = builder.Build();

SeedingService seedingService = new();
seedingService.Seed();

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
