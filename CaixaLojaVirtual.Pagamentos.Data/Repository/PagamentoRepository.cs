using CaixaLojaVirtual.Core.Data;
using CaixaLojaVirtual.Pagamentos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaixaLojaVirtual.Pagamentos.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly PagamentoContext _context;

        public PagamentoRepository(PagamentoContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task<IEnumerable<Pagamento>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => await _context.Pagamentos.AsNoTracking().ToListAsync(cancellationToken);

        public async Task<Pagamento> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => await _context.Pagamentos.AsNoTracking().FirstAsync(p => p.Id == id, cancellationToken);

        public async Task AdicionarAsync(Pagamento pagamento, CancellationToken cancellationToken)
            => await _context.Pagamentos.AddAsync(pagamento, cancellationToken);

        public void Atualizar(Pagamento pagamento)
            => _context.Pagamentos.Update(pagamento);

        public void Excluir(Pagamento pagamento)
            => _context.Pagamentos.Remove(pagamento);

        public void Dispose() => _context?.Dispose();
    }
}
