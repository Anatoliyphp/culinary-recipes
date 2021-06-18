using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Migrations
{
    public partial class AddSteps : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Steps",
                columns: new[] { "Id", "Desc", "Name", "RecipeId" },
                values: new object[,]
                {
                    { 1, "Приготовим панна котту: Зальем желатин молоком и поставим на 30 минут для набухания. В сливки добавим сахар и ванильный сахар. Доводим до кипения (не кипятим!).", "Шаг 1", 1 },
                    { 2, "Добавим в сливки набухший в молоке желатин. Перемешаем до полного растворения. Огонь отключаем. Охладим до комнатной температуры.", "Шаг 2", 1 },
                    { 3, "Для приготовления фрикаделек к фаршу добавьте яйцо и измельченную зелень. По вкусу посыпьте небольшим количеством соли и специи. Все хорошо перемешайте до однородной массы.", "Шаг 1", 2 },
                    { 4, "Смешайте 2 яйца и 200 мл молока.Затем добавьте 2 ст.л.сахара и ваниль.Взбейте до однородности.Добавьте 10 ст.л.муки и разрыхлитель.Тщательно перемешайте.Тесто получится средней густоты.", "Шаг 1", 3 },
                    { 5, "Взбейте миксером холодные сливки до кремообразной консистенции. Затем смешайте их со сгущёнкой.", "Шаг 1", 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Steps",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
