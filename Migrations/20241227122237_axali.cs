using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class axali : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SastumroebiDaTurebi",
                columns: table => new
                {
                    Sastumro_Id = table.Column<int>(type: "int", nullable: false),
                    Turebi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastumroebiDaTurebi", x => new { x.Sastumro_Id, x.Turebi_Id });
                    table.ForeignKey(
                        name: "FK_SastumroebiDaTurebi_Sastumroebis_Sastumro_Id",
                        column: x => x.Sastumro_Id,
                        principalTable: "Sastumroebis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SastumroebiDaTurebi_Turebis_Turebi_Id",
                        column: x => x.Turebi_Id,
                        principalTable: "Turebis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SastumroebiDaTurebi_Turebi_Id",
                table: "SastumroebiDaTurebi",
                column: "Turebi_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SastumroebiDaTurebi");
        }
    }
}
