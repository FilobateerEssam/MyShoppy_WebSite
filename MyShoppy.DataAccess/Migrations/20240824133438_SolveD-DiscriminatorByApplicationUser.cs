﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyShoppy.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SolveDDiscriminatorByApplicationUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(13)",
                oldMaxLength: 13);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 16, 34, 37, 785, DateTimeKind.Local).AddTicks(3689));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 15, 16, 34, 37, 785, DateTimeKind.Local).AddTicks(3695));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 16, 16, 34, 37, 785, DateTimeKind.Local).AddTicks(3698));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "Users",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(21)",
                oldMaxLength: 21);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 14, 15, 57, 5, 957, DateTimeKind.Local).AddTicks(8078));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 15, 15, 57, 5, 957, DateTimeKind.Local).AddTicks(8083));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 8, 16, 15, 57, 5, 957, DateTimeKind.Local).AddTicks(8087));
        }
    }
}
