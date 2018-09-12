using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAtividade.Models
{
    [Table("Imagem")]
    public class Imagem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public byte[] ImagemBlob { get; set; }

        [Required]
        public string Descricao { get; set; }
    }
}