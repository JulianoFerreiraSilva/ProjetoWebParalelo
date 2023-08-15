using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebParalelo.Data;
using Modelo.Cadastro;
using System.Threading.Tasks;
using ProjetoWebParalelo.Data.DAL;

namespace ProjetoWebParalelo.Controllers
{
    public class FabricanteController : Controller
    {
        private AcessoContext _context;
        private FabricanteDAL _acesso;

        public FabricanteController(AcessoContext context)
        {            
            this._context = context;
            _acesso = new FabricanteDAL(context);
        }
        public async Task<IActionResult> BuscarPorId(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var fabricante = await _acesso.ObterPorId(id);
            if(fabricante == null)
            {
                return NotFound();
            }
            return View(fabricante);
        }

        // GET: FabricanteController
        public async Task<IActionResult> Index()
        {            
            return View(await _acesso.ListaFabricantes().ToListAsync());
        }

        // GET: FabricanteController/Details/5
        public async Task<IActionResult> Details(int id)
        {
           var fabricante = await BuscarPorId(id);
            return fabricante;
        }

        // GET: FabricanteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FabricanteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fabricante fabricante)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _acesso.AdicionaAtualiza(fabricante);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("","Não foi possivel cadastrar o fabricante, verifique as informações!!!");
            }
            return View(fabricante);
        }

        // GET: FabricanteController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var fabricante = await BuscarPorId(id);
            return fabricante;
        }

        // POST: FabricanteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Fabricante fabricante)
        {
            if(fabricante.FabricanteId != null)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        await _acesso.AdicionaAtualiza(fabricante);
                        return RedirectToAction(nameof(Index));
                    }
                    catch(DbUpdateException)
                    {
                        ModelState.AddModelError("", "Algo deu errado, verifique os dados da atualização!!!");
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Fabricante não encontrado!!!");
            }
            return View(fabricante);
        }

        // GET: FabricanteController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var fabricante = await BuscarPorId(id);
            return fabricante;
        }

        // POST: FabricanteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Fabricante fabricante)
        {
            var resultado = await _acesso.RemoveFabricante(fabricante);
            //TempData["Message"] = "Fabricante " + fabricante.Nome.ToUpper() + " Foi removido com sucesso!!!";
            return RedirectToAction(nameof(Index));
        }
    }
}
