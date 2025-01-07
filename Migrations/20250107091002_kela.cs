using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class kela : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 10,
                column: "MaxCapitacity",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SastumroCapitacity",
                keyColumn: "Id",
                keyValue: 10,
                column: "MaxCapitacity",
                value: 200);
        }
    }
}
