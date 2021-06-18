using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations.Migrations
{
    public partial class AddUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "Login", "Name", "Password" },
                values: new object[] { 2, "", "vasya", "Василий", "abcd" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "Login", "Name", "Password" },
                values: new object[] { 3, "На маму не кричи, она не виновата, что у тебя не все как надо…", "artem228", "Боевик", "bezymno mozno bit pervim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
