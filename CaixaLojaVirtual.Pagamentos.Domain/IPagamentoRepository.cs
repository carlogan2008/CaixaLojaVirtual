using CaixaLojaVirtual.Core.Data;

namespace CaixaLojaVirtual.Pagamentos.Domain
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        Task<IEnumerable<Pagamento>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken);
        Task<Pagamento> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken);

        Task AdicionarAsync(Pagamento pagamento, CancellationToken cancellationToken);
        void Atualizar(Pagamento pagamento);
        void Excluir(Pagamento pagamento);
    }
}
