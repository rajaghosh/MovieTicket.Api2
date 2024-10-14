using Microsoft.EntityFrameworkCore;
using MovieTicket.DBHelper.Entities;
using System.Text.Json;

namespace MovieTicket.DBHelper.DatabaseContext
{
    public class MovieTicketDbContext : DbContext
    {
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
            string appSettingFilePath = "..\\MovieTicket.Api\\appsettings.json";
            string jsonString = File.ReadAllText(appSettingFilePath);

            //Manual read from the appsettings.json for Migration Run to DB
            string conn = "";
            using (JsonDocument doc = JsonDocument.Parse(jsonString))
            {
                JsonElement root = doc.RootElement;
                JsonElement appSettings = root.GetProperty("ConnectionStrings");

                conn = appSettings.GetProperty("MovieTicketDb").GetString();
            }

            optionsBuilder.UseSqlServer(conn);
            base.OnConfiguring(optionsBuilder);
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
                new TheatreMaster { Id = 1, Name = "Inox-Kol", Description = "Multiplex", Location = "Kolkata" },
                new TheatreMaster { Id = 2, Name = "PVR-Kol", Description = "Multiplex", Location = "Kolkata" },
                new TheatreMaster { Id = 3, Name = "Inox-NCR", Description = "Multiplex", Location = "NCR" },
                new TheatreMaster { Id = 4, Name = "PVR-NCR", Description = "Multiplex", Location = "NCR" },
                new TheatreMaster { Id = 5, Name = "Inox-HYD", Description = "Multiplex", Location = "Hyderabad" }
            );

            modelBuilder.Entity<UserMaster>().HasData(
                new UserMaster { Id = 1, Name = "inox-kol", Email = "inox-kol@deloitte.com", Password = "abc1@123", Location = "Kolkata", Role = "Admin" },
                new UserMaster { Id = 2, Name = "inox-kol", Email = "inox-kol@deloitte.com", Password = "abc2@123", Location = "Hyderabad", Role = "Admin" },
                new UserMaster { Id = 3, Name = "cust1", Email = "cust1@deloitte.com", Password = "abc3@123", Location = "Pune", Role = "User" },
                new UserMaster { Id = 4, Name = "cust2", Email = "cust2@deloitte.com", Password = "abc4@123", Location = "NCR", Role = "User" },
                new UserMaster { Id = 5, Name = "inox-hyd", Email = "inox-hyd@deloitte.com", Password = "abc5@123", Location = "Hyderabad", Role = "Admin" }
            );

            modelBuilder.Entity<TheatreScreen>().HasData(
                new TheatreScreen
                {
                    Id = 1,
                    TheatreId = 1,
                    ScreenName = "Inox-Kol-Scr1",
                    Rows = new List<int>() { 1, 2, 3, 4, 5 },
                    SeatNos = new List<string>() { "A", "B", "C", "D", "E" }
                },
                new TheatreScreen
                {
                    Id = 2,
                    TheatreId = 1,
                    ScreenName = "Inox-Kol-Scr2",
                    Rows = new List<int>() { 1, 2, 3, 4, 5 },
                    SeatNos = new List<string>() { "A", "B", "C", "D", "E" }
                },
                new TheatreScreen
                {
                    Id = 3,
                    TheatreId = 2,
                    ScreenName = "PVR-Kol-Scr1",
                    Rows = new List<int>() { 1, 2, 3, 4, 5 },
                    SeatNos = new List<string>() { "A", "B", "C", "D", "E" }
                },
                new TheatreScreen
                {
                    Id = 4,
                    TheatreId = 2,
                    ScreenName = "PVR-Kol-Scr2",
                    Rows = new List<int>() { 1, 2, 3, 4, 5 },
                    SeatNos = new List<string>() { "A", "B", "C", "D", "E" }
                },
                new TheatreScreen
                {
                    Id = 5,
                    TheatreId = 5,
                    ScreenName = "Inox-HYD-Scr1",
                    Rows = new List<int>() { 1, 2, 3, 4, 5 },
                    SeatNos = new List<string>() { "A", "B", "C", "D", "E" }
                },
                new TheatreScreen
                {
                    Id = 6,
                    TheatreId = 5,
                    ScreenName = "Inox-HYD-Scr2",
                    Rows = new List<int>() { 1, 2, 3, 4, 5 },
                    SeatNos = new List<string>() { "A", "B", "C", "D", "E" }
                }
            );

            modelBuilder.Entity<MovieListing>().HasData(
                new MovieListing
                {
                    Id = 1,
                    MovieId = 1,
                    ScreenId = 1,
                    //StartDate= new DateTime(2023,10,01),
                    StartDate = DateTime.Parse("2024-10-21"), //Format yyyy-MM-dd
                    EndDate = DateTime.Parse("2024-10-28"),
                    StartTime = DateTime.Parse("09:00:00"),
                    EndTime = DateTime.Parse("11:00:00"),
                    IsActive = true
                },
                new MovieListing
                {
                    Id = 2,
                    MovieId = 2,
                    ScreenId = 1,
                    StartDate = DateTime.Parse("2024-10-21"),
                    EndDate = DateTime.Parse("2024-10-28"),
                    StartTime = DateTime.Parse("11:30:00"),
                    EndTime = DateTime.Parse("11:30:00"),
                    IsActive = true
                }
            );

            modelBuilder.Entity<Booking>().HasData(
               new Booking { Id = 1, DoneBy = "User", DoneFor = "cust1@deloitte.com", UserId = 1, MovieId = 1, ScreenId = 1, Row = 1, SeatNo = "A", ShowTime = DateTime.Parse("2024-10-22T09:00:00Z") },
               new Booking { Id = 2, DoneBy = "User", DoneFor = "cust1@deloitte.com", UserId = 2, MovieId = 1, ScreenId = 1, Row = 1, SeatNo = "B", ShowTime = DateTime.Parse("2024-10-22T09:00:00Z") }
            );
        }

    }
}
