using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class gelap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                column: "image_name",
                value: "Spain.jfif");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                column: "image_name",
                value: "Brazil.jfif");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                column: "image_name",
                value: "Denmark.jfif");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "image_name",
                value: "Los-AngelasCa.jfif");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                column: "image_name",
                value: "Paris.jpg");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                column: "image_name",
                value: "Miami.jpg");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                column: "image_name",
                value: "Gori.jpg");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "image_name",
                value: "Telavi.jpg");
        }
    }
}
