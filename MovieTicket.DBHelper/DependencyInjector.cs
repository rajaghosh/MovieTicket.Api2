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

            services.AddScoped(typeof(IMovieTicketRepository<>), typeof(MovieTicketRepository<>));
        }        
    }
}
