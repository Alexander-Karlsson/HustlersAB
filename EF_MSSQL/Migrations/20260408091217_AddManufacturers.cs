using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class AddManufacturers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ManufacturerId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Manufacturer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturer", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Manufacturer",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("20000001-0000-0000-0000-000000000000"), "Acer" },
                    { new Guid("20000002-0000-0000-0000-000000000000"), "Lenovo" },
                    { new Guid("20000003-0000-0000-0000-000000000000"), "ASUS" },
                    { new Guid("20000004-0000-0000-0000-000000000000"), "Dell" },
                    { new Guid("20000005-0000-0000-0000-000000000000"), "HP" },
                    { new Guid("20000006-0000-0000-0000-000000000000"), "Samsung" },
                    { new Guid("20000007-0000-0000-0000-000000000000"), "Apple" },
                    { new Guid("20000008-0000-0000-0000-000000000000"), "Google" },
                    { new Guid("20000009-0000-0000-0000-000000000000"), "OnePlus" },
                    { new Guid("20000010-0000-0000-0000-000000000000"), "MSI" },
                    { new Guid("20000011-0000-0000-0000-000000000000"), "LG" },
                    { new Guid("20000012-0000-0000-0000-000000000000"), "Logitech" },
                    { new Guid("20000013-0000-0000-0000-000000000000"), "Elgato" },
                    { new Guid("20000014-0000-0000-0000-000000000000"), "Spigen" },
                    { new Guid("20000015-0000-0000-0000-000000000000"), "Anker" },
                    { new Guid("20000016-0000-0000-0000-000000000000"), "Belkin" },
                    { new Guid("20000017-0000-0000-0000-000000000000"), "Sony" },
                    { new Guid("20000018-0000-0000-0000-000000000000"), "Philips" },
                    { new Guid("20000019-0000-0000-0000-000000000000"), "Bose" },
                    { new Guid("20000020-0000-0000-0000-000000000000"), "Jabra" },
                    { new Guid("20000021-0000-0000-0000-000000000000"), "Sennheiser" },
                    { new Guid("20000022-0000-0000-0000-000000000000"), "JBL" },
                    { new Guid("20000023-0000-0000-0000-000000000000"), "Sonos" },
                    { new Guid("20000024-0000-0000-0000-000000000000"), "Marshall" },
                    { new Guid("20000025-0000-0000-0000-000000000000"), "Nintendo" },
                    { new Guid("20000026-0000-0000-0000-000000000000"), "Razer" },
                    { new Guid("20000027-0000-0000-0000-000000000000"), "SteelSeries" },
                    { new Guid("20000028-0000-0000-0000-000000000000"), "Corsair" },
                    { new Guid("20000029-0000-0000-0000-000000000000"), "Garmin" },
                    { new Guid("20000030-0000-0000-0000-000000000000"), "Polar" },
                    { new Guid("20000031-0000-0000-0000-000000000000"), "Fitbit" },
                    { new Guid("20000032-0000-0000-0000-000000000000"), "Huawei" },
                    { new Guid("20000033-0000-0000-0000-000000000000"), "Bosch" },
                    { new Guid("20000034-0000-0000-0000-000000000000"), "Electrolux" },
                    { new Guid("20000035-0000-0000-0000-000000000000"), "Dyson" },
                    { new Guid("20000036-0000-0000-0000-000000000000"), "iRobot" },
                    { new Guid("20000037-0000-0000-0000-000000000000"), "Miele" },
                    { new Guid("20000038-0000-0000-0000-000000000000"), "IKEA" },
                    { new Guid("20000039-0000-0000-0000-000000000000"), "Nanoleaf" },
                    { new Guid("20000040-0000-0000-0000-000000000000"), "Govee" },
                    { new Guid("20000041-0000-0000-0000-000000000000"), "Ring" },
                    { new Guid("20000042-0000-0000-0000-000000000000"), "Arlo" },
                    { new Guid("20000043-0000-0000-0000-000000000000"), "Netatmo" },
                    { new Guid("20000044-0000-0000-0000-000000000000"), "Amazon" },
                    { new Guid("20000045-0000-0000-0000-000000000000"), "TP-Link" },
                    { new Guid("20000046-0000-0000-0000-000000000000"), "Eero" },
                    { new Guid("20000047-0000-0000-0000-000000000000"), "Netgear" },
                    { new Guid("20000048-0000-0000-0000-000000000000"), "Synology" },
                    { new Guid("20000049-0000-0000-0000-000000000000"), "Western Digital" },
                    { new Guid("20000050-0000-0000-0000-000000000000"), "SanDisk" },
                    { new Guid("20000051-0000-0000-0000-000000000000"), "CalDigit" },
                    { new Guid("20000052-0000-0000-0000-000000000000"), "GoPro" },
                    { new Guid("20000053-0000-0000-0000-000000000000"), "Xiaomi" },
                    { new Guid("20000054-0000-0000-0000-000000000000"), "Withings" },
                    { new Guid("20000055-0000-0000-0000-000000000000"), "Microsoft" },
                    { new Guid("20000056-0000-0000-0000-000000000000"), "EA" },
                    { new Guid("20000057-0000-0000-0000-000000000000"), "CD Projekt Red" },
                    { new Guid("20000058-0000-0000-0000-000000000000"), "Insomniac Games" },
                    { new Guid("20000059-0000-0000-0000-000000000000"), "Avalanche Software" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000001-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000001-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000002-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000002-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000003-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000003-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000004-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000004-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000005-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000005-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000006-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000005-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000007-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000004-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000008-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000002-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000009-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000003-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000010-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000010-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000011-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000011-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000012-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000004-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000013-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000014-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000012-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000015-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000012-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000016-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000013-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000017-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000018-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000007-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000019-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000008-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000020-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000021-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000009-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000022-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000007-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000023-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000024-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000002-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000025-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000014-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000026-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000015-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000027-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000016-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000028-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000029-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000011-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000030-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000017-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000031-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000018-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000032-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000017-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000033-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000019-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000034-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000020-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000035-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000021-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000036-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000022-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000037-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000023-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000038-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000024-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000039-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000017-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000040-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000055-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000041-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000025-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000042-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000056-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000043-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000059-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000044-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000025-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000045-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000057-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000046-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000058-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000047-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000026-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000048-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000012-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000049-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000027-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000050-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000028-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000051-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000007-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000052-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000053-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000029-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000054-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000032-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000055-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000029-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000056-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000030-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000057-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000031-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000058-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000007-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000059-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000060-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000017-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000061-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000033-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000062-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000063-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000034-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000064-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000065-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000033-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000066-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000011-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000067-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000035-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000068-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000036-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000069-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000037-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000070-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000018-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000071-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000038-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000072-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000039-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000073-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000040-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000074-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000041-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000075-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000042-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000076-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000043-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000077-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000044-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000078-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000008-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000079-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000007-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000080-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000003-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000081-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000045-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000082-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000046-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000083-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000047-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000084-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000048-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000085-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000049-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000086-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000006-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000087-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000050-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000088-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000051-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000089-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000015-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000090-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000016-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000091-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000007-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000092-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000012-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000093-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000011-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000094-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000019-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000095-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000052-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000096-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000053-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000097-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000054-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000098-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000013-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000099-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000045-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000100-0000-0000-0000-000000000000"),
                column: "ManufacturerId",
                value: new Guid("20000028-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products",
                column: "ManufacturerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Manufacturer_ManufacturerId",
                table: "Products",
                column: "ManufacturerId",
                principalTable: "Manufacturer",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Manufacturer_ManufacturerId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Manufacturer");

            migrationBuilder.DropIndex(
                name: "IX_Products_ManufacturerId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ManufacturerId",
                table: "Products");
        }
    }
}
