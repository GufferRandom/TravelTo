using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class kide : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "image_name",
                value: "Los-AngelesCa.jfif");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "image_name",
                value: "Los-AngelasCa.jfif");
        }
    }
}
