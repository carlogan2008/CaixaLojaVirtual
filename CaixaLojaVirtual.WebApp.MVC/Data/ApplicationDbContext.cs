using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CaixaLojaVirtual.Pagamentos.Application.ViewModels;

namespace CaixaLojaVirtual.WebApp.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<CaixaLojaVirtual.Pagamentos.Application.ViewModels.PagamentoViewModel> PagamentoViewModel { get; set; } = default!;
    }
}