using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerPhone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { 2, "janaSameh@gmail.com", "Jana Sameh", "hashed_jana_sameh_2", "01005033314" });
        }
    }
}
