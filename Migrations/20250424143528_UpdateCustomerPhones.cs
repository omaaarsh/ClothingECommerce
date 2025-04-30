using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerPhones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Email", "Name", "Password", "PhoneNo" },
                values: new object[] { 2, "janaSameh@gmail.com", "Jana Sameh", "hashed_jana_sameh_2", "01005033314" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
