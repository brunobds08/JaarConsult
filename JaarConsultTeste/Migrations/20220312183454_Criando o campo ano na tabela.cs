using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JaarConsultTeste.Migrations
{
    public partial class Criandoocampoanonatabela : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Ano",
                table: "Veiculos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                table: "Veiculos");
        }
    }
}
