using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_BE.Migrations
{
    /// <inheritdoc />
    public partial class CreateBillOfSaleDbset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailBillOfSale_BillOfSale_BillId",
                table: "DetailBillOfSale");

            migrationBuilder.DropForeignKey(
                name: "FK_DetailBillOfSale_products_ProductId",
                table: "DetailBillOfSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetailBillOfSale",
                table: "DetailBillOfSale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BillOfSale",
                table: "BillOfSale");

            migrationBuilder.RenameTable(
                name: "DetailBillOfSale",
                newName: "detailBillOfSales");

            migrationBuilder.RenameTable(
                name: "BillOfSale",
                newName: "billOfSales");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "products",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ingredients",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ImportBill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "detailProducts",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "DetailImportBill",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "detailBillOfSales",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_DetailBillOfSale_ProductId",
                table: "detailBillOfSales",
                newName: "IX_detailBillOfSales_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_DetailBillOfSale_BillId",
                table: "detailBillOfSales",
                newName: "IX_detailBillOfSales_BillId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "billOfSales",
                newName: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detailBillOfSales",
                table: "detailBillOfSales",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_billOfSales",
                table: "billOfSales",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_detailBillOfSales_billOfSales_BillId",
                table: "detailBillOfSales",
                column: "BillId",
                principalTable: "billOfSales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detailBillOfSales_products_ProductId",
                table: "detailBillOfSales",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detailBillOfSales_billOfSales_BillId",
                table: "detailBillOfSales");

            migrationBuilder.DropForeignKey(
                name: "FK_detailBillOfSales_products_ProductId",
                table: "detailBillOfSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detailBillOfSales",
                table: "detailBillOfSales");

            migrationBuilder.DropPrimaryKey(
                name: "PK_billOfSales",
                table: "billOfSales");

            migrationBuilder.RenameTable(
                name: "detailBillOfSales",
                newName: "DetailBillOfSale");

            migrationBuilder.RenameTable(
                name: "billOfSales",
                newName: "BillOfSale");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "products",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ingredients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "ImportBill",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "detailProducts",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailImportBill",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "DetailBillOfSale",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_detailBillOfSales_ProductId",
                table: "DetailBillOfSale",
                newName: "IX_DetailBillOfSale_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_detailBillOfSales_BillId",
                table: "DetailBillOfSale",
                newName: "IX_DetailBillOfSale_BillId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "BillOfSale",
                newName: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetailBillOfSale",
                table: "DetailBillOfSale",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BillOfSale",
                table: "BillOfSale",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailBillOfSale_BillOfSale_BillId",
                table: "DetailBillOfSale",
                column: "BillId",
                principalTable: "BillOfSale",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetailBillOfSale_products_ProductId",
                table: "DetailBillOfSale",
                column: "ProductId",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
