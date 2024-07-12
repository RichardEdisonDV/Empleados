using Application;
using Application.Statics.Configurations;
//using EmpleadosAPI.Extensions;
//using EmpleadosAPI.Tools;
using Infrastructure;
//using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddControllersWithViews();

// Agregar el servicio de sesi�n
builder.Services.AddSession(options =>
{
    // Configura las opciones de sesi�n aqu� si es necesario
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tiempo de expiraci�n de la sesi�n
    options.Cookie.HttpOnly = true; // Previene el acceso a la cookie de sesi�n a trav�s de JavaScript
    options.Cookie.IsEssential = true; // Marca la cookie de sesi�n como esencial
});

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

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
