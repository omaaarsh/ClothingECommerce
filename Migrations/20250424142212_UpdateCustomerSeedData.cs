using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Customer_PhoneNo_Length",
                table: "Customers",
                sql: "LEN(PhoneNo) = 11");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Customer_PhoneNo_Length",
                table: "Customers");
        }
    }
}
