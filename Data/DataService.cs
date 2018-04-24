using System.Collections.Generic;
using System.Linq;
using CasaDoCodigo.Models;
using CasaDoCodigo.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Data
{
    public class DataService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataService(ApplicationDbContext dbContext, IHttpContextAccessor httpContextAccessor)
        {
            _dbContext = dbContext;
            _httpContextAccessor = httpContextAccessor;
        }

        public void InitializeDb()
        {
            _dbContext.Database.EnsureCreated();

            if (_dbContext.Produtos.Any()) return;

            var produtos = new List<Produto>
            {
                new Produto {Nome = "Sleep not found", Preco = 59.90m},
                new Produto {Nome = "May the code be with you", Preco = 59.90m},
                new Produto {Nome = "Rollback", Preco = 59.90m},
                new Produto {Nome = "REST", Preco = 69.90m},
                new Produto {Nome = "Design Patterns com Java", Preco = 69.90m},
                new Produto {Nome = "Vire o jogo com Spring Framework", Preco = 69.90m},
                new Produto {Nome = "Test-Driven Development", Preco = 69.90m},
                new Produto {Nome = "iOS: Programe para iPhone e iPad", Preco = 69.90m},
                new Produto {Nome = "Desenvolvimento de Jogos para Android", Preco = 69.90m}
            };

            _dbContext.AddRange(produtos);
            _dbContext.SaveChanges();
        }

        public List<Produto> GetProdutos() => _dbContext.Produtos.ToList();

        public List<ItemPedido> GetItensPedido()
        {
            var pedidoId = GetSessionPedidoId();
            var pedido = _dbContext.Pedidos.Single(p => p.Id == pedidoId);

            return _dbContext.ItensPedido
                .Include(i => i.Produto)
                .Where(i => i.Pedido.Id == pedido.Id)
                .ToList();
        }

        public void AddItemPedido(int produtoId)
        {
            var produto = _dbContext.Produtos.SingleOrDefault(p => p.Id == produtoId);

            if (produto != null)
            {
                var pedidoId = GetSessionPedidoId();
                Pedido pedido = null;

                if (pedidoId.HasValue)
                {
                    pedido = _dbContext.Pedidos.SingleOrDefault(p => p.Id == pedidoId.Value);
                }

                if (pedido == null)
                {
                    pedido = new Pedido();
                }

                if (!_dbContext.ItensPedido.Any(i => i.Pedido.Id == pedido.Id && i.Produto.Id == produtoId))
                {
                    _dbContext.ItensPedido.Add(
                        new ItemPedido
                        {
                            Pedido = pedido,
                            Produto = produto,
                            PrecoUnitario = produto.Preco,
                            Quantidade = 1
                        });
                    _dbContext.SaveChanges();
                    SetSessionPedidoId(pedido);
                }
            }
        }

        public UpdateItemPedidoResponse UpdateItemPedido(ItemPedido item)
        {
            var itemDb = _dbContext.ItensPedido.SingleOrDefault(i => i.Id == item.Id);

            if (itemDb != null)
            {
                itemDb.Quantidade = item.Quantidade;
                _dbContext.SaveChanges();
            }

            var itensPedido = _dbContext.ItensPedido.ToList();
            var carrinho = new CarrinhoViewModel(itensPedido);

            return new UpdateItemPedidoResponse
            {
                CarrinhoViewModel = carrinho,
                ItemPedido = itemDb
            };
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetSessionPedidoId();

            return _dbContext.Pedidos
                .Include(p => p.Itens)
                .ThenInclude(p => p.Produto)
                .SingleOrDefault(p => p.Id == pedidoId);
        }

        public Pedido UpdateCadastro(Pedido cadastro)
        {
            var pedido = GetPedido();
            
            pedido.UpdateCadastro(cadastro);
            _dbContext.SaveChanges();

            return pedido;
        }

        private int? GetSessionPedidoId() =>
            _httpContextAccessor.HttpContext.Session.GetInt32("pedidoId");

        private void SetSessionPedidoId(Pedido pedido) =>
            _httpContextAccessor.HttpContext.Session.SetInt32("pedidoId", pedido.Id);
    }
}