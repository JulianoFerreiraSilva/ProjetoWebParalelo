using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoWebParalelo.Data;
using Modelo.Cadastro;
using System.Threading.Tasks;
using ProjetoWebParalelo.Data.DAL;

namespace ProjetoWebParalelo.Controllers
{
    public class ProdutoController : Controller
    {
        private readonly ProdutoDAL _acesso;
        private readonly FabricanteDAL _fab;

        public ProdutoController(AcessoContext context)
        {
            _acesso = new ProdutoDAL(context);
            _fab = new FabricanteDAL(context);
        }

        public async Task<IActionResult> BuscaProdutoPorId(int? id)
        {
            return View(await _acesso.ObterProdutoPorId(id));
        }

        // GET: ProdutoController
        public async Task<IActionResult> Index()
        {
            var lista = await _acesso.ListaProdutos().ToListAsync();
            return View(lista);
        }

        // GET: ProdutoController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var produto = await BuscaProdutoPorId(id);
            
            if(produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        // GET: ProdutoController/Create
        public async Task<IActionResult> Create()
        {
            var fabricantes = await _fab.ListaFabricantes().ToListAsync();
            fabricantes.Insert(0, new Fabricante() { FabricanteId = 0, Nome = "Selecione o Fabricante" });
            ViewBag.Fabricantes = fabricantes;

            return View();
        }

        // POST: ProdutoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _acesso.CadastraAtualiza(produto);
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Não foi possivel adicionar o produto, revise as informações!");
                }
            }
            return View(produto);
        }

        // GET: ProdutoController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewResult visaoProduto = (ViewResult)await BuscaProdutoPorId(id);
            Produto produtoFabricante = (Produto)visaoProduto.Model;
            ViewBag.Fabricantes = new SelectList(_fab.ListaFabricantes(), "FabricanteId", "Nome", produtoFabricante.FabricanteId);
            return visaoProduto;
        }

         // POST: ProdutoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Produto produto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _acesso.CadastraAtualiza(produto);
                    return RedirectToAction(nameof(Index));
                }
                catch(DbUpdateException)
                {
                    ModelState.AddModelError("", "Revise os dados, algo esta não conforme!!!");
                }
            }
            return View(produto);
        }

        // GET: ProdutoController/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var produto = await BuscaProdutoPorId(id);
            if (produto == null)
            {
                return NotFound();
            }
            return produto;
        }

        // POST: ProdutoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Produto produto)
        {
            try
            {
                await _acesso.RemoverProduto(produto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(produto);
            }
        }
    }
}
