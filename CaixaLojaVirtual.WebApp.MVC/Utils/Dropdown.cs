using CaixaLojaVirtual.Pagamentos.Domain;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CaixaLojaVirtual.WebApp.MVC.Utils
{
    public static class Dropdown
    {
        public static SelectList GetTipoPagamento()
        {
            return new SelectList(Enum.GetValues(typeof(TipoPagamento))
                .Cast<TipoPagamento>()
                .Select(v => new SelectListItem
                {
                    Text = v.GetDisplay(),
                    Value = ((int)v).ToString()
                })
                .ToList(), "Value", "Text");
        }
    }
}
