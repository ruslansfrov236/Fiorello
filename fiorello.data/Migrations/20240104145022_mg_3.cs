using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorello.data.Migrations
{
    public partial class mg_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Category",
                newName: "ProducstId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProducstId",
                table: "Category",
                newName: "ProductId");
        }
    }
}
