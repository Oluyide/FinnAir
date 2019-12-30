using Microsoft.EntityFrameworkCore.Migrations;

namespace FinnAir.DataLayer.Migrations
{
    public partial class CreateIdentitySchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Passengers",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Passengers",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Passengers",
                maxLength: 225,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DepartureAirport",
                table: "Flights",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CarrierCode",
                table: "Flights",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalAirport",
                table: "Flights",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Passengers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "Firstname",
                table: "Passengers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Passengers",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 225);

            migrationBuilder.AlterColumn<string>(
                name: "FlightNumber",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "DepartureAirport",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "CarrierCode",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "ArrivalAirport",
                table: "Flights",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 150);
        }
    }
}
