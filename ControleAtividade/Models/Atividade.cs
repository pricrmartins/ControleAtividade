﻿using System;
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

        [ForeignKey("Turma")]
        [Required]
        public string CodigoTurma { get; set; }

        public Turma Turma { get; set; }

        public virtual List<Questao> ListaQuestao { get; set; }
    }
}
