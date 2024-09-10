using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations.ApplicationData
{
    /// <inheritdoc />
    public partial class daeiyps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_Id);
                });

            migrationBuilder.CreateTable(
                name: "Turebis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turebis", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turebis_Companies_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "Company_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Company_Id", "Name", "description", "owner" },
                values: new object[,]
                {
                    { 1, "BOG", null, null },
                    { 2, "TBC", null, null }
                });

            migrationBuilder.InsertData(
                table: "Turebis",
                columns: new[] { "id", "Company_Id", "Description", "Name", "Price", "image_name" },
                values: new object[,]
                {
                    { 1, 1, "aq iyo batoni wyali romelmac wyali dalia", "Antarqtida", 5.9900000000000002, "31394_1.jpg" },
                    { 2, 2, "tbilo tibifli", "Tbilisi", 15.99, "59564_1.jpg" },
                    { 3, 2, "parizelta dedaqali", "Parizi", 6.9900000000000002, "59564_1.jpg" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Turebis_Company_Id",
                table: "Turebis",
                column: "Company_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turebis");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
