using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Data.DAL
{
    public class FornecedorDAL
    {
        private AcessoContext _cont;

        public FornecedorDAL(AcessoContext cont)
        {
            this._cont = cont;
        }

        public FornecedorDAL()
        {
        }

        public IQueryable<Fornecedor> ListaFornecedores()
        {
            var lista = _cont.Fornecedores.OrderBy(f => f.RazaoSocial);
            return lista;
        }

        public async Task<Fornecedor> SelecionaFornecedorPorId(int id)
        {
            var resultado = await _cont.Fornecedores.FindAsync(id);
            return resultado;
        }

        public async Task<Fornecedor> AdicionaAtualiza(Fornecedor fornecedor)
        {
            if(fornecedor == null)
            {
                var add = _cont.Fornecedores.Add(fornecedor);
            }
            else
            {
                _cont.Fornecedores.Update(fornecedor);
            }
            await _cont.SaveChangesAsync();
            return fornecedor;
        }

        public async Task<Fornecedor>RemoveFornecedor(Fornecedor fornecedor)
        {
            _cont.Fornecedores.Remove(fornecedor);
            await _cont.SaveChangesAsync();
            return fornecedor;
        }
    }
}
