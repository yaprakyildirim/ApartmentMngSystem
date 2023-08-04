using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApartmentMngSystem.DataAccess.Migrations
{
    public partial class Initial : Migration
    {
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
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdentityNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlateNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                name: "Apartments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApartmentNumber = table.Column<int>(type: "int", nullable: false),
                    BlockNumber = table.Column<int>(type: "int", nullable: false),
                    Floor = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apartments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Apartments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ApartmentCosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CostType = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    Month = table.Column<int>(type: "int", nullable: false),
                    ApartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApartmentCosts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ApartmentCosts_Apartments_ApartmentId",
                        column: x => x.ApartmentId,
                        principalTable: "Apartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "BlockNumber", "CreatedTime", "Floor", "Status", "Type", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 8, 8, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9173), 4, 0, "1+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9174), null },
                    { 9, 10, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9176), 4, 0, "3+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9176), null },
                    { 10, 10, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9177), 6, 0, "4+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9178), null },
                    { 11, 12, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9179), 6, 0, "3+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9179), null }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "341743f0-asd2–42de-afbf-49kmkkmk72cf6", "Admin", "ADMIN" },
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "341743f0-asd2–42de-afbf-39kmkkmk72cf6", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "IdentityNumber", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PlateNumber", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "02174cf0–9123xccfe-afbf-59f706d33cf6", 0, "88abaa66-01e2-4690-9166-a680c07b0ba0", "User", "busraozdemir@gmail.com", true, "Busra", "14798756332", "Ozdemir", false, null, "BUSRAOZDEMIR@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAEKReK8rVoTEFa2mvf0hpYkTXdYgRc8Mjj27BC9eyP5NBlmmZ/HlSXUEPfkuhAjRatQ==", "5417894125", false, "34ZH45", "9c2244a8-3c80-4fed-9d69-f196232e0c0a", false, "user5" },
                    { "02174cf0–9412–4cfe-afbf-53422d33cf6", 0, "6eab375b-5df9-4270-bb7a-579f7b589d97", "User", "cemgunveren@hotmail.com", true, "Cem", "35898714563", "Gunveren", false, null, "CEMGUNVEREN@HOTMAIL.COM", "USER2", "AQAAAAEAACcQAAAAEOTO+/fnBPR8N/MTnlTQG/2o6M0+j/aSXNHzjPgfexwEs4099QReYLXX6LsaDhs3tw==", "5300708998", false, "34FV07", "847bd3fc-8794-4f98-86e0-4b076a1a4c8d", false, "user2" },
                    { "02174cf0–9412–4cfe-afbf-591231sd6d33cf6", 0, "101aac64-9a26-4f0d-85e1-290306002db5", "User", "furkankucukali@outlook.com", true, "Furkan", "17898774123", "Kucukali", false, null, "FURKANKUCUKALI@OUTLOOK.COM", "USER4", "AQAAAAEAACcQAAAAEFJQm1Ohf4n/1pniBRuUn2W1jSdKnHFbl9Dzv+F4v7GIagrJZP7DWBHAUmG+HmUZIw==", "5329665632", false, "34CV78", "c9ccb3d1-e907-4287-9b27-e54fdd34e88c", false, "user4" },
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "7a63cf79-186a-44b9-be6d-eb544318fbf6", "User", "admin@gmail.com", true, "Yaprak", "14975856297", "Yildirim", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEGV9mdLAAMgzSBbkNbYpg4ZGqrw8IFUUuJ0IBGXkELsIse1+5l2IA3g9gx21ZGkHaQ==", "5417894512", false, "34NV3128", "4fa506c2-7411-43c3-bf5f-33af97b0cca2", false, "admin" },
                    { "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6", 0, "255c8619-8024-4cfb-a712-be14c6dcebc8", "User", "yusuf@gmail.com", true, "Yusuf", "15178945632", "Aslan", false, null, "YUSUF@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEH0vk9qpK0x0SNRvwHev/KYX5j6KiReRoSmDBoKUP+lY7AmYP993RORrNcus03rbrQ==", "5329638956", false, "34BFF44", "7af96a38-aa3a-450a-9641-5c20935c7474", false, "user3" },
                    { "02174cf0–9cvbcds2-afbf-59f706d33cf6", 0, "22fd7945-4b82-4401-8c00-721326114f24", "User", "ayselshn@gmail.com", true, "Aysel", "452256565623", "Sahin", false, null, "AYSELSHN@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEMX4MNONvP/6lySHCHacMARMKcY0UNaWoL9TAzjbt46RfSPTYY2dSR1HvXiyIT5hEg==", "5453500023", false, "34SHN58", "0891b968-fad0-4558-9573-5b014e6cd9e8", false, "user6" },
                    { "02174cf0–xcvds2e-afbf-59f706d33cf6", 0, "bae156ee-344c-4d7a-906e-2b0d73e3fd7a", "User", "altun58@gmail.com", true, "Altun", "14978889789", "Yıldıran", false, null, "ALTUN58@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEAh+Ur/bR1H6yl28HdLgkS3oVgwi6hykbzchf82W717noLq0McJWanNAG3gvk8XdAw==", "5354869874", false, "34AY78", "a75df7c2-168a-482a-ad77-f4a793a56085", false, "user7" }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "BlockNumber", "CreatedTime", "Floor", "Status", "Type", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9152), 2, 1, "3+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9160), "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { 2, 3, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9164), 7, 1, "2+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9164), "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { 3, 3, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9166), 7, 1, "2+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9166), "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { 4, 5, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9167), 3, 1, "3+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9168), "02174cf0–9123xccfe-afbf-59f706d33cf6" },
                    { 5, 5, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9169), 3, 1, "3+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9169), "02174cf0–9cvbcds2-afbf-59f706d33cf6" },
                    { 6, 7, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9170), 3, 0, "4+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9171), "02174cf0–xcvds2e-afbf-59f706d33cf6" },
                    { 7, 7, 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9172), 4, 0, "2+1", new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9172), "02174cf0–9412–4cfe-afbf-59f706d72cf6" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "02174cf0–9123xccfe-afbf-59f706d33cf6" },
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { "341743f0-asd2–42de-afbf-59kmkkmk72cf6", "02174cf0–9412–4cfe-afbf-59f706d72cf6" },
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "02174cf0–9cvbcds2-afbf-59f706d33cf6" },
                    { "34213123xxx0-asd2–42de-afas29k3X72cf6", "02174cf0–xcvds2e-afbf-59f706d33cf6" }
                });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "Id", "CreatedTime", "Description", "Status", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9501), "Faturalar ödendi.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9501), "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9503), "Apartman temizlenmemişti.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9504), "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { 3, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9505), "Asansör bozuk, neden ödeme yapıyoruz.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9505), "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { 4, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9506), "Faturalar ödendi.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9507), "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { 5, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9508), "Güvenlik uyuyor.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9508), "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { 6, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9509), "Araçlar özensiz parkediyor, uyarı geçermisiniz? Teşekkürler", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9509), "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { 7, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9510), "Pencerelerden halı, örtü silkelenmesin lütfen. Üst kat uyarılarıma rağmen devam ediyor.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9511), "02174cf0–9123xccfe-afbf-59f706d33cf6" },
                    { 8, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9511), "Aidatı ödendi.", 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9512), "02174cf0–xcvds2e-afbf-59f706d33cf6" }
                });

            migrationBuilder.InsertData(
                table: "ApartmentCosts",
                columns: new[] { "Id", "Amount", "ApartmentId", "CostType", "CreatedTime", "IsPaid", "Month", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 180, 1, 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9392), false, 12, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9392) },
                    { 2, 240, 1, 1, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9395), false, 12, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9395) },
                    { 3, 850, 1, 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9397), false, 12, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9397) },
                    { 4, 352, 2, 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9398), false, 9, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9398) },
                    { 5, 550, 2, 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9429), false, 10, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9430) },
                    { 6, 690, 2, 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9431), true, 9, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9431) },
                    { 7, 880, 3, 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9432), true, 9, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9433) },
                    { 8, 490, 3, 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9434), true, 9, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9434) },
                    { 9, 247, 4, 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9435), true, 10, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9436) },
                    { 10, 80, 4, 1, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9436), true, 10, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9437) },
                    { 11, 89, 1, 1, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9438), true, 12, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9438) },
                    { 12, 567, 1, 2, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9439), true, 12, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9440) },
                    { 13, 135, 1, 0, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9441), true, 9, new DateTime(2023, 8, 4, 17, 17, 49, 216, DateTimeKind.Local).AddTicks(9441) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApartmentCosts_ApartmentId",
                table: "ApartmentCosts",
                column: "ApartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Apartments_UserId",
                table: "Apartments",
                column: "UserId",
                unique: true,
                filter: "[UserId] IS NOT NULL");

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
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApartmentCosts");

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
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Apartments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
