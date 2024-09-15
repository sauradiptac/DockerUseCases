using DataAccess.Data.Repository.IRepository;
using DataAccess.Data.Repository;
using DataAccess;
using Microsoft.EntityFrameworkCore;

namespace TwoWebTwoDbTwoNetworks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            string connStr = builder.Configuration.GetConnectionString("MySQLConnStr");

            #region MSSQL Database
            //builder.Services.AddDbContext<ApplicationDBContext>(options =>
            //{
            //    options.UseSqlServer(connStr);
            //});
            #endregion

            #region MySQL Database
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
            {
                options.UseMySql(connStr, ServerVersion.AutoDetect(connStr));
            });
            #endregion

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

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