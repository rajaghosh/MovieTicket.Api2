using MovieTicket.BusinessService;
using MovieTicket.DBHelper;
using MovieTicketApi.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region FOR LOGGER FACTORY
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
#endregion

builder.Services.AddControllers();

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddDbContext<MovieTicketDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieTicketDb")));

//builder.Services.AddTransient(typeof(IMovieTicketRepository<>), typeof(MovieTicketRepository<>));
//builder.Services.AddScoped<IAuthService, AuthService>();

//builder.Services.AddScoped<IMovieService, MovieService>();
//builder.Services.AddScoped<IUserService, UserService>();
//builder.Services.AddScoped<ITheatreService, TheatreService>();
//builder.Services.AddScoped<ITheatreScreenService, TheatreScreenService>();
//builder.Services.AddScoped<IBookingService, BookingService>();

//builder.Services.AddScoped<IMovieListingService, MovieListingService>();

//builder.Services.AddSingleton<ICustomLoggerFactory, CustomLoggerFactory>();
//builder.Services.AddSingleton<ICustomLogger, FileLogger>();   //This is additional step

//builder.Services.AddSingleton<IAppSettings, AppSettings>();

builder.Services.RegisterBusinessServiceDependencies(builder.Configuration);
builder.Services.RegisterDbHelperDependencies(builder.Configuration);

builder.Services.AddSwaggerGen();

builder.Services.GetToken(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthentication();
app.UseAuthorization();

app.UseMiddleware<RequestHeaderMiddleware>();

app.MapControllers();

app.Run();

