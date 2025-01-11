using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class kidekaco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sastumrodaturebi_Sastumroebis_Sastumro_Id",
                table: "Sastumrodaturebi");

            migrationBuilder.DropForeignKey(
                name: "FK_Sastumrodaturebi_Turebis_Turebi_Id",
                table: "Sastumrodaturebi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sastumrodaturebi",
                table: "Sastumrodaturebi");

            migrationBuilder.RenameTable(
                name: "Sastumrodaturebi",
                newName: "SastumroebiDaTurebi");

            migrationBuilder.RenameIndex(
                name: "IX_Sastumrodaturebi_Turebi_Id",
                table: "SastumroebiDaTurebi",
                newName: "IX_SastumroebiDaTurebi_Turebi_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SastumroebiDaTurebi",
                table: "SastumroebiDaTurebi",
                columns: new[] { "Sastumro_Id", "Turebi_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_SastumroebiDaTurebi_Sastumroebis_Sastumro_Id",
                table: "SastumroebiDaTurebi",
                column: "Sastumro_Id",
                principalTable: "Sastumroebis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SastumroebiDaTurebi_Turebis_Turebi_Id",
                table: "SastumroebiDaTurebi",
                column: "Turebi_Id",
                principalTable: "Turebis",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SastumroebiDaTurebi_Sastumroebis_Sastumro_Id",
                table: "SastumroebiDaTurebi");

            migrationBuilder.DropForeignKey(
                name: "FK_SastumroebiDaTurebi_Turebis_Turebi_Id",
                table: "SastumroebiDaTurebi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SastumroebiDaTurebi",
                table: "SastumroebiDaTurebi");

            migrationBuilder.RenameTable(
                name: "SastumroebiDaTurebi",
                newName: "Sastumrodaturebi");

            migrationBuilder.RenameIndex(
                name: "IX_SastumroebiDaTurebi_Turebi_Id",
                table: "Sastumrodaturebi",
                newName: "IX_Sastumrodaturebi_Turebi_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sastumrodaturebi",
                table: "Sastumrodaturebi",
                columns: new[] { "Sastumro_Id", "Turebi_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_Sastumrodaturebi_Sastumroebis_Sastumro_Id",
                table: "Sastumrodaturebi",
                column: "Sastumro_Id",
                principalTable: "Sastumroebis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sastumrodaturebi_Turebis_Turebi_Id",
                table: "Sastumrodaturebi",
                column: "Turebi_Id",
                principalTable: "Turebis",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
