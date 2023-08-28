using Microsoft.AspNetCore.Mvc.ViewFeatures.Buffers;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Data.DAL
{
    public class EntradaMercadoriaDAL
    {
        private AcessoContext _cont;

        public EntradaMercadoriaDAL(AcessoContext cont)
        {
            this._cont = cont;
        }

        public async Task<EntradaMercadoria>SelecionaItem(int id)
        {
            var entrada = await _cont.Entrada.Where(i => i.Produto.ProdutoId == id).FirstAsync();
            return entrada;
        }
        public async Task<EntradaMercadoria> Entrada(EntradaMercadoria entrada)
        {
            await _cont.Entrada.AddAsync(entrada);
            return entrada;
        }
    }
}
