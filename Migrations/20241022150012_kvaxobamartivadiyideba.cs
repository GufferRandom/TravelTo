using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class kvaxobamartivadiyideba : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7,
                column: "image_name",
                value: "7.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7,
                column: "image_name",
                value: "7.avif");
        }
    }
}
