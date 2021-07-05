using Microsoft.EntityFrameworkCore.Migrations;

namespace Migrations
{
    public partial class AddIngridients : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Ingridients",
                columns: new[] { "Id", "List", "Name", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Сливки-20-30% - 500мл.Молоко - 100мл.Желатин - 2ч.л.Сахар - 3ст.л.Ванильный сахар - 2 ч.л.", "Для панна конты", 1 },
                    { 2, "Фарш мясной - 500г.Соль - 2ст. ложкиХлеб пшеничный - 200г.", "Для фрикаделек", 2 },
                    { 3, "Яйца - 2 шт.Молоко - 200 млМука пшеничная - 10 ст.л.Разрыхлитель - 1 ч.л.Сахар - 2 ст.л.", "Для панкейков", 3 },
                    { 4, "200 г сливок для взбивания100 г сгущённого молока.", "Для мороженого", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Ingridients",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Ingridients",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Ingridients",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Ingridients",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
