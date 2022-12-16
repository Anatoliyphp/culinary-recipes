using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class RemoveIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFavourites_UserId_RecipeId",
                table: "UserFavourites");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLikes_UserId_RecipeId",
                table: "RecipeLikes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserFavourites_UserId",
                table: "UserFavourites");

            migrationBuilder.DropIndex(
                name: "IX_RecipeLikes_UserId",
                table: "RecipeLikes");

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
    }
}
