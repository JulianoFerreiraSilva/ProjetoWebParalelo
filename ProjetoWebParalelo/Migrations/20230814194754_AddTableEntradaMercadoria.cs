using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoWebParalelo.Migrations
{
    public partial class AddTableEntradaMercadoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CodProdutoFornecedor",
                table: "ProdutosFornecedores",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EntradaMercadoriaEntradaId",
                table: "ProdutosFornecedores",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EntradaMercadoriaEntradaId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EntradaMercadorias",
                columns: table => new
                {
                    EntradaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    NotaFornecedor = table.Column<long>(nullable: true),
                    Produto = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: true),
                    ValorUnitarioProduto = table.Column<decimal>(type: "money", nullable: false),
                    ValorTotalProduto = table.Column<decimal>(type: "money", nullable: false),
                    ValorTotalNota = table.Column<decimal>(type: "money", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntradaMercadorias", x => x.EntradaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutosFornecedores_EntradaMercadoriaEntradaId",
                table: "ProdutosFornecedores",
                column: "EntradaMercadoriaEntradaId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_EntradaMercadoriaEntradaId",
                table: "Produtos",
                column: "EntradaMercadoriaEntradaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_EntradaMercadorias_EntradaMercadoriaEntradaId",
                table: "Produtos",
                column: "EntradaMercadoriaEntradaId",
                principalTable: "EntradaMercadorias",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutosFornecedores_EntradaMercadorias_EntradaMercadoriaEntradaId",
                table: "ProdutosFornecedores",
                column: "EntradaMercadoriaEntradaId",
                principalTable: "EntradaMercadorias",
                principalColumn: "EntradaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_EntradaMercadorias_EntradaMercadoriaEntradaId",
                table: "Produtos");

            migrationBuilder.DropForeignKey(
                name: "FK_ProdutosFornecedores_EntradaMercadorias_EntradaMercadoriaEntradaId",
                table: "ProdutosFornecedores");

            migrationBuilder.DropTable(
                name: "EntradaMercadorias");

            migrationBuilder.DropIndex(
                name: "IX_ProdutosFornecedores_EntradaMercadoriaEntradaId",
                table: "ProdutosFornecedores");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_EntradaMercadoriaEntradaId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "CodProdutoFornecedor",
                table: "ProdutosFornecedores");

            migrationBuilder.DropColumn(
                name: "EntradaMercadoriaEntradaId",
                table: "ProdutosFornecedores");

            migrationBuilder.DropColumn(
                name: "EntradaMercadoriaEntradaId",
                table: "Produtos");
        }
    }
}
