using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblproducts_PurchasedOrder_PurchasedOrderID",
                table: "tblproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchasedOrder",
                table: "PurchasedOrder");

            migrationBuilder.RenameTable(
                name: "PurchasedOrder",
                newName: "tblpurchasedOrders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblpurchasedOrders",
                table: "tblpurchasedOrders",
                column: "POID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblproducts_tblpurchasedOrders_PurchasedOrderID",
                table: "tblproducts",
                column: "PurchasedOrderID",
                principalTable: "tblpurchasedOrders",
                principalColumn: "POID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblproducts_tblpurchasedOrders_PurchasedOrderID",
                table: "tblproducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblpurchasedOrders",
                table: "tblpurchasedOrders");

            migrationBuilder.RenameTable(
                name: "tblpurchasedOrders",
                newName: "PurchasedOrder");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchasedOrder",
                table: "PurchasedOrder",
                column: "POID");

            migrationBuilder.AddForeignKey(
                name: "FK_tblproducts_PurchasedOrder_PurchasedOrderID",
                table: "tblproducts",
                column: "PurchasedOrderID",
                principalTable: "PurchasedOrder",
                principalColumn: "POID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
