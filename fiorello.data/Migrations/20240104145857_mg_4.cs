using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace fiorello.data.Migrations
{
    public partial class mg_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Products_ProductsId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductsId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ProductsId",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "ProducstId",
                table: "Category",
                newName: "ProductId");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryId",
                table: "Products",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductId",
                table: "Category",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Products_ProductId",
                table: "Category",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Products_ProductId",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_ProductId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Category",
                newName: "ProducstId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsId",
                table: "Category",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_ProductsId",
                table: "Category",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Products_ProductsId",
                table: "Category",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id");
        }
    }
}
