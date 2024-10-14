using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicket.DBHelper.Migrations
{
    /// <inheritdoc />
    public partial class migration_10142024_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowTime",
                value: new DateTime(2024, 10, 22, 14, 30, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowTime",
                value: new DateTime(2024, 10, 22, 14, 30, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "MovieListing",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieListing",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2024, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                column: "ShowTime",
                value: new DateTime(2023, 10, 22, 14, 30, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                column: "ShowTime",
                value: new DateTime(2023, 10, 22, 14, 30, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "MovieListing",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "MovieListing",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndDate", "StartDate" },
                values: new object[] { new DateTime(2023, 10, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
