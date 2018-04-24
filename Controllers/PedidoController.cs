using CasaDoCodigo.Data;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller
    {
        private readonly DataService _dataService;

        public PedidoController(DataService dataService) => _dataService = dataService;

        public IActionResult Carrossel() => View(_dataService.GetProdutos());

        public IActionResult Carrinho(int? produtoId)
        {
            if (produtoId.HasValue) _dataService.AddItemPedido(produtoId.Value);

            return View(GetCarrinhoViewModel());
        }

        public IActionResult Cadastro()
        {
            var pedido = _dataService.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel");
            }
            else
            {
                return View(pedido);   
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Resumo(Pedido cadastro)
        {
            if (ModelState.IsValid)
            {
                var pedido = _dataService.UpdateCadastro(cadastro);

                return View(cadastro);
            }
            else
            {
                return RedirectToAction("Cadastro");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateItemPedidoResponse PostQuantidade([FromBody] ItemPedido item) => 
            _dataService.UpdateItemPedido(item);

        private CarrinhoViewModel GetCarrinhoViewModel()
        {
            var itensCarrinho = _dataService.GetItensPedido();

            return new CarrinhoViewModel(itensCarrinho);
        }
    }
}