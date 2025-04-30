using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_Email",
                table: "Customers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Customer_Password_Length",
                table: "Customers");

            migrationBuilder.DropCheckConstraint(
                name: "CK_Customer_PhoneNo_Length",
                table: "Customers");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_Customer_Password_Length",
                table: "Customers",
                sql: "LEN(Password) >= 6");

            migrationBuilder.AddCheckConstraint(
                name: "CK_Customer_PhoneNo_Length",
                table: "Customers",
                sql: "LEN(PhoneNo) = 11");
        }
    }
}
