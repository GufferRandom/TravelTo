using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class kel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "თბილისის  სასტუმრო");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "თბილისის ცენტრალური სასტუმრო");
        }
    }
}
