using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_BE.Migrations
{
    /// <inheritdoc />
    public partial class updateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Weight",
                table: "ingerdients",
                newName: "NetWeight");

            migrationBuilder.AddColumn<double>(
                name: "PercentProfit",
                table: "products",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SalePrice",
                table: "products",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Loss",
                table: "ingerdients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "RealWeight",
                table: "ingerdients",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "BillOfSale",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SaleDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    FinalPrice = table.Column<double>(type: "double", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillOfSale", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ImportBill",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImportDate = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportBill", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetailBillOfSale",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BillId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<double>(type: "double", nullable: false),
                    ProductId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailBillOfSale", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailBillOfSale_BillOfSale_BillId",
                        column: x => x.BillId,
                        principalTable: "BillOfSale",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailBillOfSale_products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "DetailImportBill",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngerdientId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImportBillId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Quantity = table.Column<double>(type: "double", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailImportBill", x => x.id);
                    table.ForeignKey(
                        name: "FK_DetailImportBill_ImportBill_ImportBillId",
                        column: x => x.ImportBillId,
                        principalTable: "ImportBill",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailImportBill_ingerdients_IngerdientId",
                        column: x => x.IngerdientId,
                        principalTable: "ingerdients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBillOfSale_BillId",
                table: "DetailBillOfSale",
                column: "BillId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailBillOfSale_ProductId",
                table: "DetailBillOfSale",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailImportBill_ImportBillId",
                table: "DetailImportBill",
                column: "ImportBillId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailImportBill_IngerdientId",
                table: "DetailImportBill",
                column: "IngerdientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailBillOfSale");

            migrationBuilder.DropTable(
                name: "DetailImportBill");

            migrationBuilder.DropTable(
                name: "BillOfSale");

            migrationBuilder.DropTable(
                name: "ImportBill");

            migrationBuilder.DropColumn(
                name: "PercentProfit",
                table: "products");

            migrationBuilder.DropColumn(
                name: "SalePrice",
                table: "products");

            migrationBuilder.DropColumn(
                name: "Loss",
                table: "ingerdients");

            migrationBuilder.DropColumn(
                name: "RealWeight",
                table: "ingerdients");

            migrationBuilder.RenameColumn(
                name: "NetWeight",
                table: "ingerdients",
                newName: "Weight");
        }
    }
}
