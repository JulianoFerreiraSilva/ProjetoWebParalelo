using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Data.DAL
{
    public class FabricanteDAL
    {
        private AcessoContext _cont;

        public FabricanteDAL(AcessoContext context)
        {
            this._cont = context;
        }
        
        public IQueryable<Fabricante> ListaFabricantes()
        {
            var lista = _cont.Fabricantes.OrderBy(f => f.Nome);
            return lista;
        }


        public async Task<Fabricante> ObterPorId(int? id)
        {
            var retorno = await _cont.Fabricantes.FirstOrDefaultAsync(f => f.FabricanteId == id);
            return retorno;
        }

        public async Task<Fabricante> AdicionaAtualiza(Fabricante fabricante)
        {
            if(fabricante == null)
            {
                _cont.Fabricantes.Add(fabricante);
            }
            else
            {
                _cont.Fabricantes.Update(fabricante);
            }
            await _cont.SaveChangesAsync();
            return fabricante;
        }

        public async Task<Fabricante> RemoveFabricante(Fabricante fabricante)
        {
            _cont.Fabricantes.Remove(fabricante);
            await _cont.SaveChangesAsync();
            return fabricante;
        }

    }
}
