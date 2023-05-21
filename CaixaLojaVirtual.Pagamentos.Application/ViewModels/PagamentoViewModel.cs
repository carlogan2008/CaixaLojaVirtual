using CaixaLojaVirtual.Pagamentos.Domain;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CaixaLojaVirtual.Pagamentos.Application.ViewModels
{
    [Display(Name = "Pagamentos")]
    public class PagamentoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public double Valor { get; set; }

        [Display(Name = "Data de Recebimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public DateTime DataRecebimento { get; set; }

        [Display(Name = "Tipo de Pagamento")]
        [EnumDataType(typeof(TipoPagamento), ErrorMessage = "O campo {0} é obrigatório")]
        [JsonConverter(typeof(StringEnumConverter))]
        public TipoPagamento TipoPagamento { get; set; }
    }
}
