using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCustomerPhoneConst : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Name", "Password" },
                values: new object[] { "Omar Sherif", "hashed_omar_2004" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "janaSameh@gmail.com", "hashed_jana_sameh_2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "Name", "Password" },
                values: new object[] { "omar sherif", "Omar__2004" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "Email", "Password" },
                values: new object[] { "janaSameh@gamil.com", "jana_Sameh_2" });
        }
    }
}
