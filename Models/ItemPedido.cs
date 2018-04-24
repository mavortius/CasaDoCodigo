using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
{
    public class ItemPedido : BaseModel
    {
        [DataMember]
        [Required]
        public Pedido Pedido { get; set; }
        
        [DataMember]
        [Required]
        public Produto Produto { get; set; }
        
        [DataMember]
        public int Quantidade { get; set; }
        
        [DataMember]
        public decimal PrecoUnitario{ get; set; }

        [DataMember]
        public decimal Subtotal => Quantidade * PrecoUnitario;
    }
}