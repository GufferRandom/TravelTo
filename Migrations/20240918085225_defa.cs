using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class defa : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Company_Id", "Name", "description", "owner" },
                values: new object[,]
                {
                    { 1, "TBCKVADRO", "saswauli kompania romelic arasdros iarsebs", "gela" },
                    { 2, "neee", "raxdeba sh", "NEKA" },
                    { 3, "bog", "imedia", "NAK" },
                    { 4, "naga", "iarsebs", "bark" }
                });

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 1,
                column: "Company_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 2,
                column: "Company_Id",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "Company_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                column: "Company_Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "Company_Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                column: "Company_Id",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                column: "Company_Id",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "Company_Id",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Company_Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Companies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 1,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 2,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                column: "Company_Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "Company_Id",
                value: null);
        }
    }
}
