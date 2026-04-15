using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class SeedingShipping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Shippings",
                columns: new[] { "Id", "Price", "TypeOfShipping" },
                values: new object[,]
                {
                    { new Guid("30000001-0000-0000-0000-000000000000"), 49m, "Standard (3-7 business days)" },
                    { new Guid("30000002-0000-0000-0000-000000000000"), 129m, "Express (1-2 business days)" },
                    { new Guid("30000003-0000-0000-0000-000000000000"), 0m, "Store Pickup (same day)" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: new Guid("30000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: new Guid("30000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Shippings",
                keyColumn: "Id",
                keyValue: new Guid("30000003-0000-0000-0000-000000000000"));
        }
    }
}
