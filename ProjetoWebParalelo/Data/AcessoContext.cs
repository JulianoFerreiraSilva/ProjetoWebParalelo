using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;

namespace ProjetoWebParalelo.Data
{
    public class AcessoContext : DbContext
    {
        public AcessoContext(DbContextOptions<AcessoContext> options) : base(options) 
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<EntradaMercadoria> Entrada { get; set; }
    }
}
