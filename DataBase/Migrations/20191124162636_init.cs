using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblcategories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblcategories", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblvendors",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblvendors", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblproducts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Price = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    VendorID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblproducts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblproducts_tblcategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tblcategories",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblproducts_tblvendors_VendorID",
                        column: x => x.VendorID,
                        principalTable: "tblvendors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblproducts_CategoryID",
                table: "tblproducts",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tblproducts_VendorID",
                table: "tblproducts",
                column: "VendorID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblproducts");

            migrationBuilder.DropTable(
                name: "tblcategories");

            migrationBuilder.DropTable(
                name: "tblvendors");
        }
    }
}
