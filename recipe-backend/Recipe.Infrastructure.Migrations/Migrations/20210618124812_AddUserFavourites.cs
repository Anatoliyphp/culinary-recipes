using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Migrations
{
    public partial class AddUserFavourites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserFavourites",
                columns: new[] { "RecipeId", "UserId", "Id" },
                values: new object[,]
                {
                    { 2, 2, 1 },
                    { 4, 2, 2 },
                    { 1, 3, 3 },
                    { 3, 3, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserFavourites",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "UserFavourites",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "UserFavourites",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "UserFavourites",
                keyColumns: new[] { "RecipeId", "UserId" },
                keyValues: new object[] { 4, 2 });
        }
    }
}
