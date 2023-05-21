using AutoMapper;
using CaixaLojaVirtual.Pagamentos.Application.ViewModels;
using CaixaLojaVirtual.Pagamentos.Domain;

namespace CaixaLojaVirtual.Pagamentos.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pagamento, PagamentoViewModel>();
        }
    }
}
