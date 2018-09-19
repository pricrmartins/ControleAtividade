using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Resposta_Atividade")]
    public class Resposta_Atividade
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Atividade_Turma")]
        [Required]
        public int IdAtividade_Turma { get; set; }

        [ForeignKey("Aluno")]
        [Required]
        public int IdAluno { get; set; }

        [NotMapped]
        public Atividade_Turma Atividade_Turma { get; set; }

        public Aluno Aluno { get; set; }

        public virtual List<Resposta_Opcao> ListaRespostaOpcao { get; set; }
    }
}
