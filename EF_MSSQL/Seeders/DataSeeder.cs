using Entities;
using Microsoft.EntityFrameworkCore;

namespace EF_MSSQL.Seeders;

public static class DataSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        // ──────────────────────────────────────────────
        // KATEGORIER
        // ──────────────────────────────────────────────

        var catDatorer   = new ProductCategory { Id = Guid.Parse("00000001-0000-0000-0000-000000000000"), Name = "Datorer & Tillbehör" };
        var catTelefoner = new ProductCategory { Id = Guid.Parse("00000002-0000-0000-0000-000000000000"), Name = "Telefoner & Surfplattor" };
        var catTvLjud    = new ProductCategory { Id = Guid.Parse("00000003-0000-0000-0000-000000000000"), Name = "TV & Ljud" };
        var catGaming    = new ProductCategory { Id = Guid.Parse("00000004-0000-0000-0000-000000000000"), Name = "Gaming" };
        var catWearables = new ProductCategory { Id = Guid.Parse("00000005-0000-0000-0000-000000000000"), Name = "Wearables" };
        var catVitvaror  = new ProductCategory { Id = Guid.Parse("00000006-0000-0000-0000-000000000000"), Name = "Vitvaror" };
        var catSmartaHem = new ProductCategory { Id = Guid.Parse("00000007-0000-0000-0000-000000000000"), Name = "Smarta hem & IoT" };
        var catNatverk   = new ProductCategory { Id = Guid.Parse("00000008-0000-0000-0000-000000000000"), Name = "Nätverk & Lagring" };

        modelBuilder.Entity<ProductCategory>().HasData(
            catDatorer, catTelefoner, catTvLjud, catGaming,
            catWearables, catVitvaror, catSmartaHem, catNatverk
        );

        // ──────────────────────────────────────────────
        // SUBKATEGORIER
        // ──────────────────────────────────────────────

        var subLaptops         = new ProductSubCategory { Id = Guid.Parse("00000101-0000-0000-0000-000000000000"), Name = "Laptops",               ParentCategoryId = catDatorer.Id };
        var subStationara      = new ProductSubCategory { Id = Guid.Parse("00000102-0000-0000-0000-000000000000"), Name = "Stationära datorer",     ParentCategoryId = catDatorer.Id };
        var subSkarmar         = new ProductSubCategory { Id = Guid.Parse("00000103-0000-0000-0000-000000000000"), Name = "Datorskärmar",            ParentCategoryId = catDatorer.Id };
        var subTillbehorDator  = new ProductSubCategory { Id = Guid.Parse("00000104-0000-0000-0000-000000000000"), Name = "Datortillbehör",          ParentCategoryId = catDatorer.Id };
        var subSmartphones     = new ProductSubCategory { Id = Guid.Parse("00000201-0000-0000-0000-000000000000"), Name = "Smartphones",             ParentCategoryId = catTelefoner.Id };
        var subSurfplattor     = new ProductSubCategory { Id = Guid.Parse("00000202-0000-0000-0000-000000000000"), Name = "Surfplattor",              ParentCategoryId = catTelefoner.Id };
        var subMobilTillbehor  = new ProductSubCategory { Id = Guid.Parse("00000203-0000-0000-0000-000000000000"), Name = "Mobilskal & Tillbehör",   ParentCategoryId = catTelefoner.Id };
        var subTv              = new ProductSubCategory { Id = Guid.Parse("00000301-0000-0000-0000-000000000000"), Name = "TV-apparater",             ParentCategoryId = catTvLjud.Id };
        var subHorlurar        = new ProductSubCategory { Id = Guid.Parse("00000302-0000-0000-0000-000000000000"), Name = "Hörlurar",                 ParentCategoryId = catTvLjud.Id };
        var subHogtalare       = new ProductSubCategory { Id = Guid.Parse("00000303-0000-0000-0000-000000000000"), Name = "Högtalare",                ParentCategoryId = catTvLjud.Id };
        var subKonsoler        = new ProductSubCategory { Id = Guid.Parse("00000401-0000-0000-0000-000000000000"), Name = "Spelkonsoler",             ParentCategoryId = catGaming.Id };
        var subSpel            = new ProductSubCategory { Id = Guid.Parse("00000402-0000-0000-0000-000000000000"), Name = "Spel",                     ParentCategoryId = catGaming.Id };
        var subGamingTillbehor = new ProductSubCategory { Id = Guid.Parse("00000403-0000-0000-0000-000000000000"), Name = "Gaming-tillbehör",         ParentCategoryId = catGaming.Id };
        var subSmartwatch      = new ProductSubCategory { Id = Guid.Parse("00000501-0000-0000-0000-000000000000"), Name = "Smartwatches",             ParentCategoryId = catWearables.Id };
        var subTraning         = new ProductSubCategory { Id = Guid.Parse("00000502-0000-0000-0000-000000000000"), Name = "Träningsklockor",           ParentCategoryId = catWearables.Id };
        var subEarbuds         = new ProductSubCategory { Id = Guid.Parse("00000503-0000-0000-0000-000000000000"), Name = "Trådlösa earbuds",          ParentCategoryId = catWearables.Id };
        var subTvattmaskiner   = new ProductSubCategory { Id = Guid.Parse("00000601-0000-0000-0000-000000000000"), Name = "Tvättmaskiner",             ParentCategoryId = catVitvaror.Id };
        var subKylskap         = new ProductSubCategory { Id = Guid.Parse("00000602-0000-0000-0000-000000000000"), Name = "Kylskåp & Frysar",          ParentCategoryId = catVitvaror.Id };
        var subDammsugare      = new ProductSubCategory { Id = Guid.Parse("00000603-0000-0000-0000-000000000000"), Name = "Dammsugare",                ParentCategoryId = catVitvaror.Id };
        var subSmartaBelysning = new ProductSubCategory { Id = Guid.Parse("00000701-0000-0000-0000-000000000000"), Name = "Smart belysning",           ParentCategoryId = catSmartaHem.Id };
        var subSmartaSakerhet  = new ProductSubCategory { Id = Guid.Parse("00000702-0000-0000-0000-000000000000"), Name = "Säkerhet & Kameror",        ParentCategoryId = catSmartaHem.Id };
        var subSmartaAssistent = new ProductSubCategory { Id = Guid.Parse("00000703-0000-0000-0000-000000000000"), Name = "Smarta assistenter",         ParentCategoryId = catSmartaHem.Id };
        var subRouters         = new ProductSubCategory { Id = Guid.Parse("00000801-0000-0000-0000-000000000000"), Name = "Routrar & Mesh",             ParentCategoryId = catNatverk.Id };
        var subNAS             = new ProductSubCategory { Id = Guid.Parse("00000802-0000-0000-0000-000000000000"), Name = "NAS & Extern lagring",       ParentCategoryId = catNatverk.Id };
        var subUSBHubbar       = new ProductSubCategory { Id = Guid.Parse("00000803-0000-0000-0000-000000000000"), Name = "USB-hubbar & Dockningar",    ParentCategoryId = catNatverk.Id };

        modelBuilder.Entity<ProductSubCategory>().HasData(
            subLaptops, subStationara, subSkarmar, subTillbehorDator,
            subSmartphones, subSurfplattor, subMobilTillbehor,
            subTv, subHorlurar, subHogtalare,
            subKonsoler, subSpel, subGamingTillbehor,
            subSmartwatch, subTraning, subEarbuds,
            subTvattmaskiner, subKylskap, subDammsugare,
            subSmartaBelysning, subSmartaSakerhet, subSmartaAssistent,
            subRouters, subNAS, subUSBHubbar
        );

        // ──────────────────────────────────────────────
        // TILLVERKARE
        // ──────────────────────────────────────────────

        var mfrAcer        = new Manufacturer { Id = Guid.Parse("20000001-0000-0000-0000-000000000000"), Name = "Acer" };
        var mfrLenovo      = new Manufacturer { Id = Guid.Parse("20000002-0000-0000-0000-000000000000"), Name = "Lenovo" };
        var mfrAsus        = new Manufacturer { Id = Guid.Parse("20000003-0000-0000-0000-000000000000"), Name = "ASUS" };
        var mfrDell        = new Manufacturer { Id = Guid.Parse("20000004-0000-0000-0000-000000000000"), Name = "Dell" };
        var mfrHp          = new Manufacturer { Id = Guid.Parse("20000005-0000-0000-0000-000000000000"), Name = "HP" };
        var mfrSamsung     = new Manufacturer { Id = Guid.Parse("20000006-0000-0000-0000-000000000000"), Name = "Samsung" };
        var mfrApple       = new Manufacturer { Id = Guid.Parse("20000007-0000-0000-0000-000000000000"), Name = "Apple" };
        var mfrGoogle      = new Manufacturer { Id = Guid.Parse("20000008-0000-0000-0000-000000000000"), Name = "Google" };
        var mfrOnePlus     = new Manufacturer { Id = Guid.Parse("20000009-0000-0000-0000-000000000000"), Name = "OnePlus" };
        var mfrMsi         = new Manufacturer { Id = Guid.Parse("20000010-0000-0000-0000-000000000000"), Name = "MSI" };
        var mfrLg          = new Manufacturer { Id = Guid.Parse("20000011-0000-0000-0000-000000000000"), Name = "LG" };
        var mfrLogitech    = new Manufacturer { Id = Guid.Parse("20000012-0000-0000-0000-000000000000"), Name = "Logitech" };
        var mfrElgato      = new Manufacturer { Id = Guid.Parse("20000013-0000-0000-0000-000000000000"), Name = "Elgato" };
        var mfrSpigen      = new Manufacturer { Id = Guid.Parse("20000014-0000-0000-0000-000000000000"), Name = "Spigen" };
        var mfrAnker       = new Manufacturer { Id = Guid.Parse("20000015-0000-0000-0000-000000000000"), Name = "Anker" };
        var mfrBelkin      = new Manufacturer { Id = Guid.Parse("20000016-0000-0000-0000-000000000000"), Name = "Belkin" };
        var mfrSony        = new Manufacturer { Id = Guid.Parse("20000017-0000-0000-0000-000000000000"), Name = "Sony" };
        var mfrPhilips     = new Manufacturer { Id = Guid.Parse("20000018-0000-0000-0000-000000000000"), Name = "Philips" };
        var mfrBose        = new Manufacturer { Id = Guid.Parse("20000019-0000-0000-0000-000000000000"), Name = "Bose" };
        var mfrJabra       = new Manufacturer { Id = Guid.Parse("20000020-0000-0000-0000-000000000000"), Name = "Jabra" };
        var mfrSennheiser  = new Manufacturer { Id = Guid.Parse("20000021-0000-0000-0000-000000000000"), Name = "Sennheiser" };
        var mfrJbl         = new Manufacturer { Id = Guid.Parse("20000022-0000-0000-0000-000000000000"), Name = "JBL" };
        var mfrSonos       = new Manufacturer { Id = Guid.Parse("20000023-0000-0000-0000-000000000000"), Name = "Sonos" };
        var mfrMarshall    = new Manufacturer { Id = Guid.Parse("20000024-0000-0000-0000-000000000000"), Name = "Marshall" };
        var mfrNintendo    = new Manufacturer { Id = Guid.Parse("20000025-0000-0000-0000-000000000000"), Name = "Nintendo" };
        var mfrRazer       = new Manufacturer { Id = Guid.Parse("20000026-0000-0000-0000-000000000000"), Name = "Razer" };
        var mfrSteelSeries = new Manufacturer { Id = Guid.Parse("20000027-0000-0000-0000-000000000000"), Name = "SteelSeries" };
        var mfrCorsair     = new Manufacturer { Id = Guid.Parse("20000028-0000-0000-0000-000000000000"), Name = "Corsair" };
        var mfrGarmin      = new Manufacturer { Id = Guid.Parse("20000029-0000-0000-0000-000000000000"), Name = "Garmin" };
        var mfrPolar       = new Manufacturer { Id = Guid.Parse("20000030-0000-0000-0000-000000000000"), Name = "Polar" };
        var mfrFitbit      = new Manufacturer { Id = Guid.Parse("20000031-0000-0000-0000-000000000000"), Name = "Fitbit" };
        var mfrHuawei      = new Manufacturer { Id = Guid.Parse("20000032-0000-0000-0000-000000000000"), Name = "Huawei" };
        var mfrBosch       = new Manufacturer { Id = Guid.Parse("20000033-0000-0000-0000-000000000000"), Name = "Bosch" };
        var mfrElectrolux  = new Manufacturer { Id = Guid.Parse("20000034-0000-0000-0000-000000000000"), Name = "Electrolux" };
        var mfrDyson       = new Manufacturer { Id = Guid.Parse("20000035-0000-0000-0000-000000000000"), Name = "Dyson" };
        var mfrIrobot      = new Manufacturer { Id = Guid.Parse("20000036-0000-0000-0000-000000000000"), Name = "iRobot" };
        var mfrMiele       = new Manufacturer { Id = Guid.Parse("20000037-0000-0000-0000-000000000000"), Name = "Miele" };
        var mfrIkea        = new Manufacturer { Id = Guid.Parse("20000038-0000-0000-0000-000000000000"), Name = "IKEA" };
        var mfrNanoleaf    = new Manufacturer { Id = Guid.Parse("20000039-0000-0000-0000-000000000000"), Name = "Nanoleaf" };
        var mfrGovee       = new Manufacturer { Id = Guid.Parse("20000040-0000-0000-0000-000000000000"), Name = "Govee" };
        var mfrRing        = new Manufacturer { Id = Guid.Parse("20000041-0000-0000-0000-000000000000"), Name = "Ring" };
        var mfrArlo        = new Manufacturer { Id = Guid.Parse("20000042-0000-0000-0000-000000000000"), Name = "Arlo" };
        var mfrNetatmo     = new Manufacturer { Id = Guid.Parse("20000043-0000-0000-0000-000000000000"), Name = "Netatmo" };
        var mfrAmazon      = new Manufacturer { Id = Guid.Parse("20000044-0000-0000-0000-000000000000"), Name = "Amazon" };
        var mfrTpLink      = new Manufacturer { Id = Guid.Parse("20000045-0000-0000-0000-000000000000"), Name = "TP-Link" };
        var mfrEero        = new Manufacturer { Id = Guid.Parse("20000046-0000-0000-0000-000000000000"), Name = "Eero" };
        var mfrNetgear     = new Manufacturer { Id = Guid.Parse("20000047-0000-0000-0000-000000000000"), Name = "Netgear" };
        var mfrSynology    = new Manufacturer { Id = Guid.Parse("20000048-0000-0000-0000-000000000000"), Name = "Synology" };
        var mfrWd          = new Manufacturer { Id = Guid.Parse("20000049-0000-0000-0000-000000000000"), Name = "Western Digital" };
        var mfrSanDisk     = new Manufacturer { Id = Guid.Parse("20000050-0000-0000-0000-000000000000"), Name = "SanDisk" };
        var mfrCalDigit    = new Manufacturer { Id = Guid.Parse("20000051-0000-0000-0000-000000000000"), Name = "CalDigit" };
        var mfrGoPro       = new Manufacturer { Id = Guid.Parse("20000052-0000-0000-0000-000000000000"), Name = "GoPro" };
        var mfrXiaomi      = new Manufacturer { Id = Guid.Parse("20000053-0000-0000-0000-000000000000"), Name = "Xiaomi" };
        var mfrWithings    = new Manufacturer { Id = Guid.Parse("20000054-0000-0000-0000-000000000000"), Name = "Withings" };
        var mfrMicrosoft   = new Manufacturer { Id = Guid.Parse("20000055-0000-0000-0000-000000000000"), Name = "Microsoft" };
        var mfrEa          = new Manufacturer { Id = Guid.Parse("20000056-0000-0000-0000-000000000000"), Name = "EA" };
        var mfrCdProjekt   = new Manufacturer { Id = Guid.Parse("20000057-0000-0000-0000-000000000000"), Name = "CD Projekt Red" };
        var mfrInsomniac   = new Manufacturer { Id = Guid.Parse("20000058-0000-0000-0000-000000000000"), Name = "Insomniac Games" };
        var mfrAvalanche   = new Manufacturer { Id = Guid.Parse("20000059-0000-0000-0000-000000000000"), Name = "Avalanche Software" };

        modelBuilder.Entity<Manufacturer>().HasData(
            mfrAcer, mfrLenovo, mfrAsus, mfrDell, mfrHp, mfrSamsung, mfrApple, mfrGoogle,
            mfrOnePlus, mfrMsi, mfrLg, mfrLogitech, mfrElgato, mfrSpigen, mfrAnker, mfrBelkin,
            mfrSony, mfrPhilips, mfrBose, mfrJabra, mfrSennheiser, mfrJbl, mfrSonos, mfrMarshall,
            mfrNintendo, mfrRazer, mfrSteelSeries, mfrCorsair, mfrGarmin, mfrPolar, mfrFitbit,
            mfrHuawei, mfrBosch, mfrElectrolux, mfrDyson, mfrIrobot, mfrMiele, mfrIkea,
            mfrNanoleaf, mfrGovee, mfrRing, mfrArlo, mfrNetatmo, mfrAmazon, mfrTpLink, mfrEero,
            mfrNetgear, mfrSynology, mfrWd, mfrSanDisk, mfrCalDigit, mfrGoPro, mfrXiaomi, mfrWithings,
            mfrMicrosoft, mfrEa, mfrCdProjekt, mfrInsomniac, mfrAvalanche
        );

        // ──────────────────────────────────────────────
        // SHIPPING ALTERNATIVES
        // ──────────────────────────────────────────────

        var shipStandard = new Shipping { Id = Guid.Parse("30000001-0000-0000-0000-000000000000"), TypeOfShipping = "Standard (3-7 business days)", Price = 49m };
        var shipExpress  = new Shipping { Id = Guid.Parse("30000002-0000-0000-0000-000000000000"), TypeOfShipping = "Express (1-2 business days)", Price = 129m };
        var shipPickup   = new Shipping { Id = Guid.Parse("30000003-0000-0000-0000-000000000000"), TypeOfShipping = "Store Pickup (same day)", Price = 0m };

        modelBuilder.Entity<Shipping>().HasData(
            shipStandard, shipExpress, shipPickup
        );

        // ──────────────────────────────────────────────
        // PRODUKTER
        // ──────────────────────────────────────────────

        modelBuilder.Entity<Product>().HasData(

            // ── Laptops ──
            new Product { Id = Guid.Parse("10000001-0000-0000-0000-000000000000"), ManufacturerId = mfrAcer.Id,      Name = "Acer Aspire 15\"",          Description = "Pålitlig vardagslaptop med Intel Core i5 och 16GB RAM.",           Price = 7995m,  QtyInStock = 18, SubCategoryId = subLaptops.Id },
            new Product { Id = Guid.Parse("10000002-0000-0000-0000-000000000000"), ManufacturerId = mfrLenovo.Id,    Name = "Lenovo ThinkPad E14",         Description = "Affärslaptop med robust byggkvalitet och lång batteritid.",         Price = 9495m,  QtyInStock = 12, SubCategoryId = subLaptops.Id },
            new Product { Id = Guid.Parse("10000003-0000-0000-0000-000000000000"), ManufacturerId = mfrAsus.Id,      Name = "ASUS VivoBook 14\"",          Description = "Kompakt och lättviktig laptop för studenter.",                      Price = 6495m,  QtyInStock = 22, SubCategoryId = subLaptops.Id },
            new Product { Id = Guid.Parse("10000004-0000-0000-0000-000000000000"), ManufacturerId = mfrDell.Id,      Name = "Dell XPS 15\"",               Description = "Premium laptop med OLED-skärm och Intel Core i7.",                  Price = 16995m, QtyInStock = 7,  SubCategoryId = subLaptops.Id },
            new Product { Id = Guid.Parse("10000005-0000-0000-0000-000000000000"), ManufacturerId = mfrHp.Id,        Name = "HP Spectre x360 14\"",        Description = "Konvertibel 2-i-1 laptop med pekskärm och stylus.",                 Price = 14495m, QtyInStock = 9,  SubCategoryId = subLaptops.Id },

            // ── Stationära datorer ──
            new Product { Id = Guid.Parse("10000006-0000-0000-0000-000000000000"), ManufacturerId = mfrHp.Id,        Name = "HP Pavilion Desktop",         Description = "Kompakt stationär dator med Intel Core i5 och 512GB SSD.",         Price = 8995m,  QtyInStock = 10, SubCategoryId = subStationara.Id },
            new Product { Id = Guid.Parse("10000007-0000-0000-0000-000000000000"), ManufacturerId = mfrDell.Id,      Name = "Dell OptiPlex 7000",           Description = "Affärsdator med hög prestanda och energieffektivitet.",            Price = 11495m, QtyInStock = 6,  SubCategoryId = subStationara.Id },
            new Product { Id = Guid.Parse("10000008-0000-0000-0000-000000000000"), ManufacturerId = mfrLenovo.Id,    Name = "Lenovo IdeaCentre 5",          Description = "Stilren stationär dator för hem och kontor.",                      Price = 7495m,  QtyInStock = 14, SubCategoryId = subStationara.Id },
            new Product { Id = Guid.Parse("10000009-0000-0000-0000-000000000000"), ManufacturerId = mfrAsus.Id,      Name = "ASUS ROG Strix G15",           Description = "Kraftfull gaming-desktop med RTX 4070 och 32GB RAM.",              Price = 19995m, QtyInStock = 5,  SubCategoryId = subStationara.Id },

            // ── Datorskärmar ──
            new Product { Id = Guid.Parse("10000010-0000-0000-0000-000000000000"), ManufacturerId = mfrMsi.Id,       Name = "MSI MAG 27\" QHD",            Description = "27-tums QHD-skärm med 165Hz och 1ms responstid.",                  Price = 4295m,  QtyInStock = 15, SubCategoryId = subSkarmar.Id },
            new Product { Id = Guid.Parse("10000011-0000-0000-0000-000000000000"), ManufacturerId = mfrLg.Id,        Name = "LG UltraWide 34\"",            Description = "Ultravid 34-tums skärm med IPS-panel och USB-C.",                  Price = 5995m,  QtyInStock = 9,  SubCategoryId = subSkarmar.Id },
            new Product { Id = Guid.Parse("10000012-0000-0000-0000-000000000000"), ManufacturerId = mfrDell.Id,      Name = "Dell UltraSharp 27\" 4K",      Description = "Professionell 4K-skärm med exceptionell färgåtergivning.",         Price = 7495m,  QtyInStock = 8,  SubCategoryId = subSkarmar.Id },
            new Product { Id = Guid.Parse("10000013-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung 32\" Curved",          Description = "Böjd VA-skärm med 144Hz för en uppslukande upplevelse.",            Price = 3795m,  QtyInStock = 11, SubCategoryId = subSkarmar.Id },
            new Product { Id = Guid.Parse("10000093-0000-0000-0000-000000000000"), ManufacturerId = mfrLg.Id,        Name = "LG 27\" 4K UltraFine",         Description = "USB-C 4K-skärm optimerad för Mac med 96W laddning.",              Price = 6495m,  QtyInStock = 8,  SubCategoryId = subSkarmar.Id },

            // ── Datortillbehör ──
            new Product { Id = Guid.Parse("10000014-0000-0000-0000-000000000000"), ManufacturerId = mfrLogitech.Id,  Name = "Logitech MX Keys",             Description = "Trådlöst tangentbord med bakgrundsbelysning och multienhetspar.", Price = 1195m,  QtyInStock = 25, SubCategoryId = subTillbehorDator.Id },
            new Product { Id = Guid.Parse("10000015-0000-0000-0000-000000000000"), ManufacturerId = mfrLogitech.Id,  Name = "Logitech MX Master 3S",        Description = "Ergonomisk trådlös mus med precision scroll och tyst klick.",      Price = 995m,   QtyInStock = 30, SubCategoryId = subTillbehorDator.Id },
            new Product { Id = Guid.Parse("10000016-0000-0000-0000-000000000000"), ManufacturerId = mfrElgato.Id,    Name = "Elgato Stream Deck MK.2",      Description = "15-knappars LCD-kontroller för streamers och kreatörer.",          Price = 1595m,  QtyInStock = 12, SubCategoryId = subTillbehorDator.Id },
            new Product { Id = Guid.Parse("10000095-0000-0000-0000-000000000000"), ManufacturerId = mfrGoPro.Id,     Name = "GoPro Hero 12 Black",          Description = "5.3K video, HyperSmooth 6.0 och vattentät till 10m.",             Price = 4995m,  QtyInStock = 12, SubCategoryId = subTillbehorDator.Id },

            // ── Smartphones ──
            new Product { Id = Guid.Parse("10000017-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung Galaxy S24",           Description = "Flaggskepp med AI-funktioner, 50MP kamera och 120Hz AMOLED.",     Price = 9995m,  QtyInStock = 25, SubCategoryId = subSmartphones.Id },
            new Product { Id = Guid.Parse("10000018-0000-0000-0000-000000000000"), ManufacturerId = mfrApple.Id,     Name = "iPhone 15",                    Description = "Apple iPhone 15 med Dynamic Island och USB-C.",                    Price = 11995m, QtyInStock = 20, SubCategoryId = subSmartphones.Id },
            new Product { Id = Guid.Parse("10000019-0000-0000-0000-000000000000"), ManufacturerId = mfrGoogle.Id,    Name = "Google Pixel 8",               Description = "Ren Android-upplevelse med exceptionell kameramjukvara.",          Price = 8495m,  QtyInStock = 14, SubCategoryId = subSmartphones.Id },
            new Product { Id = Guid.Parse("10000020-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung Galaxy A55",           Description = "Mellanklass med premiumkänsla, 5G och 50MP kamera.",               Price = 4995m,  QtyInStock = 30, SubCategoryId = subSmartphones.Id },
            new Product { Id = Guid.Parse("10000021-0000-0000-0000-000000000000"), ManufacturerId = mfrOnePlus.Id,   Name = "OnePlus 12",                   Description = "Snabb laddning 100W, Snapdragon 8 Gen 3 och Hasselblad-kamera.",  Price = 8995m,  QtyInStock = 16, SubCategoryId = subSmartphones.Id },

            // ── Surfplattor ──
            new Product { Id = Guid.Parse("10000022-0000-0000-0000-000000000000"), ManufacturerId = mfrApple.Id,     Name = "iPad 10:e gen",                Description = "Allsidig surfplatta med A14 Bionic och USB-C.",                   Price = 5495m,  QtyInStock = 18, SubCategoryId = subSurfplattor.Id },
            new Product { Id = Guid.Parse("10000023-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung Galaxy Tab S9",        Description = "Android-surfplatta med AMOLED-skärm och S Pen.",                   Price = 7995m,  QtyInStock = 11, SubCategoryId = subSurfplattor.Id },
            new Product { Id = Guid.Parse("10000024-0000-0000-0000-000000000000"), ManufacturerId = mfrLenovo.Id,    Name = "Lenovo Tab P12 Pro",            Description = "12.6-tums AMOLED-surfplatta med Snapdragon 870.",                  Price = 6495m,  QtyInStock = 9,  SubCategoryId = subSurfplattor.Id },
            new Product { Id = Guid.Parse("10000091-0000-0000-0000-000000000000"), ManufacturerId = mfrApple.Id,     Name = "iPad Pro 12.9\" M2",           Description = "Kraftfull pro-surfplatta med M2-chip, Liquid Retina XDR och 5G.", Price = 13995m, QtyInStock = 8,  SubCategoryId = subSurfplattor.Id },

            // ── Mobilskal & Tillbehör ──
            new Product { Id = Guid.Parse("10000025-0000-0000-0000-000000000000"), ManufacturerId = mfrSpigen.Id,    Name = "Spigen Tough Armor iPhone 15", Description = "Stöttåligt skal med Air Cushion Technology.",                     Price = 299m,   QtyInStock = 80, SubCategoryId = subMobilTillbehor.Id },
            new Product { Id = Guid.Parse("10000026-0000-0000-0000-000000000000"), ManufacturerId = mfrAnker.Id,     Name = "Anker USB-C Snabbladdare 65W", Description = "Kompakt GaN-laddare med 65W och stöd för tre enheter.",           Price = 449m,   QtyInStock = 60, SubCategoryId = subMobilTillbehor.Id },
            new Product { Id = Guid.Parse("10000027-0000-0000-0000-000000000000"), ManufacturerId = mfrBelkin.Id,    Name = "Belkin MagSafe Plånboksskal",  Description = "Magnetiskt skal med inbyggd plånbok för iPhone 15.",               Price = 399m,   QtyInStock = 45, SubCategoryId = subMobilTillbehor.Id },

            // ── TV-apparater ──
            new Product { Id = Guid.Parse("10000028-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung 65\" QLED 4K",         Description = "QLED med Quantum HDR och 120Hz för sport och gaming.",            Price = 14995m, QtyInStock = 8,  SubCategoryId = subTv.Id },
            new Product { Id = Guid.Parse("10000029-0000-0000-0000-000000000000"), ManufacturerId = mfrLg.Id,        Name = "LG OLED 55\" C3",              Description = "Prisbelönt OLED-TV med perfekta svärtor och Dolby Vision.",        Price = 17995m, QtyInStock = 5,  SubCategoryId = subTv.Id },
            new Product { Id = Guid.Parse("10000030-0000-0000-0000-000000000000"), ManufacturerId = mfrSony.Id,      Name = "Sony Bravia 50\" 4K",          Description = "Google TV med Cognitive Processor XR och Dolby Atmos.",           Price = 8995m,  QtyInStock = 12, SubCategoryId = subTv.Id },
            new Product { Id = Guid.Parse("10000031-0000-0000-0000-000000000000"), ManufacturerId = mfrPhilips.Id,   Name = "Philips 43\" Ambilight",       Description = "4K TV med unikt Ambilight-system för immersiv upplevelse.",        Price = 6495m,  QtyInStock = 10, SubCategoryId = subTv.Id },

            // ── Hörlurar ──
            new Product { Id = Guid.Parse("10000032-0000-0000-0000-000000000000"), ManufacturerId = mfrSony.Id,      Name = "Sony WH-1000XM5",              Description = "Branschledande brusreducering med 30h batteritid.",               Price = 3495m,  QtyInStock = 20, SubCategoryId = subHorlurar.Id },
            new Product { Id = Guid.Parse("10000033-0000-0000-0000-000000000000"), ManufacturerId = mfrBose.Id,      Name = "Bose QuietComfort 45",         Description = "Komfortabla over-ear med TriPort-akustik och ANC.",                Price = 3295m,  QtyInStock = 15, SubCategoryId = subHorlurar.Id },
            new Product { Id = Guid.Parse("10000034-0000-0000-0000-000000000000"), ManufacturerId = mfrJabra.Id,     Name = "Jabra Evolve2 55",             Description = "Professionella kontorshörlurar med hybridANC och Teams-cert.",    Price = 4195m,  QtyInStock = 10, SubCategoryId = subHorlurar.Id },
            new Product { Id = Guid.Parse("10000035-0000-0000-0000-000000000000"), ManufacturerId = mfrSennheiser.Id,Name = "Sennheiser HD 450BT",          Description = "Trådlösa over-ear med aktiv brusreducering och 30h batteri.",     Price = 1695m,  QtyInStock = 18, SubCategoryId = subHorlurar.Id },

            // ── Högtalare ──
            new Product { Id = Guid.Parse("10000036-0000-0000-0000-000000000000"), ManufacturerId = mfrJbl.Id,       Name = "JBL Charge 5",                 Description = "Vattentät Bluetooth-högtalare med 20h batteritid.",               Price = 1595m,  QtyInStock = 30, SubCategoryId = subHogtalare.Id },
            new Product { Id = Guid.Parse("10000037-0000-0000-0000-000000000000"), ManufacturerId = mfrSonos.Id,     Name = "Sonos Era 100",                Description = "Smart WiFi-högtalare med stereopar-stöd och Trueplay.",           Price = 3295m,  QtyInStock = 14, SubCategoryId = subHogtalare.Id },
            new Product { Id = Guid.Parse("10000038-0000-0000-0000-000000000000"), ManufacturerId = mfrMarshall.Id,  Name = "Marshall Stanmore III",        Description = "Ikonisk design med kraftfullt ljud och Bluetooth 5.2.",           Price = 4495m,  QtyInStock = 8,  SubCategoryId = subHogtalare.Id },
            new Product { Id = Guid.Parse("10000094-0000-0000-0000-000000000000"), ManufacturerId = mfrBose.Id,      Name = "Bose SoundLink Max",           Description = "Stor portabel högtalare med PartyMode och 20h batteritid.",       Price = 4495m,  QtyInStock = 10, SubCategoryId = subHogtalare.Id },

            // ── Spelkonsoler ──
            new Product { Id = Guid.Parse("10000039-0000-0000-0000-000000000000"), ManufacturerId = mfrSony.Id,      Name = "PlayStation 5",                Description = "Next-gen konsol med SSD, haptic feedback och 4K gaming.",         Price = 6495m,  QtyInStock = 15, SubCategoryId = subKonsoler.Id },
            new Product { Id = Guid.Parse("10000040-0000-0000-0000-000000000000"), ManufacturerId = mfrMicrosoft.Id, Name = "Xbox Series X",                Description = "Kraftfullaste Xbox någonsin med 12 teraflops och Game Pass.",      Price = 5995m,  QtyInStock = 13, SubCategoryId = subKonsoler.Id },
            new Product { Id = Guid.Parse("10000041-0000-0000-0000-000000000000"), ManufacturerId = mfrNintendo.Id,  Name = "Nintendo Switch OLED",         Description = "Hybrid-konsol med 7-tums OLED-skärm och förbättrad ljud.",        Price = 3595m,  QtyInStock = 22, SubCategoryId = subKonsoler.Id },

            // ── Spel ──
            new Product { Id = Guid.Parse("10000042-0000-0000-0000-000000000000"), ManufacturerId = mfrEa.Id,        Name = "EA Sports FC 25 PS5",          Description = "Årets fotbollsspel med HyperMotion V-teknologi.",                  Price = 699m,   QtyInStock = 40, SubCategoryId = subSpel.Id },
            new Product { Id = Guid.Parse("10000043-0000-0000-0000-000000000000"), ManufacturerId = mfrAvalanche.Id, Name = "Hogwarts Legacy Xbox",         Description = "Upplev det magiska Hogwarts i ett öppet rollspel.",                Price = 549m,   QtyInStock = 35, SubCategoryId = subSpel.Id },
            new Product { Id = Guid.Parse("10000044-0000-0000-0000-000000000000"), ManufacturerId = mfrNintendo.Id,  Name = "Zelda: Tears of the Kingdom",  Description = "Episkt äventyr i Hyrule för Nintendo Switch.",                    Price = 599m,   QtyInStock = 28, SubCategoryId = subSpel.Id },
            new Product { Id = Guid.Parse("10000045-0000-0000-0000-000000000000"), ManufacturerId = mfrCdProjekt.Id, Name = "Cyberpunk 2077 PC",            Description = "Öppen värld i Night City – nu med Phantom Liberty-expansion.",    Price = 399m,   QtyInStock = 50, SubCategoryId = subSpel.Id },
            new Product { Id = Guid.Parse("10000046-0000-0000-0000-000000000000"), ManufacturerId = mfrInsomniac.Id, Name = "Spider-Man 2 PS5",             Description = "Sväng runt Manhattan som Peter Parker och Miles Morales.",         Price = 699m,   QtyInStock = 32, SubCategoryId = subSpel.Id },

            // ── Gaming-tillbehör ──
            new Product { Id = Guid.Parse("10000047-0000-0000-0000-000000000000"), ManufacturerId = mfrRazer.Id,     Name = "Razer BlackWidow V3",          Description = "Mekaniskt tangentbord med Razer Green-switchar och RGB.",          Price = 1295m,  QtyInStock = 18, SubCategoryId = subGamingTillbehor.Id },
            new Product { Id = Guid.Parse("10000048-0000-0000-0000-000000000000"), ManufacturerId = mfrLogitech.Id,  Name = "Logitech G502 X Plus",         Description = "Trådlös gaming-mus med LIGHTFORCE-switchar och 130h batteri.",    Price = 1195m,  QtyInStock = 24, SubCategoryId = subGamingTillbehor.Id },
            new Product { Id = Guid.Parse("10000049-0000-0000-0000-000000000000"), ManufacturerId = mfrSteelSeries.Id,Name = "SteelSeries Arctis Nova 7",   Description = "Trådlöst headset med 38h batteritid och ClearCast AI-mikrofon.",  Price = 1995m,  QtyInStock = 16, SubCategoryId = subGamingTillbehor.Id },
            new Product { Id = Guid.Parse("10000050-0000-0000-0000-000000000000"), ManufacturerId = mfrCorsair.Id,   Name = "Corsair K70 RGB Pro",          Description = "Mekaniskt tangentbord med Cherry MX-switchar och USB-passthrough.",Price = 1495m, QtyInStock = 12, SubCategoryId = subGamingTillbehor.Id },
            new Product { Id = Guid.Parse("10000092-0000-0000-0000-000000000000"), ManufacturerId = mfrLogitech.Id,  Name = "Logitech G Pro X Superlight",  Description = "Ultralätt trådlös gaming-mus med HERO 25K-sensor.",               Price = 1595m,  QtyInStock = 14, SubCategoryId = subGamingTillbehor.Id },
            new Product { Id = Guid.Parse("10000098-0000-0000-0000-000000000000"), ManufacturerId = mfrElgato.Id,    Name = "Elgato 4K60 Pro MK.2",         Description = "Capture card med 4K60 HDR10 och VRR-stöd.",                       Price = 2495m,  QtyInStock = 8,  SubCategoryId = subGamingTillbehor.Id },

            // ── Smartwatches ──
            new Product { Id = Guid.Parse("10000051-0000-0000-0000-000000000000"), ManufacturerId = mfrApple.Id,     Name = "Apple Watch Series 9",         Description = "Double Tap-gest, S9-chip och Always-On Retina-display.",          Price = 4995m,  QtyInStock = 20, SubCategoryId = subSmartwatch.Id },
            new Product { Id = Guid.Parse("10000052-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung Galaxy Watch 6",       Description = "Avancerad hälsomätning med BioActive Sensor och sleep coaching.",  Price = 3495m,  QtyInStock = 15, SubCategoryId = subSmartwatch.Id },
            new Product { Id = Guid.Parse("10000053-0000-0000-0000-000000000000"), ManufacturerId = mfrGarmin.Id,    Name = "Garmin Venu 3",                Description = "Premiumsmartwatch med AMOLED och avancerad sömn-analys.",           Price = 4195m,  QtyInStock = 10, SubCategoryId = subSmartwatch.Id },
            new Product { Id = Guid.Parse("10000054-0000-0000-0000-000000000000"), ManufacturerId = mfrHuawei.Id,    Name = "Huawei Watch GT 4",            Description = "Elegant design med 14 dagars batteritid och GPS.",                 Price = 2695m,  QtyInStock = 13, SubCategoryId = subSmartwatch.Id },
            new Product { Id = Guid.Parse("10000097-0000-0000-0000-000000000000"), ManufacturerId = mfrWithings.Id,  Name = "Withings ScanWatch 2",         Description = "Hybridklocka med EKG, SpO2 och 30 dagars batteritid.",            Price = 3495m,  QtyInStock = 9,  SubCategoryId = subSmartwatch.Id },

            // ── Träningsklockor ──
            new Product { Id = Guid.Parse("10000055-0000-0000-0000-000000000000"), ManufacturerId = mfrGarmin.Id,    Name = "Garmin Forerunner 265",        Description = "Löparklocka med AMOLED, Training Readiness och HRV Status.",      Price = 4495m,  QtyInStock = 12, SubCategoryId = subTraning.Id },
            new Product { Id = Guid.Parse("10000056-0000-0000-0000-000000000000"), ManufacturerId = mfrPolar.Id,     Name = "Polar Vantage V3",             Description = "Multisportklocka med EKG, optisk puls och SWR-sensor.",            Price = 6495m,  QtyInStock = 7,  SubCategoryId = subTraning.Id },
            new Product { Id = Guid.Parse("10000057-0000-0000-0000-000000000000"), ManufacturerId = mfrFitbit.Id,    Name = "Fitbit Charge 6",              Description = "Aktivitetsarmband med Google Maps, ECG och stress-hantering.",    Price = 1695m,  QtyInStock = 22, SubCategoryId = subTraning.Id },

            // ── Trådlösa earbuds ──
            new Product { Id = Guid.Parse("10000058-0000-0000-0000-000000000000"), ManufacturerId = mfrApple.Id,     Name = "Apple AirPods Pro 2",          Description = "Adaptiv ljudavstängning, Personalized Spatial Audio och H2-chip.", Price = 2995m,  QtyInStock = 25, SubCategoryId = subEarbuds.Id },
            new Product { Id = Guid.Parse("10000059-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung Galaxy Buds2 Pro",     Description = "Hi-Fi 24-bitars ljud med intelligent ANC och IPX7.",              Price = 1995m,  QtyInStock = 20, SubCategoryId = subEarbuds.Id },
            new Product { Id = Guid.Parse("10000060-0000-0000-0000-000000000000"), ManufacturerId = mfrSony.Id,      Name = "Sony WF-1000XM5",              Description = "Världens bästa ANC i ett kompakt format med 8h batteritid.",      Price = 2795m,  QtyInStock = 18, SubCategoryId = subEarbuds.Id },

            // ── Tvättmaskiner ──
            new Product { Id = Guid.Parse("10000061-0000-0000-0000-000000000000"), ManufacturerId = mfrBosch.Id,     Name = "Bosch Serie 6 WGG14204S",      Description = "Frontmatad tvättmaskin 9kg med EcoSilence Drive och WiFi.",        Price = 8995m,  QtyInStock = 6,  SubCategoryId = subTvattmaskiner.Id },
            new Product { Id = Guid.Parse("10000062-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung WW90T684DLE",          Description = "EcoBubble-teknologi 9kg med AI Control och ångfunktion.",          Price = 7495m,  QtyInStock = 8,  SubCategoryId = subTvattmaskiner.Id },
            new Product { Id = Guid.Parse("10000063-0000-0000-0000-000000000000"), ManufacturerId = mfrElectrolux.Id,Name = "Electrolux PerfectCare 700",   Description = "Tvättmaskin med SteamCare och UltraMix för skonsam tvätt.",       Price = 6995m,  QtyInStock = 7,  SubCategoryId = subTvattmaskiner.Id },

            // ── Kylskåp & Frysar ──
            new Product { Id = Guid.Parse("10000064-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung Side-by-Side RS68",    Description = "Fransk dörr-kylskåp med SpaceMax och Twin Cooling Plus.",         Price = 14995m, QtyInStock = 4,  SubCategoryId = subKylskap.Id },
            new Product { Id = Guid.Parse("10000065-0000-0000-0000-000000000000"), ManufacturerId = mfrBosch.Id,     Name = "Bosch KGN39AIAT",              Description = "NoFrost-kylskåp med FreshSense och VitaFresh-låda.",               Price = 9495m,  QtyInStock = 6,  SubCategoryId = subKylskap.Id },
            new Product { Id = Guid.Parse("10000066-0000-0000-0000-000000000000"), ManufacturerId = mfrLg.Id,        Name = "LG GBB62PZGFN",                Description = "Total No Frost-kylskåp med DoorCooling+ och WiFi.",                Price = 8495m,  QtyInStock = 7,  SubCategoryId = subKylskap.Id },

            // ── Dammsugare ──
            new Product { Id = Guid.Parse("10000067-0000-0000-0000-000000000000"), ManufacturerId = mfrDyson.Id,     Name = "Dyson V15 Detect",             Description = "Laser-detektering av damm, HEPA-filtrering och 60min drift.",     Price = 6995m,  QtyInStock = 10, SubCategoryId = subDammsugare.Id },
            new Product { Id = Guid.Parse("10000068-0000-0000-0000-000000000000"), ManufacturerId = mfrIrobot.Id,    Name = "Roomba Combo j9+",             Description = "Robotdammsugare med auto-tömning och moppfunktion.",               Price = 8995m,  QtyInStock = 8,  SubCategoryId = subDammsugare.Id },
            new Product { Id = Guid.Parse("10000069-0000-0000-0000-000000000000"), ManufacturerId = mfrMiele.Id,     Name = "Miele Triflex HX2 Pro",        Description = "Tredelad design, VARTA-batteri och 60min körtid.",                 Price = 5995m,  QtyInStock = 9,  SubCategoryId = subDammsugare.Id },
            new Product { Id = Guid.Parse("10000096-0000-0000-0000-000000000000"), ManufacturerId = mfrXiaomi.Id,    Name = "Xiaomi Robot Vacuum S20+",     Description = "Robotdammsugare med laser-navigering och moppfunktion.",          Price = 4495m,  QtyInStock = 10, SubCategoryId = subDammsugare.Id },

            // ── Smart belysning ──
            new Product { Id = Guid.Parse("10000070-0000-0000-0000-000000000000"), ManufacturerId = mfrPhilips.Id,   Name = "Philips Hue Starterkit E27",   Description = "3 smarta glödlampor med Hue Bridge och 16M färger.",              Price = 1295m,  QtyInStock = 25, SubCategoryId = subSmartaBelysning.Id },
            new Product { Id = Guid.Parse("10000071-0000-0000-0000-000000000000"), ManufacturerId = mfrIkea.Id,      Name = "IKEA TRÅDFRI Startpaket",      Description = "Prisvärt smart belysningssystem med dimmer och gateway.",          Price = 599m,   QtyInStock = 35, SubCategoryId = subSmartaBelysning.Id },
            new Product { Id = Guid.Parse("10000072-0000-0000-0000-000000000000"), ManufacturerId = mfrNanoleaf.Id,  Name = "Nanoleaf Lines Starter",        Description = "Modulära LED-linjer med musik-reaktivitet och Touch Control.",     Price = 1995m,  QtyInStock = 15, SubCategoryId = subSmartaBelysning.Id },
            new Product { Id = Guid.Parse("10000073-0000-0000-0000-000000000000"), ManufacturerId = mfrGovee.Id,     Name = "Govee Neon Rope Light 3m",     Description = "RGBIC neontejp med app-kontroll och musik-synkronisering.",        Price = 799m,   QtyInStock = 20, SubCategoryId = subSmartaBelysning.Id },

            // ── Säkerhet & Kameror ──
            new Product { Id = Guid.Parse("10000074-0000-0000-0000-000000000000"), ManufacturerId = mfrRing.Id,      Name = "Ring Video Doorbell Pro 2",    Description = "3D Motion Detection, Bird's Eye View och 1536p HD-video.",        Price = 2995m,  QtyInStock = 12, SubCategoryId = subSmartaSakerhet.Id },
            new Product { Id = Guid.Parse("10000075-0000-0000-0000-000000000000"), ManufacturerId = mfrArlo.Id,      Name = "Arlo Pro 5S utomhuskamera",    Description = "2K HDR, färg-nattseende och 6 månaders batteritid.",              Price = 2495m,  QtyInStock = 10, SubCategoryId = subSmartaSakerhet.Id },
            new Product { Id = Guid.Parse("10000076-0000-0000-0000-000000000000"), ManufacturerId = mfrNetatmo.Id,   Name = "Netatmo Smart Alarm System",   Description = "Modulärt larmsystem med inomhuskamera och rörelsedetektering.",   Price = 3495m,  QtyInStock = 7,  SubCategoryId = subSmartaSakerhet.Id },
            new Product { Id = Guid.Parse("10000099-0000-0000-0000-000000000000"), ManufacturerId = mfrTpLink.Id,    Name = "TP-Link Tapo C320WS",          Description = "Utomhuskamera 4MP med ColorPro Night Vision och AI-detektion.",   Price = 595m,   QtyInStock = 25, SubCategoryId = subSmartaSakerhet.Id },

            // ── Smarta assistenter ──
            new Product { Id = Guid.Parse("10000077-0000-0000-0000-000000000000"), ManufacturerId = mfrAmazon.Id,    Name = "Amazon Echo Dot 5th gen",      Description = "Kompakt smart högtalare med Alexa och förbättrat ljud.",           Price = 499m,   QtyInStock = 40, SubCategoryId = subSmartaAssistent.Id },
            new Product { Id = Guid.Parse("10000078-0000-0000-0000-000000000000"), ManufacturerId = mfrGoogle.Id,    Name = "Google Nest Hub 2nd gen",      Description = "Smart skärm med Google Assistant och sömnspårning.",              Price = 999m,   QtyInStock = 25, SubCategoryId = subSmartaAssistent.Id },
            new Product { Id = Guid.Parse("10000079-0000-0000-0000-000000000000"), ManufacturerId = mfrApple.Id,     Name = "Apple HomePod mini",           Description = "360-graders ljud, Siri och smarthemshub i ett kompakt format.",   Price = 1095m,  QtyInStock = 20, SubCategoryId = subSmartaAssistent.Id },

            // ── Routrar & Mesh ──
            new Product { Id = Guid.Parse("10000080-0000-0000-0000-000000000000"), ManufacturerId = mfrAsus.Id,      Name = "ASUS ZenWiFi Pro ET12",        Description = "WiFi 6E Mesh-system med tri-band och 10Gbps WAN/LAN.",            Price = 8995m,  QtyInStock = 6,  SubCategoryId = subRouters.Id },
            new Product { Id = Guid.Parse("10000081-0000-0000-0000-000000000000"), ManufacturerId = mfrTpLink.Id,    Name = "TP-Link Deco XE75 Pro",        Description = "WiFi 6E Mesh 3-pack med EasyMesh och föräldrakontroll.",          Price = 4995m,  QtyInStock = 9,  SubCategoryId = subRouters.Id },
            new Product { Id = Guid.Parse("10000082-0000-0000-0000-000000000000"), ManufacturerId = mfrEero.Id,      Name = "Eero Pro 6E 3-pack",           Description = "Amazon Mesh-system med Zigbee-hubb och enkel app-setup.",         Price = 5495m,  QtyInStock = 8,  SubCategoryId = subRouters.Id },
            new Product { Id = Guid.Parse("10000083-0000-0000-0000-000000000000"), ManufacturerId = mfrNetgear.Id,   Name = "Netgear Orbi RBK863S",         Description = "WiFi 6 Mesh med 6Gbps total bandbredd och 6 enheter.",            Price = 6995m,  QtyInStock = 5,  SubCategoryId = subRouters.Id },

            // ── NAS & Extern lagring ──
            new Product { Id = Guid.Parse("10000084-0000-0000-0000-000000000000"), ManufacturerId = mfrSynology.Id,  Name = "Synology DS223",               Description = "Kompakt 2-bays NAS med DiskStation Manager och RAID.",            Price = 3295m,  QtyInStock = 8,  SubCategoryId = subNAS.Id },
            new Product { Id = Guid.Parse("10000085-0000-0000-0000-000000000000"), ManufacturerId = mfrWd.Id,        Name = "WD My Cloud EX2 Ultra",        Description = "2-bay NAS med 8TB och automatisk moln-backup.",                    Price = 4495m,  QtyInStock = 6,  SubCategoryId = subNAS.Id },
            new Product { Id = Guid.Parse("10000086-0000-0000-0000-000000000000"), ManufacturerId = mfrSamsung.Id,   Name = "Samsung T7 Shield 2TB",        Description = "Robust portabel SSD med USB 3.2 Gen2 och IP65-klassning.",        Price = 1195m,  QtyInStock = 20, SubCategoryId = subNAS.Id },
            new Product { Id = Guid.Parse("10000087-0000-0000-0000-000000000000"), ManufacturerId = mfrSanDisk.Id,   Name = "SanDisk Extreme Pro 4TB",      Description = "Portabel NVMe SSD med 2000MB/s och drop-skydd.",                   Price = 1895m,  QtyInStock = 15, SubCategoryId = subNAS.Id },
            new Product { Id = Guid.Parse("10000100-0000-0000-0000-000000000000"), ManufacturerId = mfrCorsair.Id,   Name = "Corsair MP600 Pro 2TB NVMe",   Description = "PCIe 4.0 SSD med 7000MB/s läshastighet och aluminium heatsink.", Price = 2195m,  QtyInStock = 14, SubCategoryId = subNAS.Id },

            // ── USB-hubbar & Dockningar ──
            new Product { Id = Guid.Parse("10000088-0000-0000-0000-000000000000"), ManufacturerId = mfrCalDigit.Id,  Name = "CalDigit TS4 Thunderbolt 4",   Description = "18 portar inkl. 2x Thunderbolt 4, 2x USB-A och 2.5GbE.",         Price = 4295m,  QtyInStock = 7,  SubCategoryId = subUSBHubbar.Id },
            new Product { Id = Guid.Parse("10000089-0000-0000-0000-000000000000"), ManufacturerId = mfrAnker.Id,     Name = "Anker 575 USB-C Docking",      Description = "13-i-1 dockningsstation med 85W laddning och dual 4K.",           Price = 1995m,  QtyInStock = 12, SubCategoryId = subUSBHubbar.Id },
            new Product { Id = Guid.Parse("10000090-0000-0000-0000-000000000000"), ManufacturerId = mfrBelkin.Id,    Name = "Belkin Connect USB-C 11-i-1",  Description = "Kompakt hub med HDMI 4K, SD-kortläsare och 100W PD.",             Price = 1295m,  QtyInStock = 18, SubCategoryId = subUSBHubbar.Id }
        );
    }
}