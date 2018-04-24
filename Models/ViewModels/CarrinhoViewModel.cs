using System.Collections.Generic;
using System.Linq;

namespace CasaDoCodigo.Models.ViewModels
{
    public class CarrinhoViewModel
    {
        public List<ItemPedido> Itens { get; set; }

        public decimal Total => Itens.Sum(i => i.Subtotal);

        public CarrinhoViewModel(List<ItemPedido> items) => Itens = items;
    }
}