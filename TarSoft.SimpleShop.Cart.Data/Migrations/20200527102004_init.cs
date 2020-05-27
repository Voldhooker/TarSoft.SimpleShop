using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TarSoft.SimpleShop.Cart.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cart");

            migrationBuilder.CreateTable(
                name: "Carts",
                schema: "Cart",
                columns: table => new
                {
                    CartId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartCookie = table.Column<string>(nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    Expires = table.Column<DateTime>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false),
                    SourceUrl = table.Column<string>(nullable: true),
                    CustomerCookie = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.CartId);
                });

            migrationBuilder.CreateTable(
                name: "CartItems",
                schema: "Cart",
                columns: table => new
                {
                    CartItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartCookie = table.Column<string>(nullable: true),
                    CartId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    NewCartCartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.CartItemId);
                    table.ForeignKey(
                        name: "FK_CartItems_Carts_NewCartCartId",
                        column: x => x.NewCartCartId,
                        principalSchema: "Cart",
                        principalTable: "Carts",
                        principalColumn: "CartId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_NewCartCartId",
                schema: "Cart",
                table: "CartItems",
                column: "NewCartCartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems",
                schema: "Cart");

            migrationBuilder.DropTable(
                name: "Carts",
                schema: "Cart");
        }
    }
}
