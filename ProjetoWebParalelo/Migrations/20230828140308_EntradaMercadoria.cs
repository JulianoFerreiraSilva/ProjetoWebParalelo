using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebParalelo.Migrations
{
    public partial class EntradaMercadoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EntradaMercadoria",
                columns: table => new
                {
                    EntradaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProdutoId = table.Column<int>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaMercadoria", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_EntradaMercadoria_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EntradaMercadoria_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EntradaMercadoria_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EntradaMercadoria_EstoqueId",
                table: "EntradaMercadoria",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaMercadoria_FornecedorId",
                table: "EntradaMercadoria",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_EntradaMercadoria_ProdutoId",
                table: "EntradaMercadoria",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EntradaMercadoria");
        }
    }
}
