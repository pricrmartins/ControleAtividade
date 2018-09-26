using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleAtividade.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questao_Imagem_IdImagem",
                table: "Questao");

            migrationBuilder.DropIndex(
                name: "IX_Questao_IdImagem",
                table: "Questao");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Questao_IdImagem",
                table: "Questao",
                column: "IdImagem");

            migrationBuilder.AddForeignKey(
                name: "FK_Questao_Imagem_IdImagem",
                table: "Questao",
                column: "IdImagem",
                principalTable: "Imagem",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
