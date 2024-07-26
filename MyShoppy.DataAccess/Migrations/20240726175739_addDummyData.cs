using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MyShoppy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addDummyData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "Description", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 7, 16, 20, 57, 37, 167, DateTimeKind.Local).AddTicks(6894), "", "Phones" },
                    { 2, new DateTime(2024, 7, 17, 20, 57, 37, 167, DateTimeKind.Local).AddTicks(6903), "", "Laptops" },
                    { 3, new DateTime(2024, 7, 18, 20, 57, 37, 167, DateTimeKind.Local).AddTicks(6908), "", "Electronics" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
