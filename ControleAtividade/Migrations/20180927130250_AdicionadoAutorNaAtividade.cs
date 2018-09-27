using Microsoft.EntityFrameworkCore.Migrations;

namespace ControleAtividade.Migrations
{
    public partial class AdicionadoAutorNaAtividade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdProfessor",
                table: "Atividade",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProfessor",
                table: "Atividade");
        }
    }
}
