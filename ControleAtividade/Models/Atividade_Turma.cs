using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Atividade_Turma")]
    public class Atividade_Turma
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public bool Disponivel { get; set; }

        [ForeignKey("Atividade")]
        [Required]
        public int IdAtividade { get; set; }

        [ForeignKey("Turma")]
        [Required]
        public string CodigoTurma { get; set; }

        public Atividade Atividade { get; set; }

        public Turma Turma { get; set; }
    }
}
