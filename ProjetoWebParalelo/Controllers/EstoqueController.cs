using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Modelo.Cadastro;
using ProjetoWebParalelo.Data;
using ProjetoWebParalelo.Data.DAL;
using System.Threading.Tasks;

namespace ProjetoWebParalelo.Controllers
{
    public class EstoqueController : Controller
    {
        private EstoqueDAL _est;
        private ProdutoDAL _prod;
        private EntradaMercadoriaDAL _ent;

        public EstoqueController(AcessoContext cont)
        {
            _est = new EstoqueDAL(cont);
            _prod = new ProdutoDAL(cont);
            _ent = new EntradaMercadoriaDAL(cont);
        }

        public async Task<IActionResult> SelecionaPorId(int id)
        {
            return View(await _est.SelecionaEstoque(id));
        }
        // GET: EstoqueController
        public async Task<IActionResult> Index()
        {
            var lista = await _est.ListaEstoque().ToListAsync();
            return View(lista);
        }

        // GET: EstoqueController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var estoque = await _est.SelecionaEstoque(id);
            if (estoque == null)
            {
                return NotFound();
            }
            return View(estoque);
        }

        // GET: EstoqueController/Create
        public async Task<IActionResult> EntradaMercadoria()
        {
            var produtos = await _ent.ListaProdutosEntrada().ToListAsync();
            produtos.Insert(0, new Produto() { ProdutoId = 0, Nome = "Selecione o Produto"});
            ViewBag.Produtos = produtos;

            var fornecedores = await _ent.ListaFornecedores().ToListAsync();
            fornecedores.Insert(0, new Fornecedor() { FornecedorId = 0, RazaoSocial = "Selecione o Fornecedor" });
            ViewBag.Fornecedores = fornecedores;
            return View();
        }

        // POST: EstoqueController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EntradaMercadoria(EntradaMercadoria entrada, Estoque estoque)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _ent.Entrada(entrada, estoque);
                    
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View(entrada);
                }
            }
            return View(entrada);
        }

        // GET: EstoqueController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            ViewResult visaoEstoque = (ViewResult)await SelecionaPorId(id);
            Estoque estoqueProdutoFabricante = (Estoque)visaoEstoque.Model;
            ViewBag.Produtos = new SelectList(_prod.ListaProdutos(), "ProdutoId", "Nome",
                estoqueProdutoFabricante.ProdutoId);
                return visaoEstoque;
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
