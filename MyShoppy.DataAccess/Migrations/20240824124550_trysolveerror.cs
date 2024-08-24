using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShoppy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class trysolveerror : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 15, 45, 47, 483, DateTimeKind.Local).AddTicks(1398));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 15, 15, 45, 47, 483, DateTimeKind.Local).AddTicks(1403));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 16, 15, 45, 47, 483, DateTimeKind.Local).AddTicks(1406));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 14, 31, 32, 361, DateTimeKind.Local).AddTicks(9274));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 15, 14, 31, 32, 361, DateTimeKind.Local).AddTicks(9279));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 16, 14, 31, 32, 361, DateTimeKind.Local).AddTicks(9289));
        }
    }
}
