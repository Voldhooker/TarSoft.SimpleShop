using Microsoft.EntityFrameworkCore.Migrations;

namespace TarSoft.SimpleShop.Cart.Data.Migrations
{
    public partial class idchange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_NewCartCartId",
                schema: "Cart",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                schema: "Cart",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_NewCartCartId",
                schema: "Cart",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "CartId",
                schema: "Cart",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "NewCartCartId",
                schema: "Cart",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                schema: "Cart",
                table: "Carts",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "NewCartId",
                schema: "Cart",
                table: "CartItems",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                schema: "Cart",
                table: "Carts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_NewCartId",
                schema: "Cart",
                table: "CartItems",
                column: "NewCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_NewCartId",
                schema: "Cart",
                table: "CartItems",
                column: "NewCartId",
                principalSchema: "Cart",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Carts_NewCartId",
                schema: "Cart",
                table: "CartItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts",
                schema: "Cart",
                table: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_NewCartId",
                schema: "Cart",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "Id",
                schema: "Cart",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "NewCartId",
                schema: "Cart",
                table: "CartItems");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                schema: "Cart",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "NewCartCartId",
                schema: "Cart",
                table: "CartItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts",
                schema: "Cart",
                table: "Carts",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_NewCartCartId",
                schema: "Cart",
                table: "CartItems",
                column: "NewCartCartId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Carts_NewCartCartId",
                schema: "Cart",
                table: "CartItems",
                column: "NewCartCartId",
                principalSchema: "Cart",
                principalTable: "Carts",
                principalColumn: "CartId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
