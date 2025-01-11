using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TravelTo.Migrations
{
    /// <inheritdoc />
    public partial class hel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    First_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Last_Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Company_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    img_name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Company_Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactiUndat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Telephoni = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Messege = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactiUndat", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "sastumroDajavshna",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    First_Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Last_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    text = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sastumroDajavshna", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TvisebebiDaSastumroebi",
                columns: table => new
                {
                    Tviseba_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Wifi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    უფასო_ავტოსადგომი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ოთახი_არამწეველებისთვის = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    რესტორანი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    უფასო_წყალი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    საუნა = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    სპორტული_დარბაზი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ბილიარდი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    სპა_ცენტრი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    კინოდარბაზი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    საკონფერენციო_დარბაზი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ბარი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    საბავშო_ოთახი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ტერასა = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ბაღი = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    სამრეცხაო = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    შინაური_ცხოვრების_დაშვება = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TvisebebiDaSastumroebi", x => x.Tviseba_Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turebis",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Company_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turebis", x => x.id);
                    table.ForeignKey(
                        name: "FK_Turebis_Companies_Company_Id",
                        column: x => x.Company_Id,
                        principalTable: "Companies",
                        principalColumn: "Company_Id");
                });

            migrationBuilder.CreateTable(
                name: "Sastumroebis",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fasi = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokacia = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tviseba_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastumroebis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sastumroebis_TvisebebiDaSastumroebi_Tviseba_Id",
                        column: x => x.Tviseba_Id,
                        principalTable: "TvisebebiDaSastumroebi",
                        principalColumn: "Tviseba_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAndTurebi",
                columns: table => new
                {
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Turebi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAndTurebi", x => new { x.Turebi_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_UserAndTurebi_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserAndTurebi_Turebis_Turebi_Id",
                        column: x => x.Turebi_Id,
                        principalTable: "Turebis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SastumroCapitacity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sastumro_Id = table.Column<int>(type: "int", nullable: true),
                    MaxCapitacity = table.Column<int>(type: "int", nullable: true),
                    CurrentCapacity = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastumroCapitacity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SastumroCapitacity_Sastumroebis_Sastumro_Id",
                        column: x => x.Sastumro_Id,
                        principalTable: "Sastumroebis",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sastumrodaturebi",
                columns: table => new
                {
                    Sastumro_Id = table.Column<int>(type: "int", nullable: false),
                    Turebi_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sastumrodaturebi", x => new { x.Sastumro_Id, x.Turebi_Id });
                    table.ForeignKey(
                        name: "FK_Sastumrodaturebi_Sastumroebis_Sastumro_Id",
                        column: x => x.Sastumro_Id,
                        principalTable: "Sastumroebis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sastumrodaturebi_Turebis_Turebi_Id",
                        column: x => x.Turebi_Id,
                        principalTable: "Turebis",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SastumtroAndDajavshna",
                columns: table => new
                {
                    Sastumro_Id = table.Column<int>(type: "int", nullable: false),
                    SastumroDajavshna_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SastumtroAndDajavshna", x => new { x.Sastumro_Id, x.SastumroDajavshna_Id });
                    table.ForeignKey(
                        name: "FK_SastumtroAndDajavshna_Sastumroebis_Sastumro_Id",
                        column: x => x.Sastumro_Id,
                        principalTable: "Sastumroebis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SastumtroAndDajavshna_sastumroDajavshna_SastumroDajavshna_Id",
                        column: x => x.SastumroDajavshna_Id,
                        principalTable: "sastumroDajavshna",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "userAndSastumroebis",
                columns: table => new
                {
                    Sastumorebi_Id = table.Column<int>(type: "int", nullable: false),
                    User_Id = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userAndSastumroebis", x => new { x.Sastumorebi_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_userAndSastumroebis_AspNetUsers_User_Id",
                        column: x => x.User_Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_userAndSastumroebis_Sastumroebis_Sastumorebi_Id",
                        column: x => x.Sastumorebi_Id,
                        principalTable: "Sastumroebis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Company_Id", "Name", "description", "img_name", "owner" },
                values: new object[,]
                {
                    { 1, "TBCKVADRO", "saswauli kompania romelic arasdros iarsebs", "tbc_image.png", "gela" },
                    { 2, "liberti", "raxdeba sh", "liberti_img.png", "NEKA" },
                    { 3, "bog", "imedia", "bog_image.png", "NAK" },
                    { 4, "kripto", "iarsebs", "credit_bank.png", "bark" }
                });

            migrationBuilder.InsertData(
                table: "TvisebebiDaSastumroebi",
                columns: new[] { "Tviseba_Id", "Wifi", "ბარი", "ბაღი", "ბილიარდი", "კინოდარბაზი", "ოთახი_არამწეველებისთვის", "რესტორანი", "საბავშო_ოთახი", "საკონფერენციო_დარბაზი", "სამრეცხაო", "საუნა", "სპა_ცენტრი", "სპორტული_დარბაზი", "ტერასა", "უფასო_ავტოსადგომი", "უფასო_წყალი", "შინაური_ცხოვრების_დაშვება" },
                values: new object[,]
                {
                    { 1, "YES", "YES", "YES", "NO", "NO", "NO", "NO", "YES", "NO", "YES", "YES", "NO", "YES", "NO", "NO", "NO", "YES" },
                    { 2, "NO", "NO", "NO", "YES", "YES", "YES", "YES", "NO", "YES", "NO", "NO", "YES", "NO", "YES", "YES", "YES", "NO" },
                    { 3, "YES", "YES", "YES", "NO", "YES", "NO", "NO", "YES", "NO", "YES", "YES", "NO", "YES", "NO", "NO", "NO", "YES" },
                    { 4, "YES", "NO", "NO", "YES", "NO", "NO", "YES", "YES", "YES", "YES", "YES", "YES", "NO", "YES", "YES", "NO", "NO" },
                    { 5, "NO", "YES", "YES", "YES", "YES", "YES", "NO", "YES", "NO", "NO", "NO", "NO", "YES", "YES", "NO", "YES", "YES" },
                    { 6, "YES", "YES", "NO", "NO", "YES", "NO", "YES", "NO", "NO", "YES", "YES", "NO", "YES", "NO", "YES", "NO", "YES" },
                    { 7, "NO", "NO", "YES", "YES", "NO", "YES", "YES", "YES", "YES", "YES", "NO", "YES", "NO", "YES", "NO", "NO", "NO" },
                    { 8, "YES", "YES", "NO", "YES", "YES", "NO", "NO", "YES", "NO", "YES", "YES", "YES", "NO", "NO", "YES", "NO", "NO" },
                    { 9, "NO", "NO", "YES", "NO", "YES", "YES", "YES", "NO", "YES", "YES", "NO", "NO", "YES", "YES", "NO", "YES", "YES" },
                    { 10, "YES", "YES", "NO", "YES", "YES", "NO", "NO", "YES", "NO", "YES", "NO", "YES", "NO", "NO", "YES", "YES", "NO" }
                });

            migrationBuilder.InsertData(
                table: "Sastumroebis",
                columns: new[] { "Id", "Description", "Fasi", "Lokacia", "Name", "Nomer", "Owner", "Tviseba_Id", "gmail", "image_name" },
                values: new object[,]
                {
                    { 1, "ეს სასტუმრო წარმოადგენს სამგზის ლუქსს და თანამედროვე მომსახურებას.", 100, "თბილისი", "თბილისის ცენტრალური სასტუმრო", null, null, 1, "tbilisi@gmail.com", "1.jpeg" },
                    { 2, "ამ სასტუმროში სტუმრები სარგებლობენ საოცარი სანაპიროს ხედებით.", 50, "ბათუმი", "ბათუმი რეზორტი", null, null, 2, "batumi@gmail.com", "2.jpg" },
                    { 3, "სასტუმრო გთავაზობთ კომფორტულ პირობებს და შესანიშნავ სამზარეულოს.", 75, "ქუთაისი", "ქუთაისი  სასტუმრო", null, null, 3, "kutaisi@gmail.com", "3.jpg" },
                    { 4, "სასტუმრო წარმოადგენს ისტორიულ და კულტურულ გარემოს.", 60, "მცხეთა", "მცხეთა ჰერიტიჯ სასტუმრო", null, null, 4, "mtskheta@gmail.com", "4.webp" },
                    { 5, "ცენტრალური ადგილმდებარეობა, ახლოს სამრეწველო და კულტურული ატრაქციონებთან.", 80, "ზუგდიდი", "ზუგდიდი პარკ სასტუმრო", null, null, 5, "zugdidi@gmail.com", "5.jpg" },
                    { 6, "მომსახურება მაღალი ხარისხის, მყუდრო ატმოსფერო და თანამედროვე ოთახები.", 40, "გორი", "გორი ფორტეს სასტუმრო", null, null, 6, "gori@gmail.com", "6.jpg" },
                    { 7, "თელავში მდებარე მყუდრო სასტუმრო, რომელიც გთავაზობთ შესანიშნავ მომსახურებას.", 30, "თელავი", "თელავი უაინ ჰოტელი", null, null, 7, "telavi@gmail.com", "7.jpg" },
                    { 8, "სასტუმრო მაღალი ხარისხის მომსახურებითა და ლამაზი ხედებით.", 45, "სიღნაღი", "სიღნაღი ჰილტოპ სასტუმრო", null, null, 8, "signagi@gmail.com", "8.jpg" },
                    { 9, "სასტუმრო მშვიდ გარემოში და სრულყოფილი მყუდროებით.", 55, "რაჭა", "რაჭა რეზორტი", null, null, 9, "racha@gmail.com", "9.jpg" },
                    { 10, "ვარძი ჰოტელი გთავაზობთ თანამედროვე ფასის ოპციებს და განსაცვიფრებელ გარემოს.", 65, "ვარძი", "ვარძი რეზორტი", null, null, 10, "vardzi@gmail.com", "10.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Turebis",
                columns: new[] { "id", "Company_Id", "Description", "Name", "Price", "image_name" },
                values: new object[,]
                {
                    { 1, 1, "ანტარქტიდა დედამიწის ყველაზე სამხრეთული კონტინენტია, სადაც არ არსებობს მუდმივი მოსახლეობა, მხოლოდ მკვლევარები.", "ანტარქტიდა", 999.99000000000001, "antarqtida.jpg" },
                    { 2, 3, "თბილისი საქართველოს დედაქალაქია, ცნობილია თავისი ისტორიული ძველი უბნებით და კულტურული მნიშვნელობით.", "თბილისი", 500.99000000000001, "Tbilisi.jpg" },
                    { 3, 2, "ქუთაისი საქართველოს ისტორიული ქალაქია, გალიას საკათედრო ტაძრითა და მსოფლიოს ერთ-ერთი ძველი უნივერსიტეტით.", "ქუთაისი", 799.99000000000001, "7012519385_f7e92b8d8e_z.jpg" },
                    { 4, 4, "პარიზი საფრანგეთის დედაქალაქია, ცნობილია აიფელის კოშკით და ლუვრის მუზეუმით.", "პარიზი", 1999.99, "Spain.jfif" },
                    { 5, 1, "ბათუმი შავი ზღვის სანაპიროზე მდებარე ქალაქია, ცნობილი თავისი სანაპირო პარკებით და კურორტებით.", "ბათუმი", 999.99000000000001, "Batumi.jpg" },
                    { 6, 2, "მაიამი, აშშ-ის ფლორიდაში მდებარე ქალაქია, ცნობილი თავისი ფინანსური, კულტურული და სავაჭრო ცენტრის როლით.", "მაიამი", 1999.99, "Brazil.jfif" },
                    { 7, 4, "გორი ქალაქია საქართველოში, ცნობილია თავისი ისტორიული მნიშვნელობით და გორის ციხით.", "გორი", 500.99000000000001, "Denmark.jfif" },
                    { 8, 3, "თელავი ქალაქია კახეთში, ცნობილი თავისი ღვინის კულტურით და ისტორიული ძეგლებით.", "თელავი", 999.99000000000001, "Los-AngelesCa.jfif" }
                });

            migrationBuilder.InsertData(
                table: "SastumroCapitacity",
                columns: new[] { "Id", "CurrentCapacity", "MaxCapitacity", "Sastumro_Id" },
                values: new object[,]
                {
                    { 1, 0, 50, 1 },
                    { 2, 0, 100, 2 },
                    { 3, 0, 200, 3 },
                    { 4, 0, 300, 4 },
                    { 5, 0, 50, 5 },
                    { 6, 0, 200, 6 },
                    { 7, 0, 300, 7 },
                    { 8, 0, 300, 8 },
                    { 9, 0, 100, 9 },
                    { 10, 0, 2, 10 }
                });

            migrationBuilder.InsertData(
                table: "Sastumrodaturebi",
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_SastumroCapitacity_Sastumro_Id",
                table: "SastumroCapitacity",
                column: "Sastumro_Id",
                unique: true,
                filter: "[Sastumro_Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Sastumrodaturebi_Turebi_Id",
                table: "Sastumrodaturebi",
                column: "Turebi_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Sastumroebis_Tviseba_Id",
                table: "Sastumroebis",
                column: "Tviseba_Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SastumtroAndDajavshna_SastumroDajavshna_Id",
                table: "SastumtroAndDajavshna",
                column: "SastumroDajavshna_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Turebis_Company_Id",
                table: "Turebis",
                column: "Company_Id");

            migrationBuilder.CreateIndex(
                name: "IX_userAndSastumroebis_User_Id",
                table: "userAndSastumroebis",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserAndTurebi_User_Id",
                table: "UserAndTurebi",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ContactiUndat");

            migrationBuilder.DropTable(
                name: "SastumroCapitacity");

            migrationBuilder.DropTable(
                name: "Sastumrodaturebi");

            migrationBuilder.DropTable(
                name: "SastumtroAndDajavshna");

            migrationBuilder.DropTable(
                name: "userAndSastumroebis");

            migrationBuilder.DropTable(
                name: "UserAndTurebi");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "sastumroDajavshna");

            migrationBuilder.DropTable(
                name: "Sastumroebis");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Turebis");

            migrationBuilder.DropTable(
                name: "TvisebebiDaSastumroebi");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
