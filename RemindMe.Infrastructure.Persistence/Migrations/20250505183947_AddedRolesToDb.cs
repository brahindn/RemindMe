using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RemindMe.Application.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "identity",
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0936f344-48dc-42a9-b44e-9957fa530b80", null, "Administrator", "ADMINISTRATOR" },
                    { "5301bb12-cf21-4d25-924d-3aacae3f4d4a", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0936f344-48dc-42a9-b44e-9957fa530b80");

            migrationBuilder.DeleteData(
                schema: "identity",
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5301bb12-cf21-4d25-924d-3aacae3f4d4a");
        }
    }
}
