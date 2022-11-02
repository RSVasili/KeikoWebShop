using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class RenamedTable_CategoryProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_categoryproducts",
                table: "categoryproducts");

            migrationBuilder.RenameTable(
                name: "categoryproducts",
                newName: "CategoryProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryProducts",
                table: "CategoryProducts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryProducts",
                table: "CategoryProducts");

            migrationBuilder.RenameTable(
                name: "CategoryProducts",
                newName: "categoryproducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_categoryproducts",
                table: "categoryproducts",
                column: "Id");
        }
    }
}
