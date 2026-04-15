using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class FortfarandePåSvenska : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "Id", "PaymentName" },
                values: new object[,]
                {
                    { new Guid("40000001-0000-0000-0000-000000000000"), "Kort (Visa/Mastercard)" },
                    { new Guid("40000002-0000-0000-0000-000000000000"), "Faktura" },
                    { new Guid("40000003-0000-0000-0000-000000000000"), "Swish" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("40000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("40000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "PaymentMethods",
                keyColumn: "Id",
                keyValue: new Guid("40000003-0000-0000-0000-000000000000"));
        }
    }
}
