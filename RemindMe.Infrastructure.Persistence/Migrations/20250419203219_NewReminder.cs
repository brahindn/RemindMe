using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RemindMe.Application.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewReminder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingTime",
                table: "Reminders",
                newName: "ScheduledAt");

            migrationBuilder.RenameColumn(
                name: "CreationTime",
                table: "Reminders",
                newName: "CreatedAt");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Reminders",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300);

            migrationBuilder.AddColumn<bool>(
                name: "IsSent",
                table: "Reminders",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Reminders",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TargetType",
                table: "Reminders",
                type: "text",
                nullable: false,
                defaultValue: "email");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Reminders",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Reminders",
                type: "timestamp with time zone",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSent",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "TargetType",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Reminders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Reminders");

            migrationBuilder.RenameColumn(
                name: "ScheduledAt",
                table: "Reminders",
                newName: "ShippingTime");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                table: "Reminders",
                newName: "CreationTime");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Reminders",
                type: "character varying(300)",
                maxLength: 300,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(300)",
                oldMaxLength: 300,
                oldNullable: true);
        }
    }
}
