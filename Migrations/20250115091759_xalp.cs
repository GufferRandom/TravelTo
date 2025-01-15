using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class xalp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCookieTurebis_UserCookie_User_Id",
                table: "userCookieTurebis");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserCookie",
                table: "UserCookie");

            migrationBuilder.RenameTable(
                name: "UserCookie",
                newName: "userCookies");

            migrationBuilder.AddPrimaryKey(
                name: "PK_userCookies",
                table: "userCookies",
                column: "User_Id");

            migrationBuilder.CreateTable(
                name: "userSastumroebiCookies",
                columns: table => new
                {
                    Sastumro_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userSastumroebiCookies", x => new { x.Sastumro_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_userSastumroebiCookies_Sastumroebis_Sastumro_Id",
                        column: x => x.Sastumro_Id,
                        principalTable: "Sastumroebis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userSastumroebiCookies_userCookies_User_Id",
                        column: x => x.User_Id,
                        principalTable: "userCookies",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_userSastumroebiCookies_User_Id",
                table: "userSastumroebiCookies",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userCookieTurebis_userCookies_User_Id",
                table: "userCookieTurebis",
                column: "User_Id",
                principalTable: "userCookies",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userCookieTurebis_userCookies_User_Id",
                table: "userCookieTurebis");

            migrationBuilder.DropTable(
                name: "userSastumroebiCookies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_userCookies",
                table: "userCookies");

            migrationBuilder.RenameTable(
                name: "userCookies",
                newName: "UserCookie");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserCookie",
                table: "UserCookie",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_userCookieTurebis_UserCookie_User_Id",
                table: "userCookieTurebis",
                column: "User_Id",
                principalTable: "UserCookie",
                principalColumn: "User_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
