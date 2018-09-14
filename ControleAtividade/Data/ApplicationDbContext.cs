using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ControleAtividade.Models;
using Microsoft.Extensions.Logging;

namespace ControleAtividade.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Imagem> Imagens { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Professor> Professores { get; set; }
        public virtual DbSet<Turma> Turmas { get; set; }
        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Questao> Questoes { get; set; }
        public virtual DbSet<Opcao> Opcoes { get; set; }
        public virtual DbSet<Atividade_Aluno> Atividades_Aluno { get; set; }
        public virtual DbSet<Questao_Aluno> Questoes_Aluno { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true)
                .UseLoggerFactory(new LoggerFactory().AddConsole((category, level) =>
                level == LogLevel.Information &&
                category == DbLoggerCategory.Database.Command.Name, true));
        }
    }
}
