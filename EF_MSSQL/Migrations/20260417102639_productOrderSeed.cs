using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class productOrderSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "IsMember", "Name" },
                values: new object[,]
                {
                    { new Guid("50000001-0000-0000-0000-000000000000"), true, "Anna Svensson" },
                    { new Guid("50000002-0000-0000-0000-000000000000"), false, "Johan Eriksson" },
                    { new Guid("50000003-0000-0000-0000-000000000000"), true, "Sara Nilsson" }
                });

            migrationBuilder.InsertData(
                table: "CustomerContactInfo",
                columns: new[] { "Id", "Address", "CustomerId", "Email", "Phone", "PostalNumber" },
                values: new object[,]
                {
                    { new Guid("51000001-0000-0000-0000-000000000000"), "Storgatan 1", new Guid("50000001-0000-0000-0000-000000000000"), "anna.svensson@example.com", "0701234567", "41110" },
                    { new Guid("51000002-0000-0000-0000-000000000000"), "Parkvägen 12", new Guid("50000002-0000-0000-0000-000000000000"), "johan.eriksson@example.com", "0702345678", "41755" },
                    { new Guid("51000003-0000-0000-0000-000000000000"), "Björkgatan 8", new Guid("50000003-0000-0000-0000-000000000000"), "sara.nilsson@example.com", "0703456789", "46130" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CustomerId", "OrderDate", "PaymentMethodId", "ShippingId", "TotalPrice" },
                values: new object[,]
                {
                    { new Guid("60000001-0000-0000-0000-000000000000"), new Guid("50000001-0000-0000-0000-000000000000"), new DateTime(2026, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40000001-0000-0000-0000-000000000000"), new Guid("30000001-0000-0000-0000-000000000000"), 9039m },
                    { new Guid("60000002-0000-0000-0000-000000000000"), new Guid("50000002-0000-0000-0000-000000000000"), new DateTime(2026, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40000003-0000-0000-0000-000000000000"), new Guid("30000002-0000-0000-0000-000000000000"), 12573m },
                    { new Guid("60000003-0000-0000-0000-000000000000"), new Guid("50000003-0000-0000-0000-000000000000"), new DateTime(2026, 4, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("40000002-0000-0000-0000-000000000000"), new Guid("30000003-0000-0000-0000-000000000000"), 4793m }
                });

            migrationBuilder.InsertData(
                table: "ProductOrders",
                columns: new[] { "Id", "OrderId", "ProductId", "Quantity" },
                values: new object[,]
                {
                    { new Guid("70000001-0000-0000-0000-000000000000"), new Guid("60000001-0000-0000-0000-000000000000"), new Guid("10000001-0000-0000-0000-000000000000"), 1 },
                    { new Guid("70000002-0000-0000-0000-000000000000"), new Guid("60000001-0000-0000-0000-000000000000"), new Guid("10000015-0000-0000-0000-000000000000"), 1 },
                    { new Guid("70000003-0000-0000-0000-000000000000"), new Guid("60000002-0000-0000-0000-000000000000"), new Guid("10000018-0000-0000-0000-000000000000"), 1 },
                    { new Guid("70000004-0000-0000-0000-000000000000"), new Guid("60000002-0000-0000-0000-000000000000"), new Guid("10000026-0000-0000-0000-000000000000"), 1 },
                    { new Guid("70000005-0000-0000-0000-000000000000"), new Guid("60000003-0000-0000-0000-000000000000"), new Guid("10000041-0000-0000-0000-000000000000"), 1 },
                    { new Guid("70000006-0000-0000-0000-000000000000"), new Guid("60000003-0000-0000-0000-000000000000"), new Guid("10000044-0000-0000-0000-000000000000"), 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CustomerContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("51000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "CustomerContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("51000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "CustomerContactInfo",
                keyColumn: "Id",
                keyValue: new Guid("51000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumn: "Id",
                keyValue: new Guid("70000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumn: "Id",
                keyValue: new Guid("70000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumn: "Id",
                keyValue: new Guid("70000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumn: "Id",
                keyValue: new Guid("70000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumn: "Id",
                keyValue: new Guid("70000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductOrders",
                keyColumn: "Id",
                keyValue: new Guid("70000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("60000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("60000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("60000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("50000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("50000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: new Guid("50000003-0000-0000-0000-000000000000"));
        }
    }
}
