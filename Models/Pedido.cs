using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CasaDoCodigo.Models
{
    public class Pedido : BaseModel
    {
        public List<ItemPedido> Itens { get; set; } = new List<ItemPedido>();
        
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve ter entre 5 e 50 caracteres")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "Email é obrigatório")]
        public string Email { get; set; }
        
        [Required]
        public string Telefone { get; set; }
        
        [Required]
        public string Endereco { get; set; }
        public string Complemento { get; set; }
        
        [Required]
        public string Bairro { get; set; }
        
        [Required]
        public string Municipio { get; set; }
        
        [Required]
        public string Uf { get; set; }
        
        [Required]
        public string Cep { get; set; }
        
        public void UpdateCadastro(Pedido cadastro)
        {
            Nome = cadastro.Nome;
            Email = cadastro.Email;
            Telefone = cadastro.Telefone;

            Endereco = cadastro.Endereco;
            Complemento = cadastro.Complemento;
            Bairro = cadastro.Bairro;

            Municipio = cadastro.Municipio;
            Uf = cadastro.Uf;
            Cep = cadastro.Cep;
        }
    }
}