using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class lastFixInSha2aAlla : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 33,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Cozy NFL Giants hoodie, perfect for women to show team spirit with a comfortable and stylish fit.", "./photos/women/NFL GIANTS HOODIE  3,290 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 34,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Casual hoodie with pockets, offering a relaxed fit and practical style for women.", "./photos/women/HOODIE WITH POCKETS +2  1,690 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Cropped fleece Harvard University sweatshirt, combining collegiate pride with trendy women’s fashion.", "./photos/women/HARVARD UNIVERSITY CROPPED FLEECE SWEATSHIRT  2,290 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 36,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Stylish NFL Bills hoodie, designed for women to support their team in comfort.", "./photos/women/NFL BILLS HOODIE  2,990 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Trendy high-waist wide-leg TRF jeans, offering a bold and fashionable look for women.", "./photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 38,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Trendy high-waist wide-leg TRF jeans, offering a bold and fashionable look for women.", "./photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP.jpg", "HIGH-WAIST WIDE-LEG TRF JEANS +3", 2990m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Sophisticated Yale™ polo neck sweatshirt, blending classic style with modern women’s fashion.", "./photos/w \nYALE™ POLO NECK SWEATSHIRT  2,490 EGP.jpg", "YALE™ POLO NECK SWEATSHIRT" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 40,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Chic wide-leg mid-rise darted jeans, perfect for a stylish and comfortable women’s outfit.", "./photos/women/Z1975 WIDE-LEG MID-RISE DARTED JEANS  2,490 EGP.jpg", "WIDE-LEG MID-RISE DARTED JEANS", 2490m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 41,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Alluring Dark Romance EDP 80ml, a captivating fragrance for women.", "./photos/women/DARK ROMANCE EDP 80 ML : 2.71 oz  1,690 EGP.jpg", "DARK ROMANCE EDP 80 ML : 2.71 oz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Enchanting Immortal Vanilla EDP 80ml, a sweet and lasting scent for women.", "./photos/women/IMMORTAL VANILLA EDP 80 ML : 2.71 oz  1,690 EGP.jpg", "IMMORTAL VANILLA EDP 80 ML : 2.71 oz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 43,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Mesmerizing Hypnotic Vanilla Bloom EDP 80ml, a floral-vanilla fragrance for women.", "./photos/women/HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz  1,690 EGP.jpg", "HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 44,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Bold Red Zara Temptation EDP 80ml, a vibrant and tempting scent for women.", "./photos/women/RED ZARA TEMPTATION EDP 80ML : 2.71 oz  1,690 EGP.jpg", "RED ZARA TEMPTATION EDP 80ML : 2.71 oz", 1690m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 45,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Cozy turn-up knit beanie, a stylish and warm accessory for women.", "./photos/women/TURN-UP KNIT BEANIE  1,090 EGP.jpg", "TURN-UP KNIT BEANIE", 1090m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 46,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Elegant flower hair clip, adding a feminine touch to women’s hairstyles.", "./photos/women/FLOWER HAIR CLIP  1,290 EGP.jpg", "FLOWER HAIR CLIP" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 47,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Striking maxi enamelled flower earrings, a bold accessory for women.", "./photos/women/MAXI ENAMELLED FLOWER EARRINGS  1,290 EGP.jpg", "MAXI ENAMELLED FLOWER EARRINGS", 1290m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[] { 48, 2, "Unique cord sun necklace, a chic and summery accessory for women.", "./photos/women/CORD SUN NECKLACE  1,490 EGP.jpg", "CORD SUN NECKLACE", 1490m, 50 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 48);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 33,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Cozy NFL Giants hoodie, perfect for showing team spirit in style.", "./photos/women/NFL Giants Hoodie 3290 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 34,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Comfortable hoodie with pockets, ideal for a casual and practical look.", "./photos/women/Hoodie With Pockets +2 1690 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 35,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Stylish Harvard University cropped fleece sweatshirt, blending comfort and collegiate pride.", "./photos/women/Harvard University Cropped Fleece Sweatshirt 2290 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 36,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Bold NFL Bills hoodie, designed for fans with a passion for comfort and team loyalty.", "./photos/women/NFL Bills Hoodie 2990 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37,
                columns: new[] { "Description", "Image" },
                values: new object[] { "Trendy high-waist wide-leg TRF jeans, offering a chic and relaxed silhouette.", "./photos/women/High Waist Wide Leg TRF Jeans +3 2990 EGP.jpg" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 38,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Elegant Yale™ polo neck sweatshirt, combining sophistication with cozy comfort.", "./photos/women/Yale Polo Neck Sweatshirt 2490 EGP.jpg", "YALE™ POLO NECK SWEATSHIRT", 2490m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Fashion-forward wide-leg mid-rise darted jeans, perfect for a modern and stylish look.", "./photos/women/Z1975 Wide Leg Mid Rise Darted Jeans 2490 EGP.jpg", "WIDE-LEG MID-RISE DARTED JEANS" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 40,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Captivating Dark Romance EDP, a bold and alluring fragrance for women.", "./photos/women/Dark Romance EDP 80 ML 2.71 oz 1690 EGP.jpg", "DARK ROMANCE EDP 80 ML : 2.71 oz", 1690m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 41,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Enchanting Immortal Vanilla EDP, offering a sweet and timeless scent.", "./photos/women/Immortal Vanilla EDP 80 ML 2.71 oz 1690 EGP.jpg", "IMMORTAL VANILLA EDP 80 ML : 2.71 oz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 42,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Mesmerizing Hypnotic Vanilla Bloom EDP, a floral and vanilla-infused fragrance.", "./photos/women/Hypnotic Vanilla Bloom EDP 80ML 2.71 oz 1690 EGP.jpg", "HYPNOTIC VANILLA BLOOM EDP 80ML : 2.71 oz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 43,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Seductive Red Zara Temptation EDP, a vibrant and irresistible fragrance.", "./photos/women/Red Zara Temptation EDP 80ML 2.71 oz 1690 EGP.jpg", "RED ZARA TEMPTATION EDP 80ML : 2.71 oz" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 44,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Cozy turn-up knit beanie, perfect for adding warmth and style to any outfit.", "./photos/women/Turn Up Knit Beanie 1090 EGP.jpg", "TURN-UP KNIT BEANIE", 1090m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 45,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Elegant flower hair clip, adding a delicate and feminine touch to hairstyles.", "./photos/women/Flower Hair Clip 1290 EGP.jpg", "FLOWER HAIR CLIP", 1290m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 46,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Striking maxi enamelled flower earrings, perfect for a bold and floral statement.", "./photos/women/Maxi Enamelled Flower Earrings 1290 EGP.jpg", "MAXI ENAMELLED FLOWER EARRINGS" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 47,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Unique cord sun necklace, blending bohemian charm with a radiant design.", "./photos/women/Cord Sun Necklace 1490 EGP.jpg", "CORD SUN NECKLACE", 1490m });
        }
    }
}
