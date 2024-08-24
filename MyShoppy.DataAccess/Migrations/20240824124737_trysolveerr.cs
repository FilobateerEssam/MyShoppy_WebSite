using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShoppy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class trysolveerr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 15, 47, 36, 626, DateTimeKind.Local).AddTicks(8166));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 15, 15, 47, 36, 626, DateTimeKind.Local).AddTicks(8171));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 16, 15, 47, 36, 626, DateTimeKind.Local).AddTicks(8175));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
