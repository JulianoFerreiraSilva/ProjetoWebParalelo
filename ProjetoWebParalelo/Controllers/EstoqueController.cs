using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebParalelo.Data;
using ProjetoWebParalelo.Data.DAL;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Controllers
{
    public class EstoqueController : Controller
    {
        private EstoqueDAL est;
        private AcessoContext _cont;
        public EstoqueController(AcessoContext cont)
        {
            est = new EstoqueDAL(cont);
        }
        // GET: EstoqueController
        public async Task<IActionResult> Index()
        {
            var lista = await est.ListaEstoque().ToListAsync();
            return View(lista);
        }

        // GET: EstoqueController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var estoque = await est.SelecionaEstoque(id);
            return View(estoque);
        }

        // GET: EstoqueController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstoqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstoqueController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EstoqueController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EstoqueController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EstoqueController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
