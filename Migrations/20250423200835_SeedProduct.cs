using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class SeedProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "/Users/compumagic/Downloads/frontend-project/photos/man/Boxy Fit Crew Neck Printed Sweatshirt 1199 EGP.avif");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ID",
                keyValue: 1,
                column: "Image",
                value: "./photos/man/Boxy_Fit_Crew_Neck_Printed_Sweatshirt_1199_EGP.avif");
        }
    }
}
