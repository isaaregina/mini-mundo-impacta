using System.ComponentModel.DataAnnotations;

namespace MiniMundo.Models
{
    public class Funcionario
    {
        [Key]
        public int FuncionarioID { get; set; }


        [Required]
        public string Nome { get; set; }


        [Required]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Insuficiente. Necessário 11 caracteres.")]
        public string CPF { get; set; }


        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data de Cadastro")]       
        public DateTime DatCad {  get; set; }


        [Required]
        [Display(Name = "Salário")]
        public decimal Salario { get; set; }
    }
}
