using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Data.DAL
{
    public class EstoqueDAL
    {
        private AcessoContext _cont;
        public EstoqueDAL(AcessoContext cont)
        {
            this._cont = cont;
        }

        public IQueryable<Estoque> ListaEstoque()
        {
            var lista = _cont.Estoque.Include(p => p.Produto).
                Include(p => p.Produto.Fabricante).OrderBy( p => p.Produto.Nome);
            return lista;
        }

        public async Task<Estoque> Atualiza(Estoque estoque)
        {
            _cont.Estoque.Update(estoque);
            await _cont.SaveChangesAsync();
            return estoque;
        }

        public async Task<Estoque> SelecionaEstoque(int id)
        {
            var estoque = await _cont.Estoque.SingleOrDefaultAsync(e => e.EstoqueId == id);
            _cont.Estoque.Where(e => estoque.ProdutoId == e.Produto.ProdutoId).
                Include(e => estoque.Produto.FabricanteId == e.Produto.FabricanteId).LoadAsync();
            return estoque;
        }
    }
}
