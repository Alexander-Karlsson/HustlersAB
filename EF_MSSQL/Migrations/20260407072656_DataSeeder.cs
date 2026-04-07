using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EF_MSSQL.Migrations
{
    /// <inheritdoc />
    public partial class DataSeeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("00000001-0000-0000-0000-000000000000"), "Datorer & Tillbehör" },
                    { new Guid("00000002-0000-0000-0000-000000000000"), "Telefoner & Surfplattor" },
                    { new Guid("00000003-0000-0000-0000-000000000000"), "TV & Ljud" },
                    { new Guid("00000004-0000-0000-0000-000000000000"), "Gaming" },
                    { new Guid("00000005-0000-0000-0000-000000000000"), "Wearables" },
                    { new Guid("00000006-0000-0000-0000-000000000000"), "Vitvaror" },
                    { new Guid("00000007-0000-0000-0000-000000000000"), "Smarta hem & IoT" },
                    { new Guid("00000008-0000-0000-0000-000000000000"), "Nätverk & Lagring" }
                });

            migrationBuilder.InsertData(
                table: "ProductSubCategories",
                columns: new[] { "Id", "Name", "ParentCategoryId" },
                values: new object[,]
                {
                    { new Guid("00000101-0000-0000-0000-000000000000"), "Laptops", new Guid("00000001-0000-0000-0000-000000000000") },
                    { new Guid("00000102-0000-0000-0000-000000000000"), "Stationära datorer", new Guid("00000001-0000-0000-0000-000000000000") },
                    { new Guid("00000103-0000-0000-0000-000000000000"), "Datorskärmar", new Guid("00000001-0000-0000-0000-000000000000") },
                    { new Guid("00000104-0000-0000-0000-000000000000"), "Datortillbehör", new Guid("00000001-0000-0000-0000-000000000000") },
                    { new Guid("00000201-0000-0000-0000-000000000000"), "Smartphones", new Guid("00000002-0000-0000-0000-000000000000") },
                    { new Guid("00000202-0000-0000-0000-000000000000"), "Surfplattor", new Guid("00000002-0000-0000-0000-000000000000") },
                    { new Guid("00000203-0000-0000-0000-000000000000"), "Mobilskal & Tillbehör", new Guid("00000002-0000-0000-0000-000000000000") },
                    { new Guid("00000301-0000-0000-0000-000000000000"), "TV-apparater", new Guid("00000003-0000-0000-0000-000000000000") },
                    { new Guid("00000302-0000-0000-0000-000000000000"), "Hörlurar", new Guid("00000003-0000-0000-0000-000000000000") },
                    { new Guid("00000303-0000-0000-0000-000000000000"), "Högtalare", new Guid("00000003-0000-0000-0000-000000000000") },
                    { new Guid("00000401-0000-0000-0000-000000000000"), "Spelkonsoler", new Guid("00000004-0000-0000-0000-000000000000") },
                    { new Guid("00000402-0000-0000-0000-000000000000"), "Spel", new Guid("00000004-0000-0000-0000-000000000000") },
                    { new Guid("00000403-0000-0000-0000-000000000000"), "Gaming-tillbehör", new Guid("00000004-0000-0000-0000-000000000000") },
                    { new Guid("00000501-0000-0000-0000-000000000000"), "Smartwatches", new Guid("00000005-0000-0000-0000-000000000000") },
                    { new Guid("00000502-0000-0000-0000-000000000000"), "Träningsklockor", new Guid("00000005-0000-0000-0000-000000000000") },
                    { new Guid("00000503-0000-0000-0000-000000000000"), "Trådlösa earbuds", new Guid("00000005-0000-0000-0000-000000000000") },
                    { new Guid("00000601-0000-0000-0000-000000000000"), "Tvättmaskiner", new Guid("00000006-0000-0000-0000-000000000000") },
                    { new Guid("00000602-0000-0000-0000-000000000000"), "Kylskåp & Frysar", new Guid("00000006-0000-0000-0000-000000000000") },
                    { new Guid("00000603-0000-0000-0000-000000000000"), "Dammsugare", new Guid("00000006-0000-0000-0000-000000000000") },
                    { new Guid("00000701-0000-0000-0000-000000000000"), "Smart belysning", new Guid("00000007-0000-0000-0000-000000000000") },
                    { new Guid("00000702-0000-0000-0000-000000000000"), "Säkerhet & Kameror", new Guid("00000007-0000-0000-0000-000000000000") },
                    { new Guid("00000703-0000-0000-0000-000000000000"), "Smarta assistenter", new Guid("00000007-0000-0000-0000-000000000000") },
                    { new Guid("00000801-0000-0000-0000-000000000000"), "Routrar & Mesh", new Guid("00000008-0000-0000-0000-000000000000") },
                    { new Guid("00000802-0000-0000-0000-000000000000"), "NAS & Extern lagring", new Guid("00000008-0000-0000-0000-000000000000") },
                    { new Guid("00000803-0000-0000-0000-000000000000"), "USB-hubbar & Dockningar", new Guid("00000008-0000-0000-0000-000000000000") }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Description", "Name", "Price", "QtyInStock", "SubCategoryId" },
                values: new object[,]
                {
                    { new Guid("10000001-0000-0000-0000-000000000000"), "Pålitlig vardagslaptop med Intel Core i5 och 16GB RAM.", "Acer Aspire 15\"", 7995m, 18, new Guid("00000101-0000-0000-0000-000000000000") },
                    { new Guid("10000002-0000-0000-0000-000000000000"), "Affärslaptop med robust byggkvalitet och lång batteritid.", "Lenovo ThinkPad E14", 9495m, 12, new Guid("00000101-0000-0000-0000-000000000000") },
                    { new Guid("10000003-0000-0000-0000-000000000000"), "Kompakt och lättviktig laptop för studenter.", "ASUS VivoBook 14\"", 6495m, 22, new Guid("00000101-0000-0000-0000-000000000000") },
                    { new Guid("10000004-0000-0000-0000-000000000000"), "Premium laptop med OLED-skärm och Intel Core i7.", "Dell XPS 15\"", 16995m, 7, new Guid("00000101-0000-0000-0000-000000000000") },
                    { new Guid("10000005-0000-0000-0000-000000000000"), "Konvertibel 2-i-1 laptop med pekskärm och stylus.", "HP Spectre x360 14\"", 14495m, 9, new Guid("00000101-0000-0000-0000-000000000000") },
                    { new Guid("10000006-0000-0000-0000-000000000000"), "Kompakt stationär dator med Intel Core i5 och 512GB SSD.", "HP Pavilion Desktop", 8995m, 10, new Guid("00000102-0000-0000-0000-000000000000") },
                    { new Guid("10000007-0000-0000-0000-000000000000"), "Affärsdator med hög prestanda och energieffektivitet.", "Dell OptiPlex 7000", 11495m, 6, new Guid("00000102-0000-0000-0000-000000000000") },
                    { new Guid("10000008-0000-0000-0000-000000000000"), "Stilren stationär dator för hem och kontor.", "Lenovo IdeaCentre 5", 7495m, 14, new Guid("00000102-0000-0000-0000-000000000000") },
                    { new Guid("10000009-0000-0000-0000-000000000000"), "Kraftfull gaming-desktop med RTX 4070 och 32GB RAM.", "ASUS ROG Strix G15", 19995m, 5, new Guid("00000102-0000-0000-0000-000000000000") },
                    { new Guid("10000010-0000-0000-0000-000000000000"), "27-tums QHD-skärm med 165Hz och 1ms responstid.", "MSI MAG 27\" QHD", 4295m, 15, new Guid("00000103-0000-0000-0000-000000000000") },
                    { new Guid("10000011-0000-0000-0000-000000000000"), "Ultravid 34-tums skärm med IPS-panel och USB-C.", "LG UltraWide 34\"", 5995m, 9, new Guid("00000103-0000-0000-0000-000000000000") },
                    { new Guid("10000012-0000-0000-0000-000000000000"), "Professionell 4K-skärm med exceptionell färgåtergivning.", "Dell UltraSharp 27\" 4K", 7495m, 8, new Guid("00000103-0000-0000-0000-000000000000") },
                    { new Guid("10000013-0000-0000-0000-000000000000"), "Böjd VA-skärm med 144Hz för en uppslukande upplevelse.", "Samsung 32\" Curved", 3795m, 11, new Guid("00000103-0000-0000-0000-000000000000") },
                    { new Guid("10000014-0000-0000-0000-000000000000"), "Trådlöst tangentbord med bakgrundsbelysning och multienhetspar.", "Logitech MX Keys", 1195m, 25, new Guid("00000104-0000-0000-0000-000000000000") },
                    { new Guid("10000015-0000-0000-0000-000000000000"), "Ergonomisk trådlös mus med precision scroll och tyst klick.", "Logitech MX Master 3S", 995m, 30, new Guid("00000104-0000-0000-0000-000000000000") },
                    { new Guid("10000016-0000-0000-0000-000000000000"), "15-knappars LCD-kontroller för streamers och kreatörer.", "Elgato Stream Deck MK.2", 1595m, 12, new Guid("00000104-0000-0000-0000-000000000000") },
                    { new Guid("10000017-0000-0000-0000-000000000000"), "Flaggskepp med AI-funktioner, 50MP kamera och 120Hz AMOLED.", "Samsung Galaxy S24", 9995m, 25, new Guid("00000201-0000-0000-0000-000000000000") },
                    { new Guid("10000018-0000-0000-0000-000000000000"), "Apple iPhone 15 med Dynamic Island och USB-C.", "iPhone 15", 11995m, 20, new Guid("00000201-0000-0000-0000-000000000000") },
                    { new Guid("10000019-0000-0000-0000-000000000000"), "Ren Android-upplevelse med exceptionell kameramjukvara.", "Google Pixel 8", 8495m, 14, new Guid("00000201-0000-0000-0000-000000000000") },
                    { new Guid("10000020-0000-0000-0000-000000000000"), "Mellanklass med premiumkänsla, 5G och 50MP kamera.", "Samsung Galaxy A55", 4995m, 30, new Guid("00000201-0000-0000-0000-000000000000") },
                    { new Guid("10000021-0000-0000-0000-000000000000"), "Snabb laddning 100W, Snapdragon 8 Gen 3 och Hasselblad-kamera.", "OnePlus 12", 8995m, 16, new Guid("00000201-0000-0000-0000-000000000000") },
                    { new Guid("10000022-0000-0000-0000-000000000000"), "Allsidig surfplatta med A14 Bionic och USB-C.", "iPad 10:e gen", 5495m, 18, new Guid("00000202-0000-0000-0000-000000000000") },
                    { new Guid("10000023-0000-0000-0000-000000000000"), "Android-surfplatta med AMOLED-skärm och S Pen.", "Samsung Galaxy Tab S9", 7995m, 11, new Guid("00000202-0000-0000-0000-000000000000") },
                    { new Guid("10000024-0000-0000-0000-000000000000"), "12.6-tums AMOLED-surfplatta med Snapdragon 870.", "Lenovo Tab P12 Pro", 6495m, 9, new Guid("00000202-0000-0000-0000-000000000000") },
                    { new Guid("10000025-0000-0000-0000-000000000000"), "Stöttåligt skal med Air Cushion Technology.", "Spigen Tough Armor iPhone 15", 299m, 80, new Guid("00000203-0000-0000-0000-000000000000") },
                    { new Guid("10000026-0000-0000-0000-000000000000"), "Kompakt GaN-laddare med 65W och stöd för tre enheter.", "Anker USB-C Snabbladdare 65W", 449m, 60, new Guid("00000203-0000-0000-0000-000000000000") },
                    { new Guid("10000027-0000-0000-0000-000000000000"), "Magnetiskt skal med inbyggd plånbok för iPhone 15.", "Belkin MagSafe Plånboksskal", 399m, 45, new Guid("00000203-0000-0000-0000-000000000000") },
                    { new Guid("10000028-0000-0000-0000-000000000000"), "QLED med Quantum HDR och 120Hz för sport och gaming.", "Samsung 65\" QLED 4K", 14995m, 8, new Guid("00000301-0000-0000-0000-000000000000") },
                    { new Guid("10000029-0000-0000-0000-000000000000"), "Prisbelönt OLED-TV med perfekta svärtor och Dolby Vision.", "LG OLED 55\" C3", 17995m, 5, new Guid("00000301-0000-0000-0000-000000000000") },
                    { new Guid("10000030-0000-0000-0000-000000000000"), "Google TV med Cognitive Processor XR och Dolby Atmos.", "Sony Bravia 50\" 4K", 8995m, 12, new Guid("00000301-0000-0000-0000-000000000000") },
                    { new Guid("10000031-0000-0000-0000-000000000000"), "4K TV med unikt Ambilight-system för immersiv upplevelse.", "Philips 43\" Ambilight", 6495m, 10, new Guid("00000301-0000-0000-0000-000000000000") },
                    { new Guid("10000032-0000-0000-0000-000000000000"), "Branschledande brusreducering med 30h batteritid.", "Sony WH-1000XM5", 3495m, 20, new Guid("00000302-0000-0000-0000-000000000000") },
                    { new Guid("10000033-0000-0000-0000-000000000000"), "Komfortabla over-ear med TriPort-akustik och ANC.", "Bose QuietComfort 45", 3295m, 15, new Guid("00000302-0000-0000-0000-000000000000") },
                    { new Guid("10000034-0000-0000-0000-000000000000"), "Professionella kontorshörlurar med hybridANC och Teams-cert.", "Jabra Evolve2 55", 4195m, 10, new Guid("00000302-0000-0000-0000-000000000000") },
                    { new Guid("10000035-0000-0000-0000-000000000000"), "Trådlösa over-ear med aktiv brusreducering och 30h batteri.", "Sennheiser HD 450BT", 1695m, 18, new Guid("00000302-0000-0000-0000-000000000000") },
                    { new Guid("10000036-0000-0000-0000-000000000000"), "Vattentät Bluetooth-högtalare med 20h batteritid.", "JBL Charge 5", 1595m, 30, new Guid("00000303-0000-0000-0000-000000000000") },
                    { new Guid("10000037-0000-0000-0000-000000000000"), "Smart WiFi-högtalare med stereopar-stöd och Trueplay.", "Sonos Era 100", 3295m, 14, new Guid("00000303-0000-0000-0000-000000000000") },
                    { new Guid("10000038-0000-0000-0000-000000000000"), "Ikonisk design med kraftfullt ljud och Bluetooth 5.2.", "Marshall Stanmore III", 4495m, 8, new Guid("00000303-0000-0000-0000-000000000000") },
                    { new Guid("10000039-0000-0000-0000-000000000000"), "Next-gen konsol med SSD, haptic feedback och 4K gaming.", "PlayStation 5", 6495m, 15, new Guid("00000401-0000-0000-0000-000000000000") },
                    { new Guid("10000040-0000-0000-0000-000000000000"), "Kraftfullaste Xbox någonsin med 12 teraflops och Game Pass.", "Xbox Series X", 5995m, 13, new Guid("00000401-0000-0000-0000-000000000000") },
                    { new Guid("10000041-0000-0000-0000-000000000000"), "Hybrid-konsol med 7-tums OLED-skärm och förbättrad ljud.", "Nintendo Switch OLED", 3595m, 22, new Guid("00000401-0000-0000-0000-000000000000") },
                    { new Guid("10000042-0000-0000-0000-000000000000"), "Årets fotbollsspel med HyperMotion V-teknologi.", "EA Sports FC 25 PS5", 699m, 40, new Guid("00000402-0000-0000-0000-000000000000") },
                    { new Guid("10000043-0000-0000-0000-000000000000"), "Upplev det magiska Hogwarts i ett öppet rollspel.", "Hogwarts Legacy Xbox", 549m, 35, new Guid("00000402-0000-0000-0000-000000000000") },
                    { new Guid("10000044-0000-0000-0000-000000000000"), "Episkt äventyr i Hyrule för Nintendo Switch.", "Zelda: Tears of the Kingdom", 599m, 28, new Guid("00000402-0000-0000-0000-000000000000") },
                    { new Guid("10000045-0000-0000-0000-000000000000"), "Öppen värld i Night City – nu med Phantom Liberty-expansion.", "Cyberpunk 2077 PC", 399m, 50, new Guid("00000402-0000-0000-0000-000000000000") },
                    { new Guid("10000046-0000-0000-0000-000000000000"), "Sväng runt Manhattan som Peter Parker och Miles Morales.", "Spider-Man 2 PS5", 699m, 32, new Guid("00000402-0000-0000-0000-000000000000") },
                    { new Guid("10000047-0000-0000-0000-000000000000"), "Mekaniskt tangentbord med Razer Green-switchar och RGB.", "Razer BlackWidow V3", 1295m, 18, new Guid("00000403-0000-0000-0000-000000000000") },
                    { new Guid("10000048-0000-0000-0000-000000000000"), "Trådlös gaming-mus med LIGHTFORCE-switchar och 130h batteri.", "Logitech G502 X Plus", 1195m, 24, new Guid("00000403-0000-0000-0000-000000000000") },
                    { new Guid("10000049-0000-0000-0000-000000000000"), "Trådlöst headset med 38h batteritid och ClearCast AI-mikrofon.", "SteelSeries Arctis Nova 7", 1995m, 16, new Guid("00000403-0000-0000-0000-000000000000") },
                    { new Guid("10000050-0000-0000-0000-000000000000"), "Mekaniskt tangentbord med Cherry MX-switchar och USB-passthrough.", "Corsair K70 RGB Pro", 1495m, 12, new Guid("00000403-0000-0000-0000-000000000000") },
                    { new Guid("10000051-0000-0000-0000-000000000000"), "Double Tap-gest, S9-chip och Always-On Retina-display.", "Apple Watch Series 9", 4995m, 20, new Guid("00000501-0000-0000-0000-000000000000") },
                    { new Guid("10000052-0000-0000-0000-000000000000"), "Avancerad hälsomätning med BioActive Sensor och sleep coaching.", "Samsung Galaxy Watch 6", 3495m, 15, new Guid("00000501-0000-0000-0000-000000000000") },
                    { new Guid("10000053-0000-0000-0000-000000000000"), "Premiumsmartwatch med AMOLED och avancerad sömn-analys.", "Garmin Venu 3", 4195m, 10, new Guid("00000501-0000-0000-0000-000000000000") },
                    { new Guid("10000054-0000-0000-0000-000000000000"), "Elegant design med 14 dagars batteritid och GPS.", "Huawei Watch GT 4", 2695m, 13, new Guid("00000501-0000-0000-0000-000000000000") },
                    { new Guid("10000055-0000-0000-0000-000000000000"), "Löparklocka med AMOLED, Training Readiness och HRV Status.", "Garmin Forerunner 265", 4495m, 12, new Guid("00000502-0000-0000-0000-000000000000") },
                    { new Guid("10000056-0000-0000-0000-000000000000"), "Multisportklocka med EKG, optisk puls och SWR-sensor.", "Polar Vantage V3", 6495m, 7, new Guid("00000502-0000-0000-0000-000000000000") },
                    { new Guid("10000057-0000-0000-0000-000000000000"), "Aktivitetsarmband med Google Maps, ECG och stress-hantering.", "Fitbit Charge 6", 1695m, 22, new Guid("00000502-0000-0000-0000-000000000000") },
                    { new Guid("10000058-0000-0000-0000-000000000000"), "Adaptiv ljudavstängning, Personalized Spatial Audio och H2-chip.", "Apple AirPods Pro 2", 2995m, 25, new Guid("00000503-0000-0000-0000-000000000000") },
                    { new Guid("10000059-0000-0000-0000-000000000000"), "Hi-Fi 24-bitars ljud med intelligent ANC och IPX7.", "Samsung Galaxy Buds2 Pro", 1995m, 20, new Guid("00000503-0000-0000-0000-000000000000") },
                    { new Guid("10000060-0000-0000-0000-000000000000"), "Världens bästa ANC i ett kompakt format med 8h batteritid.", "Sony WF-1000XM5", 2795m, 18, new Guid("00000503-0000-0000-0000-000000000000") },
                    { new Guid("10000061-0000-0000-0000-000000000000"), "Frontmatad tvättmaskin 9kg med EcoSilence Drive och WiFi.", "Bosch Serie 6 WGG14204S", 8995m, 6, new Guid("00000601-0000-0000-0000-000000000000") },
                    { new Guid("10000062-0000-0000-0000-000000000000"), "EcoBubble-teknologi 9kg med AI Control och ångfunktion.", "Samsung WW90T684DLE", 7495m, 8, new Guid("00000601-0000-0000-0000-000000000000") },
                    { new Guid("10000063-0000-0000-0000-000000000000"), "Tvättmaskin med SteamCare och UltraMix för skonsam tvätt.", "Electrolux PerfectCare 700", 6995m, 7, new Guid("00000601-0000-0000-0000-000000000000") },
                    { new Guid("10000064-0000-0000-0000-000000000000"), "Fransk dörr-kylskåp med SpaceMax och Twin Cooling Plus.", "Samsung Side-by-Side RS68", 14995m, 4, new Guid("00000602-0000-0000-0000-000000000000") },
                    { new Guid("10000065-0000-0000-0000-000000000000"), "NoFrost-kylskåp med FreshSense och VitaFresh-låda.", "Bosch KGN39AIAT", 9495m, 6, new Guid("00000602-0000-0000-0000-000000000000") },
                    { new Guid("10000066-0000-0000-0000-000000000000"), "Total No Frost-kylskåp med DoorCooling+ och WiFi.", "LG GBB62PZGFN", 8495m, 7, new Guid("00000602-0000-0000-0000-000000000000") },
                    { new Guid("10000067-0000-0000-0000-000000000000"), "Laser-detektering av damm, HEPA-filtrering och 60min drift.", "Dyson V15 Detect", 6995m, 10, new Guid("00000603-0000-0000-0000-000000000000") },
                    { new Guid("10000068-0000-0000-0000-000000000000"), "Robotdammsugare med auto-tömning och moppfunktion.", "Roomba Combo j9+", 8995m, 8, new Guid("00000603-0000-0000-0000-000000000000") },
                    { new Guid("10000069-0000-0000-0000-000000000000"), "Tredelad design, VARTA-batteri och 60min körtid.", "Miele Triflex HX2 Pro", 5995m, 9, new Guid("00000603-0000-0000-0000-000000000000") },
                    { new Guid("10000070-0000-0000-0000-000000000000"), "3 smarta glödlampor med Hue Bridge och 16M färger.", "Philips Hue Starterkit E27", 1295m, 25, new Guid("00000701-0000-0000-0000-000000000000") },
                    { new Guid("10000071-0000-0000-0000-000000000000"), "Prisvärt smart belysningssystem med dimmer och gateway.", "IKEA TRÅDFRI Startpaket", 599m, 35, new Guid("00000701-0000-0000-0000-000000000000") },
                    { new Guid("10000072-0000-0000-0000-000000000000"), "Modulära LED-linjer med musik-reaktivitet och Touch Control.", "Nanoleaf Lines Starter", 1995m, 15, new Guid("00000701-0000-0000-0000-000000000000") },
                    { new Guid("10000073-0000-0000-0000-000000000000"), "RGBIC neontejp med app-kontroll och musik-synkronisering.", "Govee Neon Rope Light 3m", 799m, 20, new Guid("00000701-0000-0000-0000-000000000000") },
                    { new Guid("10000074-0000-0000-0000-000000000000"), "3D Motion Detection, Bird's Eye View och 1536p HD-video.", "Ring Video Doorbell Pro 2", 2995m, 12, new Guid("00000702-0000-0000-0000-000000000000") },
                    { new Guid("10000075-0000-0000-0000-000000000000"), "2K HDR, färg-nattseende och 6 månaders batteritid.", "Arlo Pro 5S utomhuskamera", 2495m, 10, new Guid("00000702-0000-0000-0000-000000000000") },
                    { new Guid("10000076-0000-0000-0000-000000000000"), "Modulärt larmsystem med inomhuskamera och rörelsedetektering.", "Netatmo Smart Alarm System", 3495m, 7, new Guid("00000702-0000-0000-0000-000000000000") },
                    { new Guid("10000077-0000-0000-0000-000000000000"), "Kompakt smart högtalare med Alexa och förbättrat ljud.", "Amazon Echo Dot 5th gen", 499m, 40, new Guid("00000703-0000-0000-0000-000000000000") },
                    { new Guid("10000078-0000-0000-0000-000000000000"), "Smart skärm med Google Assistant och sömnspårning.", "Google Nest Hub 2nd gen", 999m, 25, new Guid("00000703-0000-0000-0000-000000000000") },
                    { new Guid("10000079-0000-0000-0000-000000000000"), "360-graders ljud, Siri och smarthemshub i ett kompakt format.", "Apple HomePod mini", 1095m, 20, new Guid("00000703-0000-0000-0000-000000000000") },
                    { new Guid("10000080-0000-0000-0000-000000000000"), "WiFi 6E Mesh-system med tri-band och 10Gbps WAN/LAN.", "ASUS ZenWiFi Pro ET12", 8995m, 6, new Guid("00000801-0000-0000-0000-000000000000") },
                    { new Guid("10000081-0000-0000-0000-000000000000"), "WiFi 6E Mesh 3-pack med EasyMesh och föräldrakontroll.", "TP-Link Deco XE75 Pro", 4995m, 9, new Guid("00000801-0000-0000-0000-000000000000") },
                    { new Guid("10000082-0000-0000-0000-000000000000"), "Amazon Mesh-system med Zigbee-hubb och enkel app-setup.", "Eero Pro 6E 3-pack", 5495m, 8, new Guid("00000801-0000-0000-0000-000000000000") },
                    { new Guid("10000083-0000-0000-0000-000000000000"), "WiFi 6 Mesh med 6Gbps total bandbredd och 6 enheter.", "Netgear Orbi RBK863S", 6995m, 5, new Guid("00000801-0000-0000-0000-000000000000") },
                    { new Guid("10000084-0000-0000-0000-000000000000"), "Kompakt 2-bays NAS med DiskStation Manager och RAID.", "Synology DS223", 3295m, 8, new Guid("00000802-0000-0000-0000-000000000000") },
                    { new Guid("10000085-0000-0000-0000-000000000000"), "2-bay NAS med 8TB och automatisk moln-backup.", "WD My Cloud EX2 Ultra", 4495m, 6, new Guid("00000802-0000-0000-0000-000000000000") },
                    { new Guid("10000086-0000-0000-0000-000000000000"), "Robust portabel SSD med USB 3.2 Gen2 och IP65-klassning.", "Samsung T7 Shield 2TB", 1195m, 20, new Guid("00000802-0000-0000-0000-000000000000") },
                    { new Guid("10000087-0000-0000-0000-000000000000"), "Portabel NVMe SSD med 2000MB/s och drop-skydd.", "SanDisk Extreme Pro 4TB", 1895m, 15, new Guid("00000802-0000-0000-0000-000000000000") },
                    { new Guid("10000088-0000-0000-0000-000000000000"), "18 portar inkl. 2x Thunderbolt 4, 2x USB-A och 2.5GbE.", "CalDigit TS4 Thunderbolt 4", 4295m, 7, new Guid("00000803-0000-0000-0000-000000000000") },
                    { new Guid("10000089-0000-0000-0000-000000000000"), "13-i-1 dockningsstation med 85W laddning och dual 4K.", "Anker 575 USB-C Docking", 1995m, 12, new Guid("00000803-0000-0000-0000-000000000000") },
                    { new Guid("10000090-0000-0000-0000-000000000000"), "Kompakt hub med HDMI 4K, SD-kortläsare och 100W PD.", "Belkin Connect USB-C 11-i-1", 1295m, 18, new Guid("00000803-0000-0000-0000-000000000000") },
                    { new Guid("10000091-0000-0000-0000-000000000000"), "Kraftfull pro-surfplatta med M2-chip, Liquid Retina XDR och 5G.", "iPad Pro 12.9\" M2", 13995m, 8, new Guid("00000202-0000-0000-0000-000000000000") },
                    { new Guid("10000092-0000-0000-0000-000000000000"), "Ultralätt trådlös gaming-mus med HERO 25K-sensor.", "Logitech G Pro X Superlight", 1595m, 14, new Guid("00000403-0000-0000-0000-000000000000") },
                    { new Guid("10000093-0000-0000-0000-000000000000"), "USB-C 4K-skärm optimerad för Mac med 96W laddning.", "LG 27\" 4K UltraFine", 6495m, 8, new Guid("00000103-0000-0000-0000-000000000000") },
                    { new Guid("10000094-0000-0000-0000-000000000000"), "Stor portabel högtalare med PartyMode och 20h batteritid.", "Bose SoundLink Max", 4495m, 10, new Guid("00000303-0000-0000-0000-000000000000") },
                    { new Guid("10000095-0000-0000-0000-000000000000"), "5.3K video, HyperSmooth 6.0 och vattentät till 10m.", "GoPro Hero 12 Black", 4995m, 12, new Guid("00000104-0000-0000-0000-000000000000") },
                    { new Guid("10000096-0000-0000-0000-000000000000"), "Robotdammsugare med laser-navigering och moppfunktion.", "Xiaomi Robot Vacuum S20+", 4495m, 10, new Guid("00000603-0000-0000-0000-000000000000") },
                    { new Guid("10000097-0000-0000-0000-000000000000"), "Hybridklocka med EKG, SpO2 och 30 dagars batteritid.", "Withings ScanWatch 2", 3495m, 9, new Guid("00000501-0000-0000-0000-000000000000") },
                    { new Guid("10000098-0000-0000-0000-000000000000"), "Capture card med 4K60 HDR10 och VRR-stöd.", "Elgato 4K60 Pro MK.2", 2495m, 8, new Guid("00000403-0000-0000-0000-000000000000") },
                    { new Guid("10000099-0000-0000-0000-000000000000"), "Utomhuskamera 4MP med ColorPro Night Vision och AI-detektion.", "TP-Link Tapo C320WS", 595m, 25, new Guid("00000702-0000-0000-0000-000000000000") },
                    { new Guid("10000100-0000-0000-0000-000000000000"), "PCIe 4.0 SSD med 7000MB/s läshastighet och aluminium heatsink.", "Corsair MP600 Pro 2TB NVMe", 2195m, 14, new Guid("00000802-0000-0000-0000-000000000000") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000008-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000009-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000010-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000011-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000012-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000013-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000014-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000015-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000016-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000017-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000018-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000019-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000020-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000021-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000022-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000023-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000024-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000025-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000026-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000027-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000028-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000029-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000030-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000031-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000032-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000033-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000034-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000035-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000036-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000037-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000038-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000039-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000040-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000041-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000042-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000043-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000044-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000045-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000046-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000047-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000048-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000049-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000050-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000051-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000052-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000053-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000054-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000055-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000056-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000057-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000058-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000059-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000060-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000061-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000062-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000063-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000064-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000065-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000066-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000067-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000068-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000069-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000070-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000071-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000072-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000073-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000074-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000075-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000076-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000077-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000078-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000079-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000080-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000081-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000082-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000083-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000084-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000085-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000086-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000087-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000088-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000089-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000090-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000091-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000092-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000093-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000094-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000095-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000096-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000097-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000098-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000099-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: new Guid("10000100-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000101-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000102-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000103-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000104-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000201-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000202-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000203-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000301-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000302-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000303-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000401-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000402-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000403-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000501-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000502-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000503-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000601-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000602-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000603-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000701-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000702-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000703-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000801-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000802-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductSubCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000803-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000001-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000002-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000003-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000004-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000005-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000006-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000007-0000-0000-0000-000000000000"));

            migrationBuilder.DeleteData(
                table: "ProductCategories",
                keyColumn: "Id",
                keyValue: new Guid("00000008-0000-0000-0000-000000000000"));
        }
    }
}
