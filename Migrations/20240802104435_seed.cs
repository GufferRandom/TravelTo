using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turebi",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turebi", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "Turebi",
                columns: new[] { "id", "Description", "Name", "Price", "image_name" },
                values: new object[,]
                {
                    { 1, "aq iyo batoni wyali romelmac wyali dalia", "Antarqtida", 5.9900000000000002, "31394_1.jpg" },
                    { 2, "tbilo tibifli", "Tbilisi", 15.99, "65878_1.jpg" },
                    { 3, "parizelta dedaqali", "Parizi", 6.9900000000000002, "59564_1.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Turebi");
        }
    }
}
