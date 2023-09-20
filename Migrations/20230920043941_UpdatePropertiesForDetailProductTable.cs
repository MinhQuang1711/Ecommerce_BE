using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce_BE.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePropertiesForDetailProductTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IngredientName",
                table: "detailProducts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ProductName",
                table: "detailProducts",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IngredientName",
                table: "detailProducts");

            migrationBuilder.DropColumn(
                name: "ProductName",
                table: "detailProducts");
        }
    }
}
