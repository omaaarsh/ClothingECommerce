using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class lastFixo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37,
                column: "Image",
                value: "./photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP .jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39,
                column: "Image",
                value: "./photos/women/YALE™ POLO NECK SWEATSHIRT  2,490 EGP.jpg");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 37,
                column: "Image",
                value: "./photos/women/HIGH-WAIST WIDE-LEG TRF JEANS +3  2,990 EGP.jpg");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 39,
                column: "Image",
                value: "./photos/w \nYALE™ POLO NECK SWEATSHIRT  2,490 EGP.jpg");
        }
    }
}
