﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieTicket.DBHelper.DatabaseContext;

#nullable disable

namespace MovieTicket.DBHelper.Migrations
{
    [DbContext(typeof(MovieTicketDbContext))]
    partial class MovieTicketDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DoneBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("Row")
                        .HasColumnType("int");

                    b.Property<int>("ScreenId")
                        .HasColumnType("int");

                    b.Property<string>("SeatNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ShowTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ScreenId");

                    b.HasIndex("UserId");

                    b.ToTable("Booking");
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.MovieListing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<int>("ScreenId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MovieId");

                    b.HasIndex("ScreenId");

                    b.ToTable("MovieListing");
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.MovieMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Language")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RunningMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MovieMaster");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Action Movie",
                            Language = "Hindi",
                            Name = "Godzilla",
                            RunningMin = 120
                        },
                        new
                        {
                            Id = 2,
                            Description = "Horror Movie",
                            Language = "Hindi",
                            Name = "Stree2",
                            RunningMin = 120
                        },
                        new
                        {
                            Id = 3,
                            Description = "Action Movie",
                            Language = "Hindi",
                            Name = "Joker",
                            RunningMin = 120
                        });
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.TheatreMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TheatreMaster");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Multiplex",
                            Location = "Kolkata",
                            Name = "Inox-Kolkata"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Multiplex",
                            Location = "Kolkata",
                            Name = "PVR-Kolkata"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Multiplex",
                            Location = "NCR",
                            Name = "Inox-NCR"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Multiplex",
                            Location = "NCR",
                            Name = "PVR-NCR"
                        });
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.TheatreScreen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Rows")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ScreenName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeatNos")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TheatreId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TheatreId");

                    b.ToTable("TheatreScreen");
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.UserMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserMaster");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "a1@deloitte.com",
                            Location = "Kolkata",
                            Name = "a1",
                            Password = "abc1@123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Email = "a2@deloitte.com",
                            Location = "Hyderabad",
                            Name = "a2",
                            Password = "abc2@123",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "a3@deloitte.com",
                            Location = "Pune",
                            Name = "a3",
                            Password = "abc3@123",
                            Role = "User"
                        },
                        new
                        {
                            Id = 4,
                            Email = "a4@deloitte.com",
                            Location = "NCR",
                            Name = "a4",
                            Password = "abc4@123",
                            Role = "User"
                        },
                        new
                        {
                            Id = 5,
                            Email = "a5@deloitte.com",
                            Location = "Hyderabad",
                            Name = "a5",
                            Password = "abc5@123",
                            Role = "User"
                        });
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.Booking", b =>
                {
                    b.HasOne("MovieTicket.DBHelper.Entities.MovieMaster", "MovieMaster")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTicket.DBHelper.Entities.TheatreScreen", "TheatreScreen")
                        .WithMany()
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTicket.DBHelper.Entities.UserMaster", "UserMaster")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("MovieMaster");

                    b.Navigation("TheatreScreen");

                    b.Navigation("UserMaster");
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.MovieListing", b =>
                {
                    b.HasOne("MovieTicket.DBHelper.Entities.MovieMaster", "MovieMaster")
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MovieTicket.DBHelper.Entities.TheatreScreen", "TheatreScreen")
                        .WithMany()
                        .HasForeignKey("ScreenId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MovieMaster");

                    b.Navigation("TheatreScreen");
                });

            modelBuilder.Entity("MovieTicket.DBHelper.Entities.TheatreScreen", b =>
                {
                    b.HasOne("MovieTicket.DBHelper.Entities.TheatreMaster", "TheatreMaster")
                        .WithMany()
                        .HasForeignKey("TheatreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TheatreMaster");
                });
#pragma warning restore 612, 618
        }
    }
}
