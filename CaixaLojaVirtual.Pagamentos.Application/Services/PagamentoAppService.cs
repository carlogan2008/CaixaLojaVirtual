using AutoMapper;
using CaixaLojaVirtual.Pagamentos.Application.ViewModels;
using CaixaLojaVirtual.Pagamentos.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaixaLojaVirtual.Pagamentos.Application.Services
{
    public class PagamentoAppService : IPagamentoAppService
    {
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMapper _mapper;

        public PagamentoAppService(IPagamentoRepository pagamentoRepository, IMapper mapper)
        {
            _pagamentoRepository = pagamentoRepository;
            _mapper = mapper;
        }

        public async Task<PagamentoViewModel> ObterPorIdAsNoTrackingAsync(Guid id, CancellationToken cancellationToken)
            => _mapper.Map<PagamentoViewModel>(await _pagamentoRepository.ObterPorIdAsNoTrackingAsync(id, cancellationToken));

        public async Task<IEnumerable<PagamentoViewModel>> ObterTodosAsNoTrackingAsync(CancellationToken cancellationToken)
            => _mapper.Map<IEnumerable<PagamentoViewModel>>(await _pagamentoRepository.ObterTodosAsNoTrackingAsync(cancellationToken));

        public async Task AdicionarAsync(PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoViewModel);
            await _pagamentoRepository.AdicionarAsync(pagamento, cancellationToken);

            await _pagamentoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task AtualizarAsync(PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoViewModel);
            _pagamentoRepository.Atualizar(pagamento);

            await _pagamentoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public async Task ExcluirAsync(PagamentoViewModel pagamentoViewModel, CancellationToken cancellationToken)
        {
            var pagamento = _mapper.Map<Pagamento>(pagamentoViewModel);
            _pagamentoRepository.Excluir(pagamento);

            await _pagamentoRepository.UnitOfWork.CommitAsync(cancellationToken);
        }

        public void Dispose()
        {
            _pagamentoRepository?.Dispose();
        }
    }
}
