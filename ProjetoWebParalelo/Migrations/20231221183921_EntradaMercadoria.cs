using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebParalelo.Migrations
{
    public partial class EntradaMercadoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Entrada",
                columns: table => new
                {
                    EntradaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    ProdutoId = table.Column<int>(nullable: false),
                    EstoqueId = table.Column<int>(nullable: false),
                    QuantidadeEntrada = table.Column<int>(nullable: false),
                    ValorUnitario = table.Column<decimal>(type: "money", nullable: false),
                    FornecedorId = table.Column<int>(nullable: false),
                    ValorTotal = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Entrada", x => x.EntradaId);
                    table.ForeignKey(
                        name: "FK_Entrada_Estoque_EstoqueId",
                        column: x => x.EstoqueId,
                        principalTable: "Estoque",
                        principalColumn: "EstoqueId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "FornecedorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Entrada_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "ProdutoId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_EstoqueId",
                table: "Entrada",
                column: "EstoqueId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_FornecedorId",
                table: "Entrada",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrada_ProdutoId",
                table: "Entrada",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Entrada");
        }
    }
}
