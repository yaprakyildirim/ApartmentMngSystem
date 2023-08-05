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
                    { 8, 8, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1632), 4, 0, "1+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1632), null },
                    { 9, 10, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1633), 4, 0, "3+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1634), null },
                    { 10, 10, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1635), 6, 0, "4+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1635), null },
                    { 11, 12, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1636), 6, 0, "3+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1637), null }
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
                    { "02174cf0–9123xccfe-afbf-59f706d33cf6", 0, "bbd4e797-34fa-4286-869e-53959eff304c", "User", "busraozdemir@gmail.com", true, "Busra", "14798756332", "Ozdemir", false, null, "BUSRAOZDEMIR@GMAIL.COM", "USER5", "AQAAAAEAACcQAAAAEF3mhbqxEPA9VAxId9JvHnB0vz4llHWrwNUjGKnTnFMPtKGNivFw+gyBesffjj9hjQ==", "5417894125", false, "34ZH45", "97a12417-4f70-48ca-ba15-605d9820e320", false, "user5" },
                    { "02174cf0–9412–4cfe-afbf-53422d33cf6", 0, "071163fd-f3d0-4ca5-bf96-0a76f2b8e024", "User", "cemgunveren@hotmail.com", true, "Cem", "35898714563", "Gunveren", false, null, "CEMGUNVEREN@HOTMAIL.COM", "USER2", "AQAAAAEAACcQAAAAELxDLHHo2bMOJiIOaTioKsaIiCwHzJXwaBsD9UZTRS3iKx9UtMMqn+CVnWTXRRr2og==", "5300708998", false, "34FV07", "2d2e9b32-5508-46fc-afed-ef4bcbbef427", false, "user2" },
                    { "02174cf0–9412–4cfe-afbf-591231sd6d33cf6", 0, "2ca5f407-6d69-48de-a63e-fa9fcf1d0a79", "User", "furkankucukali@outlook.com", true, "Furkan", "17898774123", "Kucukali", false, null, "FURKANKUCUKALI@OUTLOOK.COM", "USER4", "AQAAAAEAACcQAAAAENz/a6dLSGhNhcTbHwwryDj3VmXhcLyQhqXlYujk2quCXBMFuzKDqA99AsShey+Ldg==", "5329665632", false, "34CV78", "204ffe21-de0f-44a8-8344-af80ebc1364d", false, "user4" },
                    { "02174cf0–9412–4cfe-afbf-59f706d72cf6", 0, "c120ada6-c7ba-47f2-8422-1bde91434794", "User", "admin@gmail.com", true, "Yaprak", "14975856297", "Yildirim", false, null, "ADMIN@GMAIL.COM", "ADMIN", "AQAAAAEAACcQAAAAEI3+XRhMDNZXHjkjeOFOFIvHWsuT5P3YutH2TkVDuUjen2kb3Eq5vn0yU15sOeKySQ==", "5417894512", false, "34NV3128", "28b6a138-b650-454e-be8c-572d3780b7d5", false, "admin" },
                    { "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6", 0, "17bb7676-e7cf-48e4-81bb-4f605f0982be", "User", "yusuf@gmail.com", true, "Yusuf", "15178945632", "Aslan", false, null, "YUSUF@GMAIL.COM", "USER3", "AQAAAAEAACcQAAAAEGjqAGaBNXp6fz/JYUBxRPegS9N+plrFGP5w4GVBDrnEmozllKyCLeJR5AkKlrXRqA==", "5329638956", false, "34BFF44", "c7c9e784-bcbf-4b83-b410-7c03a09d138f", false, "user3" },
                    { "02174cf0–9cvbcds2-afbf-59f706d33cf6", 0, "5e7fb33b-c0af-433c-8fe4-e2271409946d", "User", "ayselshn@gmail.com", true, "Aysel", "452256565623", "Sahin", false, null, "AYSELSHN@GMAIL.COM", "USER6", "AQAAAAEAACcQAAAAEIAl38yji2wzakcvTOUqVYAYXCQ0XueO79HU4dt1QUlQFEKXkgM+Quhu3G9PIWf6hA==", "5453500023", false, "34SHN58", "9397cb0b-8f9e-4c9b-b7e7-6442140b478e", false, "user6" },
                    { "02174cf0–xcvds2e-afbf-59f706d33cf6", 0, "242f99b0-b8ce-47ce-9e85-f24175b5670b", "User", "altun58@gmail.com", true, "Altun", "14978889789", "Yıldıran", false, null, "ALTUN58@GMAIL.COM", "USER7", "AQAAAAEAACcQAAAAEL4Bawm47oeI1DH3cLPdySdeXwMj9p+tU/6vOCuTDKFs7DnRKt8Qn1gNnPDSNORb+w==", "5354869874", false, "34AY78", "7f66faf6-2bf1-4aa2-912d-d1c1a05bfe22", false, "user7" }
                });

            migrationBuilder.InsertData(
                table: "Apartments",
                columns: new[] { "Id", "ApartmentNumber", "BlockNumber", "CreatedTime", "Floor", "Status", "Type", "UpdatedTime", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 4, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1608), 2, 1, "3+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1618), "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { 2, 3, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1623), 7, 1, "2+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1623), "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { 3, 3, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1625), 7, 1, "2+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1625), "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { 4, 5, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1626), 3, 1, "3+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1627), "02174cf0–9123xccfe-afbf-59f706d33cf6" },
                    { 5, 5, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1628), 3, 1, "3+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1628), "02174cf0–9cvbcds2-afbf-59f706d33cf6" },
                    { 6, 7, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1629), 3, 0, "4+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1630), "02174cf0–xcvds2e-afbf-59f706d33cf6" },
                    { 7, 7, 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1631), 4, 0, "2+1", new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1631), "02174cf0–9412–4cfe-afbf-59f706d72cf6" }
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
                    { 1, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2011), "Faturalar ödendi.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2011), "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2014), "Apartman temizlenmemişti.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2015), "02174cf0–9412–4cfe-afbf-53422d33cf6" },
                    { 3, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2016), "Asansör bozuk, neden ödeme yapıyoruz.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2016), "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { 4, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2017), "Faturalar ödendi.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2017), "02174cf0–9412–4cfe-afbf-5fhdf6d33cf6" },
                    { 5, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2018), "Güvenlik uyuyor.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2018), "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { 6, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2019), "Araçlar özensiz parkediyor, uyarı geçermisiniz? Teşekkürler", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2020), "02174cf0–9412–4cfe-afbf-591231sd6d33cf6" },
                    { 7, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2021), "Pencerelerden halı, örtü silkelenmesin lütfen. Üst kat uyarılarıma rağmen devam ediyor.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2021), "02174cf0–9123xccfe-afbf-59f706d33cf6" },
                    { 8, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2022), "Aidatı ödendi.", 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(2022), "02174cf0–xcvds2e-afbf-59f706d33cf6" }
                });

            migrationBuilder.InsertData(
                table: "ApartmentCosts",
                columns: new[] { "Id", "Amount", "ApartmentId", "CostType", "CreatedTime", "IsPaid", "Month", "UpdatedTime" },
                values: new object[,]
                {
                    { 1, 180, 1, 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1813), false, 12, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1814) },
                    { 2, 240, 1, 1, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1817), false, 12, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1817) },
                    { 3, 850, 1, 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1819), false, 12, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1819) },
                    { 4, 352, 2, 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1820), false, 9, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1821) },
                    { 5, 550, 2, 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1821), false, 10, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1822) },
                    { 6, 690, 2, 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1823), true, 9, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1823) },
                    { 7, 880, 3, 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1824), true, 9, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1825) },
                    { 8, 490, 3, 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1827), true, 9, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1827) },
                    { 9, 247, 4, 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1828), true, 10, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1829) },
                    { 10, 80, 4, 1, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1830), true, 10, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1830) },
                    { 11, 89, 1, 1, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1831), true, 12, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1831) },
                    { 12, 567, 1, 2, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1832), true, 12, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1833) },
                    { 13, 135, 1, 0, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1834), true, 9, new DateTime(2023, 8, 4, 22, 54, 21, 110, DateTimeKind.Local).AddTicks(1834) }
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
