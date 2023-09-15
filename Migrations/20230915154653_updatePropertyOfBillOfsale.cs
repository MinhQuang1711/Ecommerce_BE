using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_BE.Migrations
{
    /// <inheritdoc />
    public partial class updatePropertyOfBillOfsale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "ImportBill",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentType",
                table: "BillOfSale",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "ImportBill");

            migrationBuilder.DropColumn(
                name: "PaymentType",
                table: "BillOfSale");
        }
    }
}
