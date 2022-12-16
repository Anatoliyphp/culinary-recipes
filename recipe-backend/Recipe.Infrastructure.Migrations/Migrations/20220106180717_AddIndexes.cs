using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AddIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFavourites_UserId",
                table: "UserFavourites");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLikes_UserId",
                table: "RecipeLikes");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Login",
                table: "Users",
                column: "Login",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserFavourites_UserId_RecipeId",
                table: "UserFavourites",
                columns: new[] { "UserId", "RecipeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLikes_UserId_RecipeId",
                table: "RecipeLikes",
                columns: new[] { "UserId", "RecipeId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Login",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_UserFavourites_UserId_RecipeId",
                table: "UserFavourites");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLikes_UserId_RecipeId",
                table: "RecipeLikes");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Name",
                table: "Users",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_UserFavourites_UserId",
                table: "UserFavourites",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_Name",
                table: "Recipes",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeLikes_UserId",
                table: "RecipeLikes",
                column: "UserId");
        }
    }
}
