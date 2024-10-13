using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieTicket.BusinessService.LoggerFactory;
using MovieTicket.BusinessService.Services.Implementation;
using MovieTicket.BusinessService.Services.Interface;

namespace MovieTicket.BusinessService
{
    public static class DependencyInjector
    {
        public static void RegisterBusinessServiceDependencies(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped<IMovieService, MovieService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITheatreService, TheatreService>();
            services.AddScoped<ITheatreScreenService, TheatreScreenService>();
            services.AddScoped<IBookingService, BookingService>();

            services.AddScoped<IMovieListingService, MovieListingService>();

            services.AddSingleton<ICustomLoggerFactory, CustomLoggerFactory>();
            services.AddSingleton<ICustomLogger, FileLogger>();   //This is additional step

            services.AddSingleton<IAppSettings, AppSettings>();
        }
    }
}
