using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class ex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 2,
                column: "img_name",
                value: "liberti_img.png");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 3,
                column: "img_name",
                value: "bog_image.png");

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 4,
                column: "img_name",
                value: "credit_bank.png");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 2,
                column: "img_name",
                value: "liberti_img");

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
                column: "img_name",
                value: "credit_bank");
        }
    }
}
