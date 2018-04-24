using Microsoft.EntityFrameworkCore;

namespace CasaDoCodigo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}