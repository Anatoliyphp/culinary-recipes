using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AddRecipes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Img", "Name", "Persons", "Time", "UserId" },
                values: new object[,]
                {
                    { 1, "Десерт, который невероятно легко и быстро готовится. Советую подавать его порционно в красивых бокалах, украсив взбитыми сливками, свежими ягодами и мятой.", "/Images/FirstRecipe.png", "Клубничная панна-котта", 5, 35, 2 },
                    { 2, "Мясные фрикадельки в томатном соусе - несложное и вкусное блюдо, которым можно порадовать своих близких. ", "/Images/SecondRecipe.png", "Мясные фрикадельки", 4, 90, 3 },
                    { 3, "Панкейки: меньше, чем блины, но больше, чем оладьи. Основное отличие — в тесте, оно должно быть воздушным, чтобы панкейки не растекались по сковородке...", "Images/ThirdRecipe.png", "Панкейки", 3, 40, 2 },
                    { 4, "Йогуртовое мороженое сочетает в себе нежный вкус и низкую калорийность, что будет особенно актуально для сладкоежек, соблюдающих диету.", "Images/FouthRecipe.png", "Полезное мороженое без сахара", 2, 35, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Recipes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
