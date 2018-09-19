using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAtividade.Models
{
    [Table("Resposta_Opcao")]
    public class Resposta_Opcao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [ForeignKey("Resposta_Atividade")]
        [Required]
        public int IdResposta_Atividade { get; set; }

        [ForeignKey("Opcao")]
        [Required]
        public int IdOpcao { get; set; }

        public Resposta_Atividade Resposta_Atividade { get; set; }

    }
}