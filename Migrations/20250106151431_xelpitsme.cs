using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class xelpitsme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SastumroCapitacity",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapitacity", "Sastumro_Id" },
                values: new object[,]
                {
                    { 1, 0, 50, 1 },
                    { 2, 0, 100, 2 },
                    { 3, 0, 200, 3 },
                    { 4, 0, 300, 4 },
                    { 5, 0, 50, 5 },
                    { 6, 0, 200, 6 },
                    { 7, 0, 300, 7 },
                    { 8, 0, 300, 8 },
                    { 9, 0, 100, 9 },
                    { 10, 0, 200, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
