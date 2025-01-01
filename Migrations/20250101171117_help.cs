using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class help : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SastumroebiDaTurebi",
                columns: new[] { "Sastumro_Id", "Turebi_Id" },
                values: new object[,]
                {
                    { 1, 8 },
                    { 2, 1 },
                    { 3, 2 },
                    { 4, 3 },
                    { 5, 5 },
                    { 8, 6 },
                    { 9, 7 },
                    { 10, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Lokacia",
                value: "RobotiqsiHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Lokacia",
                value: "AntarqtidaHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Lokacia",
                value: "TbilisiHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Lokacia",
                value: "KutaisiHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Lokacia",
                value: "BatumiHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6,
                column: "Lokacia",
                value: "MtskhetaHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7,
                column: "Lokacia",
                value: "ZugdidiHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8,
                column: "Lokacia",
                value: "GoriHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 9,
                column: "Lokacia",
                value: "TelaviHotel");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 10,
                column: "Lokacia",
                value: "SignagiHotel");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "Name",
                value: "Kutasi");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                column: "Name",
                value: "Signagi, CA");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "Name",
                value: "Batumi");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                column: "Name",
                value: "Gori");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                column: "Name",
                value: "Telavi");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "Name",
                value: "Roboto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 2, 1 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 5, 5 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "SastumroebiDaTurebi",
                keyColumns: new[] { "Sastumro_Id", "Turebi_Id" },
                keyValues: new object[] { 10, 4 });

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1,
                column: "Lokacia",
                value: "Robotiqsi");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2,
                column: "Lokacia",
                value: "Antarqtida");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3,
                column: "Lokacia",
                value: "Tbilisi");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4,
                column: "Lokacia",
                value: "Kutaisi");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5,
                column: "Lokacia",
                value: "Batumi");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6,
                column: "Lokacia",
                value: "Mtskheta");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7,
                column: "Lokacia",
                value: "Zugdidi");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8,
                column: "Lokacia",
                value: "Gori");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 9,
                column: "Lokacia",
                value: "Telavi");

            migrationBuilder.UpdateData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 10,
                column: "Lokacia",
                value: "Signagi");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 3,
                column: "Name",
                value: "Parizi");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 4,
                column: "Name",
                value: "Los-Angeles, CA");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 5,
                column: "Name",
                value: "Italy");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 6,
                column: "Name",
                value: "Brazil");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 7,
                column: "Name",
                value: "Denmark");

            migrationBuilder.UpdateData(
                table: "Turebis",
                keyColumn: "id",
                keyValue: 8,
                column: "Name",
                value: "Spain");
        }
    }
}
