using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Opcao_Correta")]
    public class Opcao_Correta
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public bool Correta { get; set; }

        [ForeignKey("Opcao")]
        [Required]
        public int IdOpcao { get; set; }

        public Opcao Opcao { get; set; }
    }
}
