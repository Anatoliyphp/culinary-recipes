using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AddLikeCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeLikes_Recipes_RecipeId",
                table: "RecipeLikes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id");
        }
    }
}
