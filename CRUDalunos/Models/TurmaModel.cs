namespace SistemaDeAlunos.Models
{
    public class TurmaModel
    {
        public int Id { get; set; }
        public string? Disciplina { get; set; }
        public string? Professor { get; set; }
        public int Sala { get; set; }

        public int? AlunoId { get; set; }
        public virtual AlunoModel? Aluno { get; set; }
    }
}
