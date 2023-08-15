using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebParalelo.Migrations
{
    public partial class AddEstoque : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EstoqueId",
                table: "EntradaMercadorias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    EstoqueId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantidade = table.Column<int>(nullable: true),
                    ValorUnitario = table.Column<decimal>(type: "money", nullable: false),
                    EntradaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.EstoqueId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaMercadorias_EstoqueId",
                table: "EntradaMercadorias",
                column: "EstoqueId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EntradaMercadorias_Estoque_EstoqueId",
                table: "EntradaMercadorias",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "EstoqueId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Estoque_EstoqueId",
                table: "Produtos",
                column: "EstoqueId",
                principalTable: "Estoque",
                principalColumn: "EstoqueId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EntradaMercadorias_Estoque_EstoqueId",
                table: "EntradaMercadorias");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Estoque_EstoqueId",
                table: "Produtos");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EstoqueId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_EntradaMercadorias_EstoqueId",
                table: "EntradaMercadorias");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "EstoqueId",
                table: "EntradaMercadorias");
        }
    }
}
