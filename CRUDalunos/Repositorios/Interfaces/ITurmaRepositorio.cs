using SistemaDeAlunos.Models;

namespace SistemaDeAlunos.Repositorios.Interfaces
{
    public interface ITurmaRepositorio
    {
        Task<List<TurmaModel>> BuscarTodasTurmas();
        Task<TurmaModel> BuscarPorId(int id);
        Task<TurmaModel> Adicionar(TurmaModel Turma);
        Task<TurmaModel> Atualizar(TurmaModel Turma, int id);
        Task<bool> Apagar(int id);
    }
}
