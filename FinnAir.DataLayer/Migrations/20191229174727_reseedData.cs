using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinnAir.DataLayer.Migrations
{
    public partial class reseedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                column: "Id",
                values: new object[]
                {
                    "FIN123",
                    "FIN124",
                    "FIN125",
                    "FIN126",
                    "FIN127",
                    "FIN128"
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "ArrivalAirport", "ArrivalAirportCode", "ArrivalDate", "CarrierCode", "DepartureAirport", "DepartureAirportCode", "DepartureDate", "FlightNumber" },
                values: new object[,]
                {
                    { 1, "Brussel", "BRU", new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "W12", "Stuttgart", "STU", new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FA2490" },
                    { 2, "Brussel", "BRU", new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "A11", "Stuttgart", "STU", new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FA2490" },
                    { 3, "Brussel", "BRU", new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "B13", "Stuttgart", "STU", new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FA2490" },
                    { 4, "Brussel", "BRU", new DateTime(2019, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "C15", "Stuttgart", "STU", new DateTime(2019, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FA2490" }
                });

            migrationBuilder.InsertData(
                table: "BookingFlights",
                columns: new[] { "Id", "BookingId", "FlightId" },
                values: new object[,]
                {
                    { 1, "FIN123", 1 },
                    { 4, "FIN125", 1 },
                    { 3, "FIN124", 2 },
                    { 2, "FIN124", 3 },
                    { 5, "FIN125", 4 }
                });

            migrationBuilder.InsertData(
                table: "Passengers",
                columns: new[] { "Id", "BookingId", "Email", "Firstname", "LastName" },
                values: new object[,]
                {
                    { 1, "FIN123", "gbengaoluyide@gmail.com", "Gbenga", "Oluyide" },
                    { 2, "FIN124", "sadeoluyide@gmail.com", "Sade", "Oluyide" },
                    { 3, "FIN125", "gbade@gmail.com", "Gbade", "Oluyide" },
                    { 4, "FIN126", "bayo@gmail.com", "Bayo", "Oluyide" },
                    { 5, "FIN127", "biibire@gmail.com", "Biibire", "Oluyide" },
                    { 6, "FIN128", "omolaraoluyide@gmail.com", "Omolara", "Oluyide" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "BookingFlights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BookingFlights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BookingFlights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BookingFlights",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BookingFlights",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Passengers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "FIN123");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "FIN124");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "FIN125");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "FIN126");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "FIN127");

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: "FIN128");

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
