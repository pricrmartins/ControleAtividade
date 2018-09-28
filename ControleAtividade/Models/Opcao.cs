using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Opcao")]
    public class Opcao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo descrição é obrigatório.")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [ForeignKey("Questao")]
        [Required]
        public int IdQuestao { get; set; }
        
        public Questao Questao { get; set; }

        public Opcao_Correta Opcao_Correta { get; set; }
    }
}
