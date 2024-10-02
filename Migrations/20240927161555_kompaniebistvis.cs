using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class kompaniebistvis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "img_name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 1,
                column: "img_name",
                value: "tbc_image.png");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 2,
                columns: new[] { "Name", "img_name" },
                values: new object[] { "liberti", "liberti_img" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 3,
                column: "img_name",
                value: "bog_image");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 4,
                columns: new[] { "Name", "img_name" },
                values: new object[] { "kripto", "credit_bank" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "img_name",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 2,
                column: "Name",
                value: "neee");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 4,
                column: "Name",
                value: "naga");
        }
    }
}
