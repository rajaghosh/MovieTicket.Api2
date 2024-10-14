using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MovieTicket.DBHelper.Migrations
{
    /// <inheritdoc />
    public partial class migration_10142024_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "TheatreMaster",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Inox-Kol");

            migrationBuilder.UpdateData(
                table: "TheatreMaster",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "PVR-Kol");

            migrationBuilder.InsertData(
                table: "TheatreMaster",
                columns: new[] { "Id", "Description", "Location", "Name" },
                values: new object[] { 5, "Multiplex", "Hyderabad", "Inox-HYD" });

            migrationBuilder.InsertData(
                table: "TheatreScreen",
                columns: new[] { "Id", "Rows", "ScreenName", "SeatNos", "TheatreId" },
                values: new object[,]
                {
                    { 1, "[1,2,3,4,5]", "Inox-Kol-Scr1", "[\"A\",\"B\",\"C\",\"D\",\"E\"]", 1 },
                    { 2, "[1,2,3,4,5]", "Inox-Kol-Scr2", "[\"A\",\"B\",\"C\",\"D\",\"E\"]", 1 },
                    { 3, "[1,2,3,4,5]", "PVR-Kol-Scr1", "[\"A\",\"B\",\"C\",\"D\",\"E\"]", 2 },
                    { 4, "[1,2,3,4,5]", "PVR-Kol-Scr2", "[\"A\",\"B\",\"C\",\"D\",\"E\"]", 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "inox-kol@deloitte.com", "inox-kol" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "inox-kol@deloitte.com", "inox-kol" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name" },
                values: new object[] { "cust1@deloitte.com", "cust1" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Name" },
                values: new object[] { "cust2@deloitte.com", "cust2" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Name", "Role" },
                values: new object[] { "inox-hyd@deloitte.com", "inox-hyd", "Admin" });

            migrationBuilder.InsertData(
                table: "Booking",
                columns: new[] { "Id", "DoneBy", "MovieId", "Row", "ScreenId", "SeatNo", "ShowTime", "UserId" },
                values: new object[,]
                {
                    { 1, "User", 1, 1, 1, "A", new DateTime(2023, 10, 22, 14, 30, 0, 0, DateTimeKind.Local), 1 },
                    { 2, "User", 1, 1, 1, "B", new DateTime(2023, 10, 22, 14, 30, 0, 0, DateTimeKind.Local), 2 }
                });

            migrationBuilder.InsertData(
                table: "MovieListing",
                columns: new[] { "Id", "EndDate", "EndTime", "IsActive", "MovieId", "ScreenId", "StartDate", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 11, 0, 0, 0, DateTimeKind.Unspecified), true, 1, 1, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 9, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 11, 30, 0, 0, DateTimeKind.Unspecified), true, 2, 1, new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 14, 11, 30, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TheatreScreen",
                columns: new[] { "Id", "Rows", "ScreenName", "SeatNos", "TheatreId" },
                values: new object[,]
                {
                    { 5, "[1,2,3,4,5]", "Inox-HYD-Scr1", "[\"A\",\"B\",\"C\",\"D\",\"E\"]", 5 },
                    { 6, "[1,2,3,4,5]", "Inox-HYD-Scr2", "[\"A\",\"B\",\"C\",\"D\",\"E\"]", 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieListing",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieListing",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TheatreScreen",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TheatreScreen",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TheatreScreen",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TheatreScreen",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TheatreScreen",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "TheatreMaster",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TheatreScreen",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "TheatreMaster",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Inox-Kolkata");

            migrationBuilder.UpdateData(
                table: "TheatreMaster",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "PVR-Kolkata");

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name" },
                values: new object[] { "a1@deloitte.com", "a1" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name" },
                values: new object[] { "a2@deloitte.com", "a2" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Name" },
                values: new object[] { "a3@deloitte.com", "a3" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Name" },
                values: new object[] { "a4@deloitte.com", "a4" });

            migrationBuilder.UpdateData(
                table: "UserMaster",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Name", "Role" },
                values: new object[] { "a5@deloitte.com", "a5", "User" });
        }
    }
}
