using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingECommerce.Migrations
{
    /// <inheritdoc />
    public partial class AddCustomerPasswordLengthConstraint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.ID);
                    table.CheckConstraint("CK_Customer_Password_Length", "LEN(Password) >= 6");
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "ID", "Email", "Name", "Password", "PhoneNo" },
                values: new object[,]
                {
                    { 1, "omarsherifelghamry@gmail.com", "omar sherif", "Omar__2004", "01030222769" },
                    { 2, "janaSameh@gamil.com", "Jana Sameh", "jana_Sameh_2", "010005033314" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
