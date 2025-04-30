using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class newData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP.avif");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Image", "Name" },
                values: new object[] { "./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP4.avif", "PLAIN T-SHIRT WITH LABEL" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Stylish Modern Fit Lined Blazer Jacket, offering a tailored fit with premium lining for a polished and comfortable look.", "./photos/man/Modern Fit Lined Blazer Jacket 2499 EGP.avif", "Modern Fit Lined Blazer Jacket", 2499m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Elegant Regular Fit Lined Blazer, designed for a classic silhouette with high-quality lining for all-day comfort.", "./photos/man/Regular Fit Lined Blazer 3999 EGP.avif", "Regular Fit Lined Blazer", 3999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Dynamic NBA Golden State Warriors Sports Shorts, crafted for comfort and style, perfect for fans and active wear.", "./photos/man/DeFactoFit NBA Golden State Warriors Standard Fit Sports Shorts 799 EGP.avif", "NBA Golden State Warriors Sports Shorts" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Versatile Standard Fit Sports Shorts, designed for performance and comfort during active pursuits.", "./photos/man/DeFactoFit Standard Fit Sports Shorts 1299 EGP.avif", "Standard Fit Sports Shorts", 1299m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Comfortable Standard Fit Sports Woven Shorts, ideal for sports and casual wear with a lightweight, breathable design.", "./photos/man/DeFactoFit Standard Fit Sports Woven Shorts 999 EGP.avif", "Standard Fit Sports Woven Shorts", 999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Sleek Standard Fit Woven Shorts, offering a relaxed fit and durable fabric for everyday casual wear.", "./photos/man/DeFactoFit Standard Fit Woven Shorts 999 EGP.avif", "Standard Fit Woven Shorts", 999m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 18, 3, "Vibrant contrast top for kids, combining bold colors and comfortable fabric for everyday wear.", "./photos/kids/00485516250-e1.jpg", "CONTRAST TOP", 850m, 50 },
                    { 19, 3, "Trendy denim top with buttons, offering a stylish and durable option for kids' casual outfits.", "./photos/kids/08614640427-e1.jpg", "DENIM TOP WITH BUTTONS", 1390m, 50 },
                    { 20, 3, "Simple yet stylish plain T-shirt with a label, ideal for kids' versatile and comfortable wear.", "./photos/kids/01716390620-e1.jpg", "PLAIN T-SHIRT WITH LABEL", 390m, 50 },
                    { 21, 3, "Cozy sweatshirt with embroidered text, perfect for kids to stay warm and fashionable.", "./photos/kids/01880930800-e1.jpg", "EMBROIDERED TEXT SWEATSHIRT", 890m, 50 },
                    { 22, 3, "Fun bear print sweatshirt, designed to keep kids cozy with a playful and charming design.", "./photos/kids/05643504712-e1.jpg", "BEAR PRINT SWEATSHIRT", 1090m, 50 },
                    { 23, 3, "Stylish zip-up with embroidered slogan, offering kids a trendy and comfortable outerwear option.", "./photos/kids/05431527098-e1.jpg", "EMBROIDERED SLOGAN WITH ZIP", 1390m, 50 },
                    { 24, 3, "Charming shirt with floral appliqué, adding a touch of elegance to kids' casual wardrobes.", "./photos/kids/01099808250-e1.jpg", "SHIRT WITH FLORAL APPLIQUÉ", 1390m, 50 },
                    { 25, 3, "Cool textured striped Bermuda shorts, perfect for kids' active and stylish summer looks.", "./photos/kids/00794505400-e1.jpg", "TEXTURED STRIPED BERMUDA SHORTS", 1190m, 50 },
                    { 26, 3, "Sleek textured striped shirt, offering kids a polished yet comfortable option for any occasion.", "./photos/kids/00794503400-e1.jpg", "TEXTURED STRIPED SHIRT", 1290m, 50 },
                    { 27, 3, "Lightweight linen Bermuda shorts with a belt, ideal for kids' breezy and stylish summer outfits.", "./photos/kids/01258500052-e1.jpg", "LINEN BERMUDA SHORTS WITH BELT", 1290m, 50 },
                    { 28, 3, "Casual linen patch Bermuda shorts, designed for kids' comfort and trendy summer adventures.", "./photos/kids/02878502712-e1.jpg", "LINEN PATCH BERMUDA SHORTS", 1190m, 50 },
                    { 29, 3, "Exciting The Lion King © Disney themed clothing, perfect for kids who love iconic characters.", "./photos/kids/20310418999-e1.jpg", "THE LION KING © DISNEY", 1090m, 50 },
                    { 30, 3, "Playful Lilo & Stitch © Disney themed clothing, bringing fun and comfort to kids' wardrobes.", "./photos/kids/20310373999-e1.jpg", "LILO & STITCH © DISNEY", 650m, 50 },
                    { 31, 3, "Adorable Minnie Mouse © Disney themed clothing, ideal for kids with a love for classic characters.", "./photos/kids/20310338999-e1.jpg", "MINNIE MOUSE © DISNEY", 1090m, 50 },
                    { 32, 3, "Magical Mickey Mouse Fantasia © Disney themed clothing, perfect for kids' whimsical and cozy style.", "./photos/kids/00653546800-e1.jpg", "MICKEY MOUSE FANTASIA © DISNEY", 1090m, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "\"./photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP.avif\"");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4,
                columns: new[] { "Image", "Name" },
                values: new object[] { "./photos/man/Plain T Shirt With Label 1199 EGP.avif", "Plain T-Shirt with Label" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Dapper Checkered Formal Shirt, featuring a crisp check pattern and tailored fit for a polished, professional appearance.", "./photos/man/Checkered Formal Shirt 1799 EGP.avif", "Checkered Formal Shirt", 1799m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Sharp Slim Fit Blazer, designed for a streamlined silhouette with high-quality fabric for a modern, elegant look.", "./photos/man/Slim Fit Blazer 2999 EGP.avif", "Slim Fit Blazer", 2999m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13,
                columns: new[] { "Description", "Image", "Name" },
                values: new object[] { "Easygoing Casual Relaxed Fit T-Shirt, crafted from soft, breathable cotton for a comfortable, laid-back everyday style.", "./photos/man/Casual Relaxed Fit T Shirt 799 EGP.avif", "Casual Relaxed Fit T-Shirt" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 14,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Dynamic Sporty Zip-Up Hoodie, blending cozy warmth with a sleek design for active lifestyles and casual outings.", "./photos/man/Sporty Zip Up Hoodie 1399 EGP.avif", "Sporty Zip-Up Hoodie", 1399m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Essential Classic Crew Neck T-Shirt, offering timeless simplicity and ultra-soft comfort for versatile, everyday wear.", "./photos/man/Classic Crew Neck T Shirt 699 EGP.avif", "Classic Crew Neck T-Shirt", 699m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 16,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Comfort-driven Soft Cotton Casual Shirt, featuring a relaxed fit and buttery-soft fabric for effortless, all-day style.", "./photos/man/Soft Cotton Casual Shirt 1299 EGP.avif", "Soft Cotton Casual Shirt", 1299m });
        }
    }
}
