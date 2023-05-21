using CaixaLojaVirtual.Pagamentos.Application.ViewModels;

namespace CaixaLojaVirtual.Pagamentos.Application.Services
{
    public interface IPagamentoAppService : IDisposable
    {
        Task<PagamentoViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<PagamentoViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task AdicionarAsync(PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken);
        Task AtualizarAsync(PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken);
        Task ExcluirAsync(PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken);
    }
}
