using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorello.data.Migrations
{
    public partial class mg_9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "gender",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "gender",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
