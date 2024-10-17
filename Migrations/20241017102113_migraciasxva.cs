using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class migraciasxva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Sastumroebis",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Sastumroebis",
                columns: new[] { "Id", "Description", "Fasi", "Lokacia", "Name", "Nomer", "Owner", "gmail" },
                values: new object[,]
                {
                    { 1, "es sastumro mdebareobs dedamiwis mwervalze romelzedac iyo guini", 100, "Dedamiwis Centri", "Robotiqsi", null, null, "gmail@gmail.com" },
                    { 2, "Es sastumro mdebareobs msoflios yvelaze civ wertislhi wesit esaaa", 50, "AntarqtidaOnTop", "Antarqtida", null, null, "antarqtida@gmail.com" },
                    { 3, "Tbilisi tbilisi tbilisi uni uni uni btu ilia japan tsu .", 75, "Tbilisi City Center", "Tbilisi", null, null, "tbilisi@gmail.com" },
                    { 4, "Kutaisi kutaisi kutaisi ratqmaunda kutasisi rogorc yoveltvbis kutaisi.", 60, "Kutaisi Historical Area", "Kutaisi", null, null, "kutaisi@gmail.com" },
                    { 5, "Batumi bautmi bautmi zfgva zgva zgva meti meti meti .", 80, "Batumi Boulevard", "Batumi", null, null, "batumi@gmail.com" },
                    { 6, "Mtskheta es xom mcxetaa mcxetaa azrze ar var ra davwero amaze.", 40, "Mtskheta Old Town", "Mtskheta", null, null, "mtskheta@gmail.com" },
                    { 7, "Zugdidi es xom zugdidia yvelaze didi farti romelic daixarja", 30, "Zugdidi Park", "Zugdidi", null, null, "zugdidi@gmail.com" },
                    { 8, "Gori gori gori amis meti ra unda vtqva es xom goria gorta shoris.", 45, "Gori Fortress", "Gori", null, null, "gori@gmail.com" },
                    { 9, "Telavi telavi telavi azrze ar var ra davwero amashi mara telaviaMountains.", 55, "Telavi Wine Region", "Telavi", null, null, "telavi@gmail.com" },
                    { 10, "Signagi signagi signagi es xom signagia azrze ar var ra  davwero amazec amitomac signagi signagia.", 65, "Signagi Hilltop", "Signagi", null, null, "signagi@gmail.com" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Sastumroebis",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Sastumroebis");
        }
    }
}
