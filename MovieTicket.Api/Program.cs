using Microsoft.EntityFrameworkCore;
using MovieTicket.BusinessService;
using MovieTicket.DBHelper;
using MovieTicket.DBHelper.DatabaseContext;
using MovieTicket.DBHelper.DatabaseContext.Repo;
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



builder.Services.RegisterBusinessServiceDependencies(builder.Configuration);

//builder.Services.AddDbContext<MovieTicketDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieTicketDb")));
//builder.Services.AddScoped(typeof(IMovieTicketRepository<>), typeof(MovieTicketRepository<>));

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

