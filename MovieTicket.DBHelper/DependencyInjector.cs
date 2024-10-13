using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.DBHelper.DatabaseContext;
using MovieTicket.DBHelper.DatabaseContext.Repo;

namespace MovieTicket.DBHelper
{
    public static class DependencyInjector
    {
        public static void RegisterDbHelperDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddDbContext<MovieTicketDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MovieTicketDb")));

            //services.AddDbContext<MovieTicketDbContext>(options =>
            //    options.UseSqlServer("Data Source=RAJA-LENOVO\\SQLEXPRESS;Initial Catalog=MovieTicket_5; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"));

            //services.AddDbContext<MovieTicketDbContext>(options =>
            //    options.UseSqlServer(Configuration["ConnectionStrings:MovieTicketDb"]));

            services.AddScoped(typeof(IMovieTicketRepository<>), typeof(MovieTicketRepository<>));
            //services.AddSingleton<IDbAppSettings, DbAppSettings>();
        }        
    }
}
