using CaixaLojaVirtual.Core.Data;
using CaixaLojaVirtual.Pagamentos.Domain;
using Microsoft.EntityFrameworkCore;

namespace CaixaLojaVirtual.Pagamentos.Data
{
    public class PagamentoContext : DbContext, IUnitOfWork
    {
        public PagamentoContext(DbContextOptions<PagamentoContext> options) : base(options)
        {
        }

        public DbSet<Pagamento> Pagamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PagamentoContext).Assembly);
        }

        public async Task<bool> CommitAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync(cancellationToken) > 0;
        }
    }
}
