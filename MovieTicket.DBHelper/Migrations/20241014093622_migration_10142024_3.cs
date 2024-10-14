using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieTicket.DBHelper.Migrations
{
    /// <inheritdoc />
    public partial class migration_10142024_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DoneFor",
                table: "Booking",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 1,
                column: "DoneFor",
                value: "cust1@deloitte.com");

            migrationBuilder.UpdateData(
                table: "Booking",
                keyColumn: "Id",
                keyValue: 2,
                column: "DoneFor",
                value: "cust1@deloitte.com");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DoneFor",
                table: "Booking");
        }
    }
}
