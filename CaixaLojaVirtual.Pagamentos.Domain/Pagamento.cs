using CaixaLojaVirtual.Core.DomainObjects;

namespace CaixaLojaVirtual.Pagamentos.Domain
{
    public class Pagamento : Entity
    {
        public double Valor { get; private set; }
        public DateTime DataRecebimento { get; set; }
        public TipoPagamento TipoPagamento { get; private set; }

        protected Pagamento()
        {
        }

        public Pagamento(double valor, TipoPagamento tipoPagamento, DateTime dataRecebimento)
        {
            Valor = valor;
            TipoPagamento = tipoPagamento;
            DataRecebimento = dataRecebimento;
            Validar();
        }

        public void Validar()
        {
            Validacoes.ValidarMinimoMaximo(Valor, double.MinValue, double.MaxValue, "O campo Valor do pagamento é inválido.");
            Validacoes.ValidarSeNulo(TipoPagamento, "O campo TipoPagamento não pode estar vazio");
            Validacoes.ValidarSeNulo(DataRecebimento, "O campo DataRecebimento não pode estar vazio");
        }
    }
}
