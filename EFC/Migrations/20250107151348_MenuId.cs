using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFC.Migrations
{
    /// <inheritdoc />
    public partial class MenuId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_DrinksMenus_menuId",
                table: "Drinks");

            migrationBuilder.RenameColumn(
                name: "menuId",
                table: "Drinks",
                newName: "MenuId");

            migrationBuilder.RenameIndex(
                name: "IX_Drinks_menuId",
                table: "Drinks",
                newName: "IX_Drinks_MenuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_DrinksMenus_MenuId",
                table: "Drinks",
                column: "MenuId",
                principalTable: "DrinksMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drinks_DrinksMenus_MenuId",
                table: "Drinks");

            migrationBuilder.RenameColumn(
                name: "MenuId",
                table: "Drinks",
                newName: "menuId");

            migrationBuilder.RenameIndex(
                name: "IX_Drinks_MenuId",
                table: "Drinks",
                newName: "IX_Drinks_menuId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drinks_DrinksMenus_menuId",
                table: "Drinks",
                column: "menuId",
                principalTable: "DrinksMenus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
