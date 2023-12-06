using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeAlunos.Migrations
{
    public partial class VinculoTurmaAluno : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Turmas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Turmas_AlunoId",
                table: "Turmas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Turmas_Alunos_AlunoId",
                table: "Turmas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Turmas_Alunos_AlunoId",
                table: "Turmas");

            migrationBuilder.DropIndex(
                name: "IX_Turmas_AlunoId",
                table: "Turmas");

            migrationBuilder.DropColumn(
                name: "AlunoId",
                table: "Turmas");
        }
    }
}
