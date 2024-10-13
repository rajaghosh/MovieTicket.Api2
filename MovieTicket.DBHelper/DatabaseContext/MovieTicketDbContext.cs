using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MovieTicket.DBHelper.DatabaseContext.ConfigHelper;
using MovieTicket.DBHelper.Entities;

using Microsoft.EntityFrameworkCore.Design;

using System.IO;
using System.Text.Json;
using System;
using MovieTicket.ModelHelper.Models;

namespace MovieTicket.DBHelper.DatabaseContext
{
    public class MovieTicketDbContext : DbContext
    {
        //private readonly IDbAppSettings _dbAppSettings;
        //private readonly string _connStr;
        //public MovieTicketDbContext(IDbAppSettings dbAppSettings)
        //{
        //    _dbAppSettings = dbAppSettings;
        //    _connStr = _dbAppSettings._connStr;
        //}


        //public IConfiguration Configuration { get; }
        //private readonly string _connStr;
        //public MovieTicketDbContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    _connStr = Configuration.GetConnectionString("ConnectionStrings:MovieTicketDb");
        //}

        public DbSet<MovieMaster> MovieMasters { get; set; }
        public DbSet<TheatreMaster> TheatreMasters { get; set; }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<TheatreScreen> TheatreScreens { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<MovieListing> MovieListings { get; set; }

        public MovieTicketDbContext() { }
        public MovieTicketDbContext(DbContextOptions<MovieTicketDbContext> options) : base(options) { }

        //This is optional. FOR MIGRATION FILE CREATION ONLY. We have used it as we are unable to create the migration file directly 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=RAJA-LENOVO\\SQLEXPRESS;Initial Catalog=MovieTicket_5; Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"); // Replace with your connection string and provider

            //"ConnectionStrings": {
            //    "MovieTicketDb":

            //optionsBuilder.UseSqlServer(_connStr);

            //string jsonFilePath = "../Settings.json";
            string jsonFilePath = "..\\MovieTicket.Api\\appsettings.json";
            //string jsonString = File.ReadAllText(jsonFilePath);
            //DBConnModel conn = JsonSerializer.Deserialize<DBConnModel>(jsonString);

            string jsonString = File.ReadAllText(jsonFilePath);

            string conn = "";
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;
                JsonElement appSettings = root.GetProperty("ConnectionStrings");

                conn = appSettings.GetProperty("MovieTicketDb").GetString();

            }

            optionsBuilder.UseSqlServer(conn);

            base.OnConfiguring(optionsBuilder);

            //IConfigurationRoot configuration = new ConfigurationBuilder().dire
            //.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            //.AddJsonFile("appsettings.json")
            //.Build();
            //optionsBuilder.UseSqlServer(configuration.GetConnectionString("MovieTicketDb"));

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DbContextOptionsBuilder).Assembly);
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<MovieMaster>().HasData(
                new MovieMaster { Id = 1, Name = "Godzilla", Description = "Action Movie", Language = "Hindi", RunningMin = 120 },
                new MovieMaster { Id = 2, Name = "Stree2", Description = "Horror Movie", Language = "Hindi", RunningMin = 120 },
                new MovieMaster { Id = 3, Name = "Joker", Description = "Action Movie", Language = "Hindi", RunningMin = 120 }
            );

            modelBuilder.Entity<TheatreMaster>().HasData(
                new TheatreMaster { Id = 1, Name = "Inox-Kolkata", Description = "Multiplex", Location = "Kolkata" },
                new TheatreMaster { Id = 2, Name = "PVR-Kolkata", Description = "Multiplex", Location = "Kolkata" },
                new TheatreMaster { Id = 3, Name = "Inox-NCR", Description = "Multiplex", Location = "NCR" },
                new TheatreMaster { Id = 4, Name = "PVR-NCR", Description = "Multiplex", Location = "NCR" }
            );

            modelBuilder.Entity<UserMaster>().HasData(
                new UserMaster { Id = 1, Name = "a1", Email = "a1@deloitte.com", Password = "abc1@123", Location = "Kolkata", Role = "Admin" },
                new UserMaster { Id = 2, Name = "a2", Email = "a2@deloitte.com", Password = "abc2@123", Location = "Hyderabad", Role = "Admin" },
                new UserMaster { Id = 3, Name = "a3", Email = "a3@deloitte.com", Password = "abc3@123", Location = "Pune", Role = "User" },
                new UserMaster { Id = 4, Name = "a4", Email = "a4@deloitte.com", Password = "abc4@123", Location = "NCR", Role = "User" },
                new UserMaster { Id = 5, Name = "a5", Email = "a5@deloitte.com", Password = "abc5@123", Location = "Hyderabad", Role = "User" }
            );
        }
    }
}
