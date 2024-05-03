using System.ComponentModel.DataAnnotations;

namespace MiniMundo.Models
{
    public class Produto
{
        [Key]
        public int ProdutoID { get; set; }


        [Required]
        public string Nome { get; set; }


        [Display(Name = "Preço")]
        public decimal Preco {  get; set; }


        [Required]
        public int Quantidade { get; set; }
        
}
}
