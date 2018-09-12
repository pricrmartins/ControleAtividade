using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ControleAtividade.Data.Migrations
{
    public partial class TabelaSistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sobrenome",
                table: "AspNetUsers",
                newName: "Matricula");

            migrationBuilder.CreateTable(
                name: "Atividade_Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdAluno = table.Column<int>(nullable: false),
                    IdAtividade = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Imagem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: false),
                    ImagemBlob = table.Column<byte[]>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Imagem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Matricula = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    UsuarioAplicacao = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Matricula);
                    table.ForeignKey(
                        name: "FK_Usuario_AspNetUsers_UsuarioAplicacao",
                        column: x => x.UsuarioAplicacao,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questao_Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Atividade_AlunoId = table.Column<int>(nullable: true),
                    IdAtividade_Aluno = table.Column<int>(nullable: false),
                    IdOpcao = table.Column<int>(nullable: false),
                    IdQuestao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questao_Aluno_Atividade_Aluno_Atividade_AlunoId",
                        column: x => x.Atividade_AlunoId,
                        principalTable: "Atividade_Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Professor_Usuario_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Usuario",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Turma",
                columns: table => new
                {
                    Codigo = table.Column<string>(nullable: false),
                    IdProfessor = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turma", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Turma_Professor_IdProfessor",
                        column: x => x.IdProfessor,
                        principalTable: "Professor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoTurma = table.Column<string>(nullable: true),
                    Matricula = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Turma_CodigoTurma",
                        column: x => x.CodigoTurma,
                        principalTable: "Turma",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Aluno_Usuario_Matricula",
                        column: x => x.Matricula,
                        principalTable: "Usuario",
                        principalColumn: "Matricula",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Atividade",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CodigoTurma = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(nullable: false),
                    Tipo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atividade", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Atividade_Turma_CodigoTurma",
                        column: x => x.CodigoTurma,
                        principalTable: "Turma",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cabecalho = table.Column<string>(nullable: false),
                    IdAtividade = table.Column<int>(nullable: false),
                    IdImagem = table.Column<int>(nullable: false),
                    Texto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questao_Atividade_IdAtividade",
                        column: x => x.IdAtividade,
                        principalTable: "Atividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Questao_Imagem_IdImagem",
                        column: x => x.IdImagem,
                        principalTable: "Imagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opcao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Correta = table.Column<bool>(nullable: false),
                    Descricao = table.Column<string>(nullable: false),
                    IdQuestao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opcao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opcao_Questao_IdQuestao",
                        column: x => x.IdQuestao,
                        principalTable: "Questao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_CodigoTurma",
                table: "Aluno",
                column: "CodigoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_Matricula",
                table: "Aluno",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Atividade_CodigoTurma",
                table: "Atividade",
                column: "CodigoTurma");

            migrationBuilder.CreateIndex(
                name: "IX_Opcao_IdQuestao",
                table: "Opcao",
                column: "IdQuestao");

            migrationBuilder.CreateIndex(
                name: "IX_Professor_Matricula",
                table: "Professor",
                column: "Matricula");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_IdAtividade",
                table: "Questao",
                column: "IdAtividade");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_IdImagem",
                table: "Questao",
                column: "IdImagem");

            migrationBuilder.CreateIndex(
                name: "IX_Questao_Aluno_Atividade_AlunoId",
                table: "Questao_Aluno",
                column: "Atividade_AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Turma_IdProfessor",
                table: "Turma",
                column: "IdProfessor");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_UsuarioAplicacao",
                table: "Usuario",
                column: "UsuarioAplicacao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Opcao");

            migrationBuilder.DropTable(
                name: "Questao_Aluno");

            migrationBuilder.DropTable(
                name: "Questao");

            migrationBuilder.DropTable(
                name: "Atividade_Aluno");

            migrationBuilder.DropTable(
                name: "Atividade");

            migrationBuilder.DropTable(
                name: "Imagem");

            migrationBuilder.DropTable(
                name: "Turma");

            migrationBuilder.DropTable(
                name: "Professor");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.RenameColumn(
                name: "Matricula",
                table: "AspNetUsers",
                newName: "Sobrenome");
        }
    }
}
