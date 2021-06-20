using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AddRecipeTags : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RecipeTags",
                columns: new[] { "RecipeId", "TagId", "Id" },
                values: new object[,]
                {
                    { 1, 1, 0 },
                    { 2, 2, 0 },
                    { 3, 3, 0 },
                    { 4, 4, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RecipeTags",
                keyColumns: new[] { "RecipeId", "TagId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "RecipeTags",
                keyColumns: new[] { "RecipeId", "TagId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "RecipeTags",
                keyColumns: new[] { "RecipeId", "TagId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "RecipeTags",
                keyColumns: new[] { "RecipeId", "TagId" },
                keyValues: new object[] { 4, 4 });
        }
    }
}
