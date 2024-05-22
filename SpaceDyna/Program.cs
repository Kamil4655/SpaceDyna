using Microsoft.EntityFrameworkCore;
using SpaceDyna.DAL;

namespace SpaceDyna
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

      
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<SpaceDynaContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));

            });
            var app = builder.Build();

          
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.MapControllerRoute(name: "areas",pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
            app.MapControllerRoute( name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
