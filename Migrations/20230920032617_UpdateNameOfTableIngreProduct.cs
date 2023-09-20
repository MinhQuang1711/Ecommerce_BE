using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_BE.Migrations
{
    /// <inheritdoc />
    public partial class UpdateNameOfTableIngreProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportBill_ingerdients_IngerdientId",
                table: "DetailImportBill");

            migrationBuilder.DropForeignKey(
                name: "FK_detailProducts_ingerdients_IngerdientID",
                table: "detailProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingerdients",
                table: "ingerdients");

            migrationBuilder.RenameTable(
                name: "ingerdients",
                newName: "ingredients");

            migrationBuilder.RenameColumn(
                name: "IngerdientID",
                table: "detailProducts",
                newName: "IngredientID");

            migrationBuilder.RenameIndex(
                name: "IX_detailProducts_IngerdientID",
                table: "detailProducts",
                newName: "IX_detailProducts_IngredientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingredients",
                table: "ingredients",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportBill_ingredients_IngerdientId",
                table: "DetailImportBill",
                column: "IngerdientId",
                principalTable: "ingredients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detailProducts_ingredients_IngredientID",
                table: "detailProducts",
                column: "IngredientID",
                principalTable: "ingredients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetailImportBill_ingredients_IngerdientId",
                table: "DetailImportBill");

            migrationBuilder.DropForeignKey(
                name: "FK_detailProducts_ingredients_IngredientID",
                table: "detailProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ingredients",
                table: "ingredients");

            migrationBuilder.RenameTable(
                name: "ingredients",
                newName: "ingerdients");

            migrationBuilder.RenameColumn(
                name: "IngredientID",
                table: "detailProducts",
                newName: "IngerdientID");

            migrationBuilder.RenameIndex(
                name: "IX_detailProducts_IngredientID",
                table: "detailProducts",
                newName: "IX_detailProducts_IngerdientID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ingerdients",
                table: "ingerdients",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DetailImportBill_ingerdients_IngerdientId",
                table: "DetailImportBill",
                column: "IngerdientId",
                principalTable: "ingerdients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detailProducts_ingerdients_IngerdientID",
                table: "detailProducts",
                column: "IngerdientID",
                principalTable: "ingerdients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
