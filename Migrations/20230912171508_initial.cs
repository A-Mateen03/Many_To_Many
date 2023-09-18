using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RelationShip_Many_Many.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BuyersProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_ID = table.Column<int>(type: "int", nullable: false),
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BuyersProducts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "buyers",
                columns: table => new
                {
                    BuyerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_buyers", x => x.BuyerId);
                    table.ForeignKey(
                        name: "FK_buyers_BuyersProducts_BuyerProductId",
                        column: x => x.BuyerProductId,
                        principalTable: "BuyersProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    P_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    P_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_Price = table.Column<int>(type: "int", nullable: false),
                    P_Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    P_ImgUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BuyerProductId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.P_ID);
                    table.ForeignKey(
                        name: "FK_Products_BuyersProducts_BuyerProductId",
                        column: x => x.BuyerProductId,
                        principalTable: "BuyersProducts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_buyers_BuyerProductId",
                table: "buyers",
                column: "BuyerProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_BuyerProductId",
                table: "Products",
                column: "BuyerProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "buyers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "BuyersProducts");
        }
    }
}
