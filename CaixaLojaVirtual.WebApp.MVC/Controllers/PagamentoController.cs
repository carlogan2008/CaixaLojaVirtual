using Microsoft.AspNetCore.Mvc;
using CaixaLojaVirtual.Pagamentos.Application.ViewModels;
using CaixaLojaVirtual.Pagamentos.Application.Services;
using Microsoft.AspNetCore.Authorization;

namespace CaixaLojaVirtual.WebApp.MVC.Controllers
{
    [Authorize]
    public class PagamentoController : Controller
    {
        private readonly IPagamentoAppService _pagamentoAppService;

        public PagamentoController(IPagamentoAppService pagamentoAppService)
        {
            _pagamentoAppService = pagamentoAppService;
        }

        // GET: Pagamento
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
            => View(await _pagamentoAppService.ObterTodosAsNoTrackingAsync(cancellationToken));

        // GET: Pagamento/Details/5
        public async Task<IActionResult> Details(Guid id, CancellationToken cancellationToken)
            => View(await _pagamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // GET: Pagamento/Create
        public IActionResult Create()
            => View();

        // POST: Pagamento/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,DataRecebimento,TipoPagamento")] PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken)
        {
            if (!ModelState.IsValid)
                return View(pagamentoViewModel);

            await _pagamentoAppService.AdicionarAsync(pagamentoViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pagamento/Edit/5
        public async Task<IActionResult> Edit(Guid id, CancellationToken cancellationToken)
            => View(await _pagamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Pagamento/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Valor,DataRecebimento,TipoPagamento")] PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken)
        {
            if (id != pagamentoViewModel.Id)
                return NotFound();

            if (!ModelState.IsValid)
                return View(pagamentoViewModel);

            await _pagamentoAppService.AtualizarAsync(pagamentoViewModel, cancellationToken);
            return RedirectToAction(nameof(Index));
        }

        // GET: Pagamento/Delete/5
        public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
            => View(await _pagamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        // POST: Pagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id, CancellationToken cancellationToken)
        {
            var pagamento = await _pagamentoAppService.ObterPorIdAsNoTrackingAsync(id, cancellationToken);
            await _pagamentoAppService.ExcluirAsync(pagamento, cancellationToken);
            return RedirectToAction(nameof(Index));
        }
    }
}
