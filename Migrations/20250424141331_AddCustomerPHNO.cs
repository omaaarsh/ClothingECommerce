using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerPHNO : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                column: "PhoneNo",
                value: "01005033314");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                column: "PhoneNo",
                value: "010005033314");
        }
    }
}
