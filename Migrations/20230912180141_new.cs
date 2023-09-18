using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationShip_Many_Many.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_buyers_BuyersProducts_BuyerProductId",
                table: "buyers");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_BuyersProducts_BuyerProductId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "BuyersProducts");

            migrationBuilder.DropIndex(
                name: "IX_Products_BuyerProductId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_buyers_BuyerProductId",
                table: "buyers");

            migrationBuilder.DropColumn(
                name: "BuyerProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "BuyerProductId",
                table: "buyers");

            migrationBuilder.CreateTable(
                name: "BuyerProducts",
                columns: table => new
                {
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    ProductP_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerProducts", x => new { x.BuyerId, x.ProductP_ID });
                    table.ForeignKey(
                        name: "FK_BuyerProducts_Products_ProductP_ID",
                        column: x => x.ProductP_ID,
                        principalTable: "Products",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerProducts_buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerProducts_ProductP_ID",
                table: "BuyerProducts",
                column: "ProductP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerProducts");

            migrationBuilder.AddColumn<int>(
                name: "BuyerProductId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BuyerProductId",
                table: "buyers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BuyersProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    P_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyersProducts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerProductId",
                table: "Products",
                column: "BuyerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_buyers_BuyerProductId",
                table: "buyers",
                column: "BuyerProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_buyers_BuyersProducts_BuyerProductId",
                table: "buyers",
                column: "BuyerProductId",
                principalTable: "BuyersProducts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_BuyersProducts_BuyerProductId",
                table: "Products",
                column: "BuyerProductId",
                principalTable: "BuyersProducts",
                principalColumn: "Id");
        }
    }
}
