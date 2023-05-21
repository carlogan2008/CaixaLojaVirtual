using AutoMapper;
using CaixaLojaVirtual.Pagamentos.Application.ViewModels;
using CaixaLojaVirtual.Pagamentos.Domain;

namespace CaixaLojaVirtual.Pagamentos.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PagamentoViewModel, Pagamento>()
                .ConstructUsing(p =>
                    new Pagamento(p.Valor, p.TipoPagamento, p.DataRecebimento));
        }
    }
}
