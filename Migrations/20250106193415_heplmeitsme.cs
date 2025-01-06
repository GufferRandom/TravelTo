using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class heplmeitsme : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "image_name",
                value: "7012519385_f7e92b8d8e_z.jpg");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "image_name",
                value: "Batumi.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "image_name",
                value: "Parizi.jfif");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "image_name",
                value: "Italy.png");
        }
    }
}
