using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationShip_Many_Many.Migrations
{
    /// <inheritdoc />
    public partial class temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyerProduct",
                columns: table => new
                {
                    BuyerProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuyerId = table.Column<int>(type: "int", nullable: false),
                    ProductP_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyerProduct", x => x.BuyerProductId);
                    table.ForeignKey(
                        name: "FK_BuyerProduct_Products_ProductP_ID",
                        column: x => x.ProductP_ID,
                        principalTable: "Products",
                        principalColumn: "P_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BuyerProduct_buyers_BuyerId",
                        column: x => x.BuyerId,
                        principalTable: "buyers",
                        principalColumn: "BuyerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BuyerProduct_BuyerId",
                table: "BuyerProduct",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_BuyerProduct_ProductP_ID",
                table: "BuyerProduct",
                column: "ProductP_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BuyerProduct");
        }
    }
}
