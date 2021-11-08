using Microsoft.EntityFrameworkCore.Migrations;

namespace Pizza_Portal.Migrations
{
    public partial class Id_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCart",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCartId",
                table: "ShoppingCartItems",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingCartId",
                table: "ShoppingCartItems");

            migrationBuilder.AddColumn<string>(
                name: "ShoppingCart",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
