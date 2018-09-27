using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ControleAtividade.Models
{
    [Table("Atividade")]
    public class Atividade
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string Descricao { get; set; }

        [Required]
        public string Tipo { get; set; }

        [ForeignKey("Professor")]
        [Required]
        public int IdProfessor { get; set; }

        [NotMapped]
        public Professor Professor { get; set; }

        public virtual List<Questao> ListaQuestao { get; set; }
    }
}
