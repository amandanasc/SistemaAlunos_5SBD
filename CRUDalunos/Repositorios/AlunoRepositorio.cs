using Microsoft.EntityFrameworkCore;
using SistemaDeAlunos.Data;
using SistemaDeAlunos.Models;
using SistemaDeAlunos.Repositorios.Interfaces;

namespace SistemaDeAlunos.Repositorios
{
    public class AlunoRepositorio : IAlunoRepositorio
    {
        private readonly SistemaAlunosDBContext _dbContext;

        public AlunoRepositorio(SistemaAlunosDBContext SistemaAlunosDBContext) 
        {
            _dbContext = SistemaAlunosDBContext;
        }

        public async Task<AlunoModel> BuscarPorId(int id)
        {
            return await _dbContext.Alunos.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<AlunoModel>> BuscarTodosAlunos()
        {
            return await _dbContext.Alunos.ToListAsync();
        }

        public async Task<AlunoModel> Adicionar(AlunoModel Aluno)
        {
            await _dbContext.Alunos.AddAsync(Aluno);
            await _dbContext.SaveChangesAsync();
              
            return Aluno;
        }
        public async Task<AlunoModel> Atualizar(AlunoModel Aluno, int id)
        {
            AlunoModel AlunoPorId = await BuscarPorId(id);

            if (AlunoPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado.");
            }

            AlunoPorId.Nome = Aluno.Nome;
            AlunoPorId.Email = Aluno.Email;

            _dbContext.Alunos.Update(AlunoPorId);
            _dbContext.SaveChanges();

            return AlunoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            AlunoModel AlunoPorId = await BuscarPorId(id);

            if (AlunoPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado.");
            }

            _dbContext.Alunos.Remove(AlunoPorId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
