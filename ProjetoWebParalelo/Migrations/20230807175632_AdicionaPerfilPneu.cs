using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebParalelo.Migrations
{
    public partial class AdicionaPerfilPneu : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "perfil",
                table: "Produtos",
                newName: "Perfil");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Perfil",
                table: "Produtos",
                newName: "perfil");
        }
    }
}
