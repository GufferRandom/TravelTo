using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class help : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "თბილისის ცენტრალური სასტუმრო");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ბათუმი რეზორტი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "ქუთაისი  სასტუმრო");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "მცხეთა ჰერიტიჯ სასტუმრო");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "ზუგდიდი პარკ სასტუმრო");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "გორი ფორტეს სასტუმრო");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "სიღნაღი ჰილტოპ სასტუმრო");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "თბილისი გრანდ ჰოტელი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "ბათუმი ბიჩ რეზორტი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "ქუთაისი ბუტიკ ჰოტელი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "მცხეთა ჰერიტიჯ ინი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "ზუგდიდი პარკ ჰოტელი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "გორი ფორტეს ჰოტელი");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8,
                column: "Name",
                value: "სიღნაღი ჰილტოპ ჰოტელი");
        }
    }
}
