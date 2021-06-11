using Microsoft.EntityFrameworkCore.Migrations;

namespace RelatoriosVendasMVC.Migrations
{
    public partial class Correcao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Departamento",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Nome",
                table: "Departamento",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
