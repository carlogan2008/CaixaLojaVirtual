using CaixaLojaVirtual.Pagamentos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaixaLojaVirtual.Pagamentos.Data.Mappings
{
    public class PagamentoMapping : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Valor)
                .IsRequired();

            builder.Property(c => c.TipoPagamento)
                .IsRequired();

            builder.Property(c => c.DataRecebimento)
                .IsRequired();
        }
    }
}
