using System.Runtime.Serialization;

namespace CasaDoCodigo.Models
 {
     public class Produto : BaseModel
     {
         [DataMember]
         public string Nome { get; set; }
         
         [DataMember]
         public decimal Preco { get; set; }
     }
 }