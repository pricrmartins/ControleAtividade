using ControleAtividade.Models;
using ControleAtividade.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace ControleAtividadeTeste
{
    public class UnitTest1
    {
        List<Professor> _professores;
        List<Atividade> _atividades;
        public UnitTest1()
        {
            _professores = new List<Professor>();
            _atividades = new List<Atividade>();
        }

        [Fact]
        public void CriaProfessor()
        {
            Professor professor = new Professor
            {
                ApplicationUser = new ApplicationUser
                {
                    Email = "pricrmartins@gmail.com",
                    Nome = "Priscilla",
                    UserName = "12312312312",
                    PasswordHash = "123123"
                }
            };
            Assert.True(SalvarProfessor(professor), "Professor salvo.");
        }

        [Fact]
        public void CriaAtividade()
        {
            Atividade atividade = new Atividade
            {
                Descricao = "Atividade para testar conhecimentos básicos de matemática",
                Nome = "Adição simples",
                Tipo = "Matemática"
            };

            Assert.True(SalvarAtividade(atividade), "Atividade salvo.");
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

        bool SalvarAtividade(Atividade atividade)
        {
            try
            {
                _atividades.Add(atividade);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        
    }
}
