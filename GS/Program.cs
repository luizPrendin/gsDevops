using GS.Data;
using Microsoft.EntityFrameworkCore;
using GS.Models;
using System.Configuration;
using GS.Persistencia.Interfaces;
using GS.Persistencia.Repositorios;

namespace Sprint2___
{

    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the caixa.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
            });

            builder.Services.AddScoped<IRepositorio<Usuario>, Repositorio<Usuario>>();

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
        }
    }
}