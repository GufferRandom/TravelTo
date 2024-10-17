using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class sastumroebi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sastumroebis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fasi = table.Column<int>(type: "int", nullable: false),
                    gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastumroebis", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sastumroebis");
        }
    }
}
