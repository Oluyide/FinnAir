using Microsoft.EntityFrameworkCore.Migrations;

namespace FinnAir.DataLayer.Migrations
{
    public partial class seed_parsenger : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
