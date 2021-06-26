using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AddRecipeCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Recipes_RecipeId",
                table: "UserFavourites");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Recipes_RecipeId",
                table: "UserFavourites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserFavourites_Recipes_RecipeId",
                table: "UserFavourites");

            migrationBuilder.AddForeignKey(
                name: "FK_UserFavourites_Recipes_RecipeId",
                table: "UserFavourites",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
