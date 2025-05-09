using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemindMe.Application.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RefreshTokenColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "identity",
                table: "AspNetUsers",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                schema: "identity",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0936f344-48dc-42a9-b44e-9957fa530b80",
                column: "ConcurrencyStamp",
                value: "f6ea9ea8-3c3d-6f7f-c2d6-cba77fa5393d");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5301bb12-cf21-4d25-924d-3aacae3f4d4a",
                column: "ConcurrencyStamp",
                value: "5a32cbdc-da7a-ebfa-deaf-53df4ee326e0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "identity",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                schema: "identity",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0936f344-48dc-42a9-b44e-9957fa530b80",
                column: "ConcurrencyStamp",
                value: null);

            migrationBuilder.UpdateData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5301bb12-cf21-4d25-924d-3aacae3f4d4a",
                column: "ConcurrencyStamp",
                value: null);
        }
    }
}
