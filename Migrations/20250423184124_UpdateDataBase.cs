using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDataBase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 17, 3, "Stylish poplin T-shirt with bow appliqué, perfect for a chic and playful kids' look.", "../photos/kids/01037521250-e1.jpg", "POPLIN BOW APPLIQUÉ T", 850m, 50 },
                    { 18, 3, "Trendy contrast top for kids, combining comfort and bold style.", "../photos/kids/00485516250-e1.jpg", "CONTRAST TOP", 850m, 50 },
                    { 19, 3, "Cool denim top with button details, ideal for a casual yet stylish outfit.", "../photos/kids/08614640427-e1.jpg", "DENIM TOP WITH BUTTONS", 1390m, 50 },
                    { 20, 3, "Simple yet trendy plain T-shirt with a subtle label detail for everyday wear.", "../photos/kids/01716390620-e1.jpg", "PLAIN T-SHIRT WITH LABEL", 390m, 50 },
                    { 21, 3, "Cozy sweatshirt with embroidered text, adding a fun touch to kids' wardrobes.", "../photos/kids/01880930800-e1.jpg", "EMBROIDERED TEXT SWEATSHIRT", 890m, 50 },
                    { 22, 3, "Adorable bear print sweatshirt, perfect for a cute and comfy look.", "../photos/kids/05643504712-e1.jpg", "BEAR PRINT SWEATSHIRT", 1090m, 50 },
                    { 23, 3, "Stylish zip-up with embroidered slogan, blending comfort and attitude.", "../photos/kids/05431527098-e1.jpg", "EMBROIDERED SLOGAN WITH ZIP", 1390m, 50 },
                    { 24, 3, "Charming shirt with floral appliqué, adding a touch of elegance to kids' fashion.", "../photos/kids/01099808250-e1.jpg", "SHIRT WITH FLORAL APPLIQUÉ", 1390m, 50 },
                    { 25, 3, "Textured striped Bermuda shorts, offering a cool and casual vibe.", "../photos/kids/00794505400-e1.jpg", "TEXTURED STRIPED BERMUDA SHORTS", 1190m, 50 },
                    { 26, 3, "Textured striped shirt, perfect for a polished yet relaxed kids' outfit.", "../photos/kids/00794503400-e1.jpg", "TEXTURED STRIPED SHIRT", 1290m, 50 },
                    { 27, 3, "Linen Bermuda shorts with a belt, combining comfort and a smart look.", "../photos/kids/01258500052-e1.jpg", "LINEN BERMUDA SHORTS WITH BELT", 1290m, 50 },
                    { 28, 3, "Linen Bermuda shorts with patch details, ideal for a stylish summer outfit.", "../photos/kids/02878502712-e1.jpg", "LINEN PATCH BERMUDA SHORTS", 1190m, 50 },
                    { 29, 3, "Fun The Lion King © Disney themed apparel, perfect for young fans.", "../photos/kids/20310418999-e1.jpg", "THE LION KING © DISNEY", 1090m, 50 },
                    { 30, 3, "Playful Lilo & Stitch © Disney apparel, bringing fun to kids' wardrobes.", "../photos/kids/20310373999-e1.jpg", "LILO & STITCH © DISNEY", 650m, 50 },
                    { 31, 3, "Charming Minnie Mouse © Disney apparel, a delightful addition for kids.", "../photos/kids/20310338999-e1.jpg", "MINNIE MOUSE © DISNEY", 1090m, 50 },
                    { 32, 3, "Magical Mickey Mouse Fantasia © Disney apparel, perfect for Disney lovers.", "../photos/kids/00653546800-e1.jpg", "MICKEY MOUSE FANTASIA © DISNEY", 1090m, 50 },
                    { 33, 2, "Cozy NFL Giants hoodie, perfect for showing team spirit in style.", "../photos/women/NFL GIANTS HOODIE  3,290 EGP.jpg", "NFL GIANTS HOODIE", 3290m, 50 },
                    { 34, 2, "Comfortable hoodie with pockets, ideal for a casual and practical look.", "../photos/women/HOODIE WITH POCKETS +2  1,690 EGP.jpg", "HOODIE WITH POCKETS +2", 1690m, 50 },
                    { 35, 2, "Stylish Harvard University cropped fleece sweatshirt, blending comfort and collegiate pride.", "../photos/women/HARVARD UNIVERSITY CROPPED FLEECE SWEATSHIRT  2,290 EGP.jpg", "HARVARD UNIVERSITY SWEATSHIRT", 2290m, 50 },
                    { 36, 2, "Bold NFL Bills hoodie, designed for fans with a passion for comfort and team loyalty.", "../photos/women/NFL BILLS HOODIE  2,990 EGP.jpg", "NFL BILLS HOODIE", 2990m, 50 },
                    { 37, 2, "Trendy high-waist wide-leg TRF jeans, offering a chic and relaxed silhouette.", "../photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP.jpg", "HIGH-WAIST WIDE-LEG TRF JEANS +3", 2990m, 50 },
                    { 38, 2, "Elegant Yale™ polo neck sweatshirt, combining sophistication with cozy comfort.", "../photos/women/YALE™ POLO NECK SWEATSHIRT  2,490 EGP.jpg", "YALE™ POLO NECK SWEATSHIRT", 2490m, 50 },
                    { 39, 2, "Fashion-forward wide-leg mid-rise darted jeans, perfect for a modern and stylish look.", "../photos/women/Z1975 WIDE-LEG MID-RISE DARTED JEANS  2,490 EGP.jpg", "WIDE-LEG MID-RISE DARTED JEANS", 2490m, 50 },
                    { 40, 2, "Captivating Dark Romance EDP, a bold and alluring fragrance for women.", "../photos/women/DARK ROMANCE EDP 80 ML : 2.71 oz  1,690 EGP.jpg", "DARK ROMANCE EDP 80 ML : 2.71 oz", 1690m, 50 },
                    { 41, 2, "Enchanting Immortal Vanilla EDP, offering a sweet and timeless scent.", "../photos/women/IMMORTAL VANILLA EDP 80 ML : 2.71 oz  1,690 EGP.jpg", "IMMORTAL VANILLA EDP 80 ML : 2.71 oz", 1690m, 50 },
                    { 42, 2, "Mesmerizing Hypnotic Vanilla Bloom EDP, a floral and vanilla-infused fragrance.", "../photos/women/HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz  1,690 EGP.jpg", "HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz", 1690m, 50 },
                    { 43, 2, "Seductive Red Zara Temptation EDP, a vibrant and irresistible fragrance.", "../photos/women/RED ZARA TEMPTATION EDP 80ML : 2.71 oz  1,690 EGP.jpg", "RED ZARA TEMPTATION EDP 80ML : 2.71 oz", 1690m, 50 },
                    { 44, 2, "Cozy turn-up knit beanie, perfect for adding warmth and style to any outfit.", "../photos/women/TURN-UP KNIT BEANIE  1,090 EGP.jpg", "TURN-UP KNIT BEANIE", 1090m, 50 },
                    { 45, 2, "Elegant flower hair clip, adding a delicate and feminine touch to hairstyles.", "../photos/women/FLOWER HAIR CLIP  1,290 EGP.jpg", "FLOWER HAIR CLIP", 1290m, 50 },
                    { 46, 2, "Striking maxi enamelled flower earrings, perfect for a bold and floral statement.", "../photos/women/MAXI ENAMELLED FLOWER EARRINGS  1,290 EGP.jpg", "MAXI ENAMELLED FLOWER EARRINGS", 1290m, 50 },
                    { 47, 2, "Unique cord sun necklace, blending bohemian charm with a radiant design.", "../photos/women/CORD SUN NECKLACE  1,490 EGP.jpg", "CORD SUN NECKLACE", 1490m, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 47);
        }
    }
}
