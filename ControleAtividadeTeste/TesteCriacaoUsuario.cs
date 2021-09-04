using ControleAtividade.Models;
using ControleAtividade.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace ControleAtividadeTeste
{
    public class TesteCriacaoUsuario
    {
        List<Professor> _professores;
        List<Aluno> _alunos;

        ApplicationUser _user;
        Professor _professor;
        Aluno _aluno;

        public TesteCriacaoUsuario()
        {
            // Teste Criação Usuário (Professor/Aluno) 
            _professores = new List<Professor>();
            _alunos = new List<Aluno>();
        }

        [Fact]
        public void CriarUsuario()
        {   // Key UserName = CPF
            // Senha forte
            _user = new ApplicationUser
            {
                Email = "Joao@gmail.com",
                Nome = "Joao",
                UserName = "11111111111",
                PasswordHash = "0123@WAT"
            };

            // Usuario - Professor
            CriarProfessor();

            // Usuario - Aluno
            CriarAluno();
        }


        [Fact]
        public void CriarProfessor()
        {
            _professor = new Professor
            { // Key UserName = CPF
                ApplicationUser = _user
            };
            
            Assert.True(SalvarProfessor(_professor), "Professor salvo.");
        }

        [Fact]
        public void CriarAluno()
        {
            _aluno = new Aluno
            { // Key UserName = CPF
                ApplicationUser = _user
            };
            
            Assert.True(SalvarAluno(_aluno), "Aluno salvo.");
        }

        bool SalvarProfessor(Professor professor)
        {
            try
            {
                _professores.Add(professor);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            
        }

        bool SalvarAluno(Aluno aluno)
        {
            try
            {
                _alunos.Add(aluno);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        
    }
}
