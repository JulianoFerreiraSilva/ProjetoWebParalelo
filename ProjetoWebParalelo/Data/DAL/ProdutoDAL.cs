using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Data.DAL
{
    public class ProdutoDAL
    {
        private AcessoContext _cont;
        public ProdutoDAL(AcessoContext context)
        {
            _cont = context;
        }

        public IQueryable<Produto> ListaProdutos()
        {
            var lista = _cont.Produtos.Include(f => f.Fabricante).OrderBy(p => p.Nome);
            return lista;
        }

        public async Task<Produto> CadastraAtualiza(Produto produto)
        {
            if(produto == null)
            {
                _cont.Produtos.Add(produto);
            }
            else
            {
                _cont.Produtos.Update(produto); 
            }
            await _cont.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> RemoverProduto(Produto produto)
        {
            _cont.Produtos.Remove(produto);
            await _cont.SaveChangesAsync();
            return produto;
        }

        public async Task<Produto> ObterProdutoPorId(int? id)
        {
            var produtoId = await _cont.Produtos.SingleOrDefaultAsync(p => p.ProdutoId == id);
            _cont.Fabricantes.Where(f => produtoId.FabricanteId == f.FabricanteId).Load();
            return produtoId;
        }
    }
}
