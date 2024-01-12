using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using System.Linq;

namespace ProjetoWebParalelo.Data.DAL
{
    public class EntradaMercadoriaDAL
    {
        private AcessoContext _cont;

        public EntradaMercadoriaDAL(AcessoContext cont)
        {
            this._cont = cont;
        }

        public IQueryable<EntradaMercadoria> ListaDeEntrada()
        {
            var lista = _cont.Entrada
                .OrderBy(e => e.DataEntrada).Include(p => p.Produto).Include(f => f.Fornecedor);
            return lista;
        }

        public IQueryable<Produto> ListaProdutosEntrada()
        {
            var lista = _cont.Produtos.OrderBy(e => e.Nome);
            return lista;
        }

        public IQueryable<Fornecedor> ListaFornecedores()
        {
            var lista = _cont.Fornecedores.OrderBy(e => e.RazaoSocial);
            return lista;
        }

        public EntradaMercadoria Entrada(EntradaMercadoria entrada, Estoque estoque)
        {
            var verifica = _cont.Estoque.Select(e => e.ProdutoId);
            if(verifica == null)
            {
                _cont.Estoque.Add(estoque);
                _cont.SaveChanges();
            }
            else
            {
                estoque.Quantidade += entrada.QuantidadeEntrada;
                _cont.Estoque.Update(estoque);
            }
            _cont.Entrada.Add(entrada);
            _cont.SaveChanges();
            return entrada;
        }

    }
}
