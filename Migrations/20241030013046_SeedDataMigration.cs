using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Assignment_2.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "Category", "DateAdded", "Email", "Organization", "Phone", "firstName", "lastName" },
                values: new object[,]
                {
                    { 29, "Other", new DateTime(2024, 10, 29, 19, 30, 45, 757, DateTimeKind.Local).AddTicks(8589), "leon.oiler@gmail.com", "Oilers", "2929292929", "Leon", "Draisaitl" },
                    { 97, "Other", new DateTime(2024, 10, 29, 19, 30, 45, 757, DateTimeKind.Local).AddTicks(8585), "connor.oiler@gmail.com", "Oilers", "9797979797", "Connor", "McDavid" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 97);
        }
    }
}
