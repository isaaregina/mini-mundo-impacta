using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniMundo.Models
{
    public class Venda
    {
        [Key]
        public int VendaID { get; set; }


        [Required]
        [Display(Name ="Funcionário")]
        public int FuncionarioID { get; set; }

        [ForeignKey("FuncionarioID")]
        public Funcionario Funcionario { get; set; }



        [Required]
        [Display(Name = "Produto")]
        public int ProdutoID { get; set; }

        [ForeignKey("ProdutoID")]
        public Produto produto { get; set; }



        [Required]
        [Display(Name = "Data da Venda")]
        public DateTime venda {  get; set; }


    }
}
