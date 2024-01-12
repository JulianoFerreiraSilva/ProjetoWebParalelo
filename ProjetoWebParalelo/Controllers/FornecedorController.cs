using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjetoWebParalelo.Data;
using Modelo.Cadastro;
using System.Threading.Tasks;
using ProjetoWebParalelo.Data.DAL;

namespace ProjetoWebParalelo.Controllers
{
    public class FornecedorController : Controller
    {
        private AcessoContext _context;
        private FornecedorDAL _acesso;
        public FornecedorController(AcessoContext contexto)
        {
            this._context = contexto;
            _acesso = new FornecedorDAL(contexto);
        }

        // GET: FornecedorController1
        public async Task<IActionResult> Index()
        {
            var lista = await _acesso.ListaFornecedores().ToListAsync();
            return View(lista);
        }

        // GET: FornecedorController1/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var detalhes = await _acesso.SelecionaFornecedorPorId(id);
            return View(detalhes);
        }

        // GET: FornecedorController1/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FornecedorController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _acesso.AdicionaAtualiza(fornecedor);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Algo inesperado aconteceu, verifique os dados e tente novamente");
            }
            return View(fornecedor);
        }

        // GET: FornecedorController1/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var resultado = await _acesso.SelecionaFornecedorPorId(id);
            return View(resultado);
        }

        // POST: FornecedorController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _acesso.AdicionaAtualiza(fornecedor);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException)
            {
                ModelState.AddModelError("", "Verifique por gentileza os dados da atualização!!!");
            }
            return View(fornecedor);

        }

        // GET: FornecedorController1/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var resultado = await _acesso.SelecionaFornecedorPorId(id);
            if (resultado == null)
            {
                return NotFound();
            }
            return View(resultado);
        }

        // POST: FornecedorController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(Fornecedor fornecedor)
        {
            try
            {
                if (ModelState.IsValid) 
                {
                    await _acesso.RemoveFornecedor(fornecedor);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch(DbUpdateException)
            {
                ModelState.AddModelError("", "Algo deu errado, verifique a situação e tente novamente!");
                return View(fornecedor);
            }
            return View(fornecedor);
        }
    }
}
