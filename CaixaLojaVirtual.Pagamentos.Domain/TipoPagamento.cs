using System.ComponentModel.DataAnnotations;

namespace CaixaLojaVirtual.Pagamentos.Domain
{
    public enum TipoPagamento : byte
    {
        [Display(Name = "Débito")]
        Debito = 0,

        [Display(Name = "Crédito")]
        Credito = 1,
    }
}
