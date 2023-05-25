using Domain.Interface;
using Domain.Services;
using Infrastructure.Identity.Data;
using Infrastructure.Interface;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RinkuApp.Data;

namespace RinkuApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddScoped<IConnectionProvider, ConnectionProvider>();

            builder.Services.AddScoped<IDeduccionRepository, DeduccionRepository>();
            builder.Services.AddScoped<IDepartametoRepository, DepartametoRepository>();
            builder.Services.AddScoped<IEmpleadosRepository, EmpleadosRepository>();
            builder.Services.AddScoped<IPermisosRepository, PermisosRepository>();
            builder.Services.AddScoped<IRolRepository, RolRepository>();
            builder.Services.AddScoped<ISalarioRepository, SalarioRepository>();

            builder.Services.AddScoped<IDeduccionService, DeduccionService>();
            builder.Services.AddScoped<IDepartametoService, DepartametoService>();
            builder.Services.AddScoped<IEmpleadosService, EmpleadosService>();
            builder.Services.AddScoped<IPermisosService, PermisosService>();
            builder.Services.AddScoped<IRolService, RolService>();
            builder.Services.AddScoped<ISalarioService, SalarioService>();

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<RinkuAppContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<RinkuAppContext>();
            builder.Services.AddRazorPages();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapRazorPages();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                  name: "areas",
                  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
            });
            app.Run();
        }
    }
}