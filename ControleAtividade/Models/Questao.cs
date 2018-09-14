﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAtividade.Models
{
    [Table("Questao")]
    public class Questao
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Cabecalho { get; set; }

        public string Texto { get; set; }

        [ForeignKey("Imagem")]
        public int IdImagem { get; set; }

        [ForeignKey("Atividade")]
        [Required]
        public int IdAtividade { get; set; }

        public Imagem Imagem { get; set; }

        public Atividade Atividade { get; set; }

        public virtual List<Opcao> ListaOpcao { get; set; }
    }
}