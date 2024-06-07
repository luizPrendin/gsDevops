using GS.Data;
using Microsoft.EntityFrameworkCore;
using GS.Models;
using GS.Persistencia.Interfaces;
using GS.Persistencia.Repositorios;

namespace Sprint2___
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Configurar as URLs em que o aplicativo deve ouvir
            builder.WebHost.UseUrls("http://*:8080", "http://*:80");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Configurar o DbContext para usar o Oracle
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseOracle(builder.Configuration.GetConnectionString("OracleConnection"));
            });

            // Configurar injeção de dependência para os repositórios
            builder.Services.AddScoped<IRepositorio<Usuario>, Repositorio<Usuario>>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
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
