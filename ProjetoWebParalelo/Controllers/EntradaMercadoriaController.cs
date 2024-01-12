using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Modelo.Cadastro;
using ProjetoWebParalelo.Data;
using ProjetoWebParalelo.Data.DAL;
using System.Linq;

namespace ProjetoWebParalelo.Controllers
{
    public class EntradaMercadoriaController : Controller
    {
        private EntradaMercadoriaDAL _ent;

        public EntradaMercadoriaController(AcessoContext Ent)
        {
            this._ent = new EntradaMercadoriaDAL(Ent);
        }
        // GET: EntradaMercadoriaController
        public ActionResult Index()
        {
            var lista = _ent.ListaDeEntrada().ToList();
            return View(lista);
        }

        // GET: EntradaMercadoriaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EntradaMercadoriaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EntradaMercadoriaController/Create
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

        // GET: EntradaMercadoriaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EntradaMercadoriaController/Edit/5
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

        // GET: EntradaMercadoriaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EntradaMercadoriaController/Delete/5
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
