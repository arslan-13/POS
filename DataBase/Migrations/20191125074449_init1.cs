using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PurchasedOrderID",
                table: "tblproducts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PurchasedOrder",
                columns: table => new
                {
                    POID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasedOrder", x => x.POID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblproducts_PurchasedOrderID",
                table: "tblproducts",
                column: "PurchasedOrderID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblproducts_PurchasedOrder_PurchasedOrderID",
                table: "tblproducts",
                column: "PurchasedOrderID",
                principalTable: "PurchasedOrder",
                principalColumn: "POID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblproducts_PurchasedOrder_PurchasedOrderID",
                table: "tblproducts");

            migrationBuilder.DropTable(
                name: "PurchasedOrder");

            migrationBuilder.DropIndex(
                name: "IX_tblproducts_PurchasedOrderID",
                table: "tblproducts");

            migrationBuilder.DropColumn(
                name: "PurchasedOrderID",
                table: "tblproducts");
        }
    }
}
