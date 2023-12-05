using SistemaDeAlunos.Models;

namespace SistemaDeAlunos.Repositorios.Interfaces
{
    public interface IAlunoRepositorio
    {
        Task<List<AlunoModel>> BuscarTodosAlunos();
        Task<AlunoModel> BuscarPorId(int id);
        Task<AlunoModel> Adicionar(AlunoModel Aluno);
        Task<AlunoModel> Atualizar(AlunoModel Aluno, int id);
        Task<bool> Apagar(int id);
    }
}
