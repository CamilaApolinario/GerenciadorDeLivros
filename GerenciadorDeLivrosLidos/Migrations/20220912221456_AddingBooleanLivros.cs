using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorDeLivrosLidos.Migrations
{
    public partial class AddingBooleanLivros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Lido",
                table: "Livros",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Lido",
                table: "Livros");
        }
    }
}
