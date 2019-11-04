using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Punchclock.Web.Migrations
{
    public partial class AddData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Entries",
                columns: new[] { "Id", "CheckIn", "CheckOut" },
                values: new object[] { 1L, new DateTime(2019, 11, 4, 9, 12, 59, 305, DateTimeKind.Local).AddTicks(2994), new DateTime(2019, 11, 6, 9, 12, 59, 309, DateTimeKind.Local).AddTicks(3510) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entries",
                keyColumn: "Id",
                keyValue: 1L);
        }
    }
}
