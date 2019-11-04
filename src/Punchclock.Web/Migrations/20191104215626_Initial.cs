using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Punchclock.Web.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    DepartmentId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                name: "Entries",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CheckIn = table.Column<DateTime>(nullable: false),
                    CheckOut = table.Column<DateTime>(nullable: false),
                    EmployeeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Entries_AspNetUsers_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Title" },
                values: new object[] { 1L, "Department 1" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Title" },
                values: new object[] { 2L, "Department 2" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Title" },
                values: new object[] { 3L, "Department 3" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Title" },
                values: new object[] { 4L, "Department 4" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Title" },
                values: new object[] { 5L, "Department 5" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Title" },
                values: new object[] { 6L, "Department 6" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "8", 0, "ff164abf-6a49-4a14-b505-0bb6ca858f76", "Employee", "test8@test.com", false, false, null, null, null, null, null, false, "d9d4b4cd-e7de-45f5-bb34-ad4a3dd70bc8", false, null, 1L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "19", 0, "da964cad-1cb9-4303-b325-eb4937d5751e", "Employee", "test19@test.com", false, false, null, null, null, null, null, false, "f7311b23-28d0-4346-a056-4cb0e9337ab5", false, null, 5L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "16", 0, "ba6e804a-2dbc-421d-9331-dff8ee0cb54a", "Employee", "test16@test.com", false, false, null, null, null, null, null, false, "f98c8b1b-8c37-4145-a9e7-843aee1cffc1", false, null, 5L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "7", 0, "0b0fc1a2-aaf2-47cf-805e-f7e90bee9536", "Employee", "test7@test.com", false, false, null, null, null, null, null, false, "c363e46b-4878-4ce4-bae2-ae93332d31ad", false, null, 5L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "4", 0, "ddd91316-2f96-4596-ba23-108e94042502", "Employee", "test4@test.com", false, false, null, null, null, null, null, false, "6016f6b7-1a53-4609-83c5-7e2ab07ff90d", false, null, 5L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "17", 0, "ae97d17d-c0dd-4d33-9838-c224edbf8570", "Employee", "test17@test.com", false, false, null, null, null, null, null, false, "fb98ad7c-843e-42d9-aa3a-7e9310a26052", false, null, 4L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "15", 0, "0bba95f0-fae2-483f-8034-1b2d087ab3bc", "Employee", "test15@test.com", false, false, null, null, null, null, null, false, "a9362a26-6ea9-401d-b3d7-ba0fc95006f2", false, null, 4L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "6", 0, "e27faaee-c4e9-449b-b340-daa4b5189f45", "Employee", "test6@test.com", false, false, null, null, null, null, null, false, "4d0ee317-7df2-4fa6-8624-25a71ae804db", false, null, 4L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "2", 0, "f2e14e8d-4c35-4bc3-adeb-a6c6c9c6cfa9", "Employee", "test2@test.com", false, false, null, null, null, null, null, false, "d92efa4e-e62c-49f3-9b0f-6b1c6c392891", false, null, 4L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "20", 0, "3f2b6106-cb27-4895-950f-ba18e99e94eb", "Employee", "test20@test.com", false, false, null, null, null, null, null, false, "6b5ea6e3-8edc-40c9-b1f1-a59e52ca0411", false, null, 3L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "18", 0, "47f278e9-0d52-43d5-8b72-fd601f9f6a87", "Employee", "test18@test.com", false, false, null, null, null, null, null, false, "13bf1f47-4dca-405d-b950-bc413c9e421a", false, null, 3L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "11", 0, "ef0c5e31-fd3f-49d0-a30d-37fa1737217e", "Employee", "test11@test.com", false, false, null, null, null, null, null, false, "9e019954-d65c-4fe0-b4bb-b3ebf52071c0", false, null, 3L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "10", 0, "2e8c8c33-b0b8-4b91-a1a6-e58e5842b7ee", "Employee", "test10@test.com", false, false, null, null, null, null, null, false, "a77571f0-30b2-461e-aed8-94dda18b8504", false, null, 3L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "9", 0, "944cb71d-aa7d-4cb2-bee9-b210f93ee4f5", "Employee", "test9@test.com", false, false, null, null, null, null, null, false, "74d57505-0670-4a71-9651-b9727a95a7f8", false, null, 3L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "13", 0, "40997aa0-ff2b-4417-8c5c-d2b2073450ec", "Employee", "test13@test.com", false, false, null, null, null, null, null, false, "909da6c9-0a91-4d64-a52e-c39d54d7869b", false, null, 2L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "12", 0, "d4e70aeb-f5fc-4ea5-b20c-823f8a370420", "Employee", "test12@test.com", false, false, null, null, null, null, null, false, "4e7696bc-c57e-4d1e-9308-cb8144657c35", false, null, 2L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "3", 0, "ba0a452f-ddb4-44a0-b616-a25d9f232474", "Employee", "test3@test.com", false, false, null, null, null, null, null, false, "57c58da5-210c-46cf-a297-30c77900504b", false, null, 2L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "14", 0, "f87129cf-05bf-451b-bfac-712c61f8bbc3", "Employee", "test14@test.com", false, false, null, null, null, null, null, false, "3dbd6881-4aaa-43a0-b0db-ac955e4df1d2", false, null, 1L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "1", 0, "aec81e47-b49a-43f4-be8e-dcec5768434b", "Employee", "test1@test.com", false, false, null, null, null, null, null, false, "5aa719f4-c0af-4e3d-9804-0b55325d1bff", false, null, 6L });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "DepartmentId" },
                values: new object[] { "5", 0, "e2cb5bda-c101-4b6c-b78a-0fd937e00529", "Employee", "test5@test.com", false, false, null, null, null, null, null, false, "e3723920-1ad4-422b-94ea-2ec62399e180", false, null, 6L });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 19L, new DateTime(2019, 10, 16, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1792), new DateTime(2019, 11, 23, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1794), "8" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 32L, new DateTime(2019, 10, 3, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1837), new DateTime(2019, 12, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1838), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 31L, new DateTime(2019, 10, 4, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1834), new DateTime(2019, 12, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1835), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 26L, new DateTime(2019, 10, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1817), new DateTime(2019, 11, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1818), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 8L, new DateTime(2019, 10, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1714), new DateTime(2019, 11, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1715), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 2L, new DateTime(2019, 11, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1652), new DateTime(2019, 11, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1668), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 100L, new DateTime(2019, 7, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2202), new DateTime(2020, 2, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2204), "17" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 33L, new DateTime(2019, 10, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1840), new DateTime(2019, 12, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1842), "17" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 48L, new DateTime(2019, 9, 17, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1894), new DateTime(2019, 12, 22, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1895), "15" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 47L, new DateTime(2019, 9, 18, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1890), new DateTime(2019, 12, 21, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1892), "15" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 40L, new DateTime(2019, 9, 25, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1866), new DateTime(2019, 12, 14, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1867), "15" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 36L, new DateTime(2019, 9, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1851), new DateTime(2019, 12, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1853), "15" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 28L, new DateTime(2019, 10, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1823), new DateTime(2019, 12, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1825), "15" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 16L, new DateTime(2019, 10, 19, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1782), new DateTime(2019, 11, 20, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1783), "15" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 96L, new DateTime(2019, 7, 31, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2188), new DateTime(2020, 2, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2189), "6" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 93L, new DateTime(2019, 8, 3, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2178), new DateTime(2020, 2, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2179), "6" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 63L, new DateTime(2019, 9, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1945), new DateTime(2020, 1, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1947), "6" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 58L, new DateTime(2019, 9, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1928), new DateTime(2020, 1, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1929), "6" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 45L, new DateTime(2019, 9, 20, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1883), new DateTime(2019, 12, 19, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1885), "2" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 41L, new DateTime(2019, 9, 24, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1869), new DateTime(2019, 12, 15, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1871), "2" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 25L, new DateTime(2019, 10, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1813), new DateTime(2019, 11, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1815), "2" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 21L, new DateTime(2019, 10, 14, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1799), new DateTime(2019, 11, 25, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1801), "2" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 49L, new DateTime(2019, 9, 16, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1897), new DateTime(2019, 12, 23, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1899), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 84L, new DateTime(2019, 8, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2145), new DateTime(2020, 1, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2147), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 72L, new DateTime(2019, 8, 24, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1977), new DateTime(2020, 1, 15, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1978), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 3L, new DateTime(2019, 11, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1694), new DateTime(2019, 11, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1696), "7" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 70L, new DateTime(2019, 8, 26, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1970), new DateTime(2020, 1, 13, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1971), "5" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 66L, new DateTime(2019, 8, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1956), new DateTime(2020, 1, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1957), "5" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 22L, new DateTime(2019, 10, 13, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1803), new DateTime(2019, 11, 26, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1804), "5" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 6L, new DateTime(2019, 10, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1707), new DateTime(2019, 11, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1708), "5" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 98L, new DateTime(2019, 7, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2195), new DateTime(2020, 2, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2196), "1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 92L, new DateTime(2019, 8, 4, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2174), new DateTime(2020, 2, 4, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2175), "1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 88L, new DateTime(2019, 8, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2160), new DateTime(2020, 1, 31, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2161), "1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 73L, new DateTime(2019, 8, 23, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2106), new DateTime(2020, 1, 16, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2107), "1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 24L, new DateTime(2019, 10, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1810), new DateTime(2019, 11, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1812), "1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 20L, new DateTime(2019, 10, 15, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1796), new DateTime(2019, 11, 24, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1797), "1" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 17L, new DateTime(2019, 10, 18, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1785), new DateTime(2019, 11, 21, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1787), "19" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 62L, new DateTime(2019, 9, 3, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1942), new DateTime(2020, 1, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1943), "16" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 54L, new DateTime(2019, 9, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1914), new DateTime(2019, 12, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1916), "16" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 51L, new DateTime(2019, 9, 14, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1904), new DateTime(2019, 12, 25, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1906), "16" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 46L, new DateTime(2019, 9, 19, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1887), new DateTime(2019, 12, 20, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1888), "16" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 38L, new DateTime(2019, 9, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1859), new DateTime(2019, 12, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1860), "16" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 97L, new DateTime(2019, 7, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2192), new DateTime(2020, 2, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2193), "7" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 86L, new DateTime(2019, 8, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2153), new DateTime(2020, 1, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2154), "7" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 80L, new DateTime(2019, 8, 16, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2131), new DateTime(2020, 1, 23, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2132), "7" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 57L, new DateTime(2019, 9, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1924), new DateTime(2019, 12, 31, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1926), "7" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 37L, new DateTime(2019, 9, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1855), new DateTime(2019, 12, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1856), "7" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 87L, new DateTime(2019, 8, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2156), new DateTime(2020, 1, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2158), "4" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 82L, new DateTime(2019, 8, 14, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2138), new DateTime(2020, 1, 25, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2140), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 79L, new DateTime(2019, 8, 17, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2128), new DateTime(2020, 1, 22, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2129), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 78L, new DateTime(2019, 8, 18, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2124), new DateTime(2020, 1, 21, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2125), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 69L, new DateTime(2019, 8, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1966), new DateTime(2020, 1, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1968), "13" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 42L, new DateTime(2019, 9, 23, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1872), new DateTime(2019, 12, 16, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1874), "13" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 1L, new DateTime(2019, 11, 3, 22, 56, 26, 291, DateTimeKind.Local).AddTicks(9297), new DateTime(2019, 11, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(795), "13" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 83L, new DateTime(2019, 8, 13, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2142), new DateTime(2020, 1, 26, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2143), "12" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 64L, new DateTime(2019, 9, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1949), new DateTime(2020, 1, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1950), "12" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 61L, new DateTime(2019, 9, 4, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1938), new DateTime(2020, 1, 4, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1940), "12" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 43L, new DateTime(2019, 9, 22, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1876), new DateTime(2019, 12, 17, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1878), "12" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 34L, new DateTime(2019, 10, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1844), new DateTime(2019, 12, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1845), "12" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 95L, new DateTime(2019, 8, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2185), new DateTime(2020, 2, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2186), "3" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 5L, new DateTime(2019, 10, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1703), new DateTime(2019, 11, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1705), "3" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 94L, new DateTime(2019, 8, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2181), new DateTime(2020, 2, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2182), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 77L, new DateTime(2019, 8, 19, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2120), new DateTime(2020, 1, 20, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2122), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 74L, new DateTime(2019, 8, 22, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2109), new DateTime(2020, 1, 17, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2111), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 39L, new DateTime(2019, 9, 26, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1862), new DateTime(2019, 12, 13, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1863), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 27L, new DateTime(2019, 10, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1820), new DateTime(2019, 12, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1821), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 18L, new DateTime(2019, 10, 17, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1789), new DateTime(2019, 11, 22, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1790), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 12L, new DateTime(2019, 10, 23, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1766), new DateTime(2019, 11, 16, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1768), "14" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 91L, new DateTime(2019, 8, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2170), new DateTime(2020, 2, 3, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2172), "8" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 65L, new DateTime(2019, 8, 31, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1952), new DateTime(2020, 1, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1954), "8" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 56L, new DateTime(2019, 9, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1921), new DateTime(2019, 12, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1922), "8" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 55L, new DateTime(2019, 9, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1918), new DateTime(2019, 12, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1919), "8" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 11L, new DateTime(2019, 10, 24, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1725), new DateTime(2019, 11, 15, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1726), "9" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 71L, new DateTime(2019, 8, 25, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1973), new DateTime(2020, 1, 14, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1975), "9" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 81L, new DateTime(2019, 8, 15, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2134), new DateTime(2020, 1, 24, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2136), "9" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 13L, new DateTime(2019, 10, 22, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1771), new DateTime(2019, 11, 17, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1772), "10" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 75L, new DateTime(2019, 8, 21, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2113), new DateTime(2020, 1, 18, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2115), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 60L, new DateTime(2019, 9, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1935), new DateTime(2020, 1, 3, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1936), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 53L, new DateTime(2019, 9, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1911), new DateTime(2019, 12, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1912), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 30L, new DateTime(2019, 10, 5, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1830), new DateTime(2019, 12, 4, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1832), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 15L, new DateTime(2019, 10, 20, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1778), new DateTime(2019, 11, 19, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1780), "20" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 68L, new DateTime(2019, 8, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1963), new DateTime(2020, 1, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1964), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 67L, new DateTime(2019, 8, 29, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1959), new DateTime(2020, 1, 10, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1961), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 52L, new DateTime(2019, 9, 13, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1908), new DateTime(2019, 12, 26, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1909), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 50L, new DateTime(2019, 9, 15, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1901), new DateTime(2019, 12, 24, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1902), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 44L, new DateTime(2019, 9, 21, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1880), new DateTime(2019, 12, 18, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1881), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 85L, new DateTime(2019, 8, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2149), new DateTime(2020, 1, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2151), "5" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 35L, new DateTime(2019, 9, 30, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1848), new DateTime(2019, 12, 9, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1849), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 23L, new DateTime(2019, 10, 12, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1806), new DateTime(2019, 11, 27, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1808), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 14L, new DateTime(2019, 10, 21, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1775), new DateTime(2019, 11, 18, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1776), "11" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 10L, new DateTime(2019, 10, 25, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1721), new DateTime(2019, 11, 14, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1723), "11" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 9L, new DateTime(2019, 10, 26, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1718), new DateTime(2019, 11, 13, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1719), "11" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 7L, new DateTime(2019, 10, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1710), new DateTime(2019, 11, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1712), "11" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 4L, new DateTime(2019, 10, 31, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1699), new DateTime(2019, 11, 8, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1700), "11" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 99L, new DateTime(2019, 7, 28, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2198), new DateTime(2020, 2, 11, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2200), "10" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 90L, new DateTime(2019, 8, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2167), new DateTime(2020, 2, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2168), "10" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 76L, new DateTime(2019, 8, 20, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2117), new DateTime(2020, 1, 19, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2118), "10" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 59L, new DateTime(2019, 9, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1931), new DateTime(2020, 1, 2, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1933), "10" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 29L, new DateTime(2019, 10, 6, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1827), new DateTime(2019, 12, 3, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(1828), "18" });

            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut", "EmployeeId" },
                values: new object[] { 89L, new DateTime(2019, 8, 7, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2163), new DateTime(2020, 2, 1, 22, 56, 26, 296, DateTimeKind.Local).AddTicks(2165), "5" });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DepartmentId",
                table: "AspNetUsers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Entries_EmployeeId",
                table: "Entries",
                column: "EmployeeId");
        }

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
                name: "Entries");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
