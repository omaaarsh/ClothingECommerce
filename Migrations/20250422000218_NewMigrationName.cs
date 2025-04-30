using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "Man");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Women");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Kid");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "Effortlessly stylish Boxy Fit Crew Neck Printed Sweatshirt, crafted for ultimate comfort with a bold, vibrant print and relaxed silhouette.", "../photos/man/Boxy_Fit_Crew_Neck_Printed_Sweatshirt_1199_EGP.avif", "Boxy Fit Crew Neck Printed Sweatshirt", 1199m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[] { 1, "Iconic Boxy Fit Crew Neck Printed Sweatshirt, blending cozy softness with a striking graphic design for a standout casual look.", "../photos/man/Boxy_Fit_Crew_Neck_Printed_Sweatshirt_1199_EGP2.avif", "Boxy Fit Crew Neck Printed Sweatshirt", 1199m, 50 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[] { 1, "Trendsetting Boxy Fit Crew Neck Printed Sweatshirt, offering plush comfort and a dynamic print for an effortlessly cool vibe.", "../photos/man/Boxy_Fit_Crew_Neck_Printed_Sweatshirt_1199_EGP3.avif", "Boxy Fit Crew Neck Printed Sweatshirt", 1199m, 50 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ID", "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { 4, 1, "Timeless Plain T-Shirt with Label, featuring a sleek minimalist design and ultra-soft fabric for versatile, everyday wear.", "../photos/man/PLAIN_T_SHIRT_WITH_LABEL_1199_EGP.avif", "Plain T-Shirt with Label", 1199m, 50 },
                    { 5, 1, "Sophisticated Regular Fit Long Sleeve Shirt, tailored for a polished look with breathable, lightweight fabric for all-day comfort.", "../photos/man/Regular_Fit_Long_Sleeve_Shirt_1499_EGP.avif", "Regular Fit Long Sleeve Shirt", 1499m, 50 },
                    { 6, 1, "Breezy Relax Fit Apache Neck Cotton Shirt, adorned with intricate embroidery for a laid-back yet refined summer style.", "../photos/man/Relax_Fit_Apache_Neck_Cotton_Embroidered_Short_Sleeve_Shirt_1299_EGP.avif", "Relax Fit Apache Neck Cotton Shirt", 1299m, 50 },
                    { 7, 1, "Vibrant Oversize Fit Resort Collar Patterned Shirt, crafted from airy cotton with a bold pattern for a relaxed, tropical flair.", "../photos/man/Oversize_Fit_Resort_Collar_Patterned_Cotton_Shirt_999_EGP.avif", "Oversize Fit Resort Collar Patterned Shirt", 1390m, 50 },
                    { 8, 1, "Chic Regular Fit Apache Neck Viscose Shirt, featuring sleek stripes and silky-smooth fabric for a refined, casual elegance.", "../photos/man/Regular_Fit_Apache_Neck_Viscose_Striped_Short_Sleeve_Shirt_999_EGP.avif", "Regular Fit Apache Neck Viscose Shirt", 999m, 50 },
                    { 9, 1, "Sleek Modern Fit Blazer, expertly tailored for a sharp, contemporary silhouette with premium fabric for lasting sophistication.", "../photos/man/Modern_Fit_Blazer_2999_EGP.avif", "Modern Fit Blazer", 2999m, 50 },
                    { 10, 1, "Luxurious Relax Fit Lined Blazer, combining a laid-back cut with refined lining for unparalleled comfort and style.", "../photos/man/Relax_Fit_Lined_Blazer_3599_EGP.avif", "Relax Fit Lined Blazer", 3599m, 50 },
                    { 11, 1, "Dapper Checkered Formal Shirt, featuring a crisp check pattern and tailored fit for a polished, professional appearance.", "../photos/man/Checkered_Formal_Shirt_1799_EGP.avif", "Checkered Formal Shirt", 1799m, 50 },
                    { 12, 1, "Sharp Slim Fit Blazer, designed for a streamlined silhouette with high-quality fabric for a modern, elegant look.", "../photos/man/Slim_Fit_Blazer_2999_EGP.avif", "Slim Fit Blazer", 2999m, 50 },
                    { 13, 1, "Easygoing Casual Relaxed Fit T-Shirt, crafted from soft, breathable cotton for a comfortable, laid-back everyday style.", "../photos/man/Casual_Relaxed_Fit_T_Shirt_799_EGP.avif", "Casual Relaxed Fit T-Shirt", 799m, 50 },
                    { 14, 1, "Dynamic Sporty Zip-Up Hoodie, blending cozy warmth with a sleek design for active lifestyles and casual outings.", "../photos/man/Sporty_Zip_Up_Hoodie_1399_EGP.avif", "Sporty Zip-Up Hoodie", 1399m, 50 },
                    { 15, 1, "Essential Classic Crew Neck T-Shirt, offering timeless simplicity and ultra-soft comfort for versatile, everyday wear.", "../photos/man/Classic_Crew_Neck_T_Shirt_699_EGP.avif", "Classic Crew Neck T-Shirt", 699m, 50 },
                    { 16, 1, "Comfort-driven Soft Cotton Casual Shirt, featuring a relaxed fit and buttery-soft fabric for effortless, all-day style.", "../photos/man/Soft_Cotton_Casual_Shirt_1299_EGP.avif", "Soft Cotton Casual Shirt", 1299m, 50 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 16);

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 1,
                column: "Name",
                value: "T-Shirts");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 2,
                column: "Name",
                value: "Jeans");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "ID",
                keyValue: 3,
                column: "Name",
                value: "Hoodies");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Description", "Image", "Name", "Price" },
                values: new object[] { "blue_tshirt", "blue_tshirt.jpg", "Blue T-Shirt", 19.99m });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[] { 2, "Black Jeans", "black_jeans.jpg", "Black Jeans", 49.99m, 30 });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 3,
                columns: new[] { "CategoryID", "Description", "Image", "Name", "Price", "Quantity" },
                values: new object[] { 3, "Red Hoodie", "red_hoodie.jpg", "Red Hoodie", 39.99m, 20 });
        }
    }
}
