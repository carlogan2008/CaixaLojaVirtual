using CaixaLojaVirtual.Pagamentos.Application.Services;
using CaixaLojaVirtual.Pagamentos.Data.Repository;
using CaixaLojaVirtual.Pagamentos.Domain;

namespace CaixaLojaVirtual.WebApp.MVC.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IPagamentoRepository, PagamentoRepository>();
            services.AddScoped<IPagamentoAppService, PagamentoAppService>();
        }
    }
}
