﻿using Microsoft.EntityFrameworkCore;
using SistemaDeAlunos.Data;
using SistemaDeAlunos.Models;
using SistemaDeAlunos.Repositorios.Interfaces;

namespace SistemaDeTurmas.Repositorios
{
    public class TurmaRepositorio : ITurmaRepositorio
    {
        private readonly SistemaAlunosDBContext _dbContext;

        public TurmaRepositorio(SistemaAlunosDBContext SistemaAlunosDBContext)
        {
            _dbContext = SistemaAlunosDBContext;
        }

        public async Task<TurmaModel> BuscarPorId(int id)
        {
            return await _dbContext.Turmas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TurmaModel>> BuscarTodosTurmas()
        {
            return await _dbContext.Turmas.ToListAsync();
        }

        public async Task<TurmaModel> Adicionar(TurmaModel Turma)
        {
            await _dbContext.Turmas.AddAsync(Turma);
            await _dbContext.SaveChangesAsync();

            return Turma;
        }
        public async Task<TurmaModel> Atualizar(TurmaModel Turma, int id)
        {
            TurmaModel TurmaPorId = await BuscarPorId(id);

            if (TurmaPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado.");
            }

            TurmaPorId.Disciplina = Turma.Disciplina;
            TurmaPorId.Professor = Turma.Professor;
            TurmaPorId.Sala = Turma.Sala;

            _dbContext.Update(TurmaPorId);
            _dbContext.SaveChanges();

            return TurmaPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            TurmaModel TurmaPorId = await BuscarPorId(id);

            if (TurmaPorId == null)
            {
                throw new Exception($"Usuário com ID: {id} não foi encontrado.");
            }

            _dbContext.Turmas.Remove(TurmaPorId);
            _dbContext.SaveChanges();

            return true;
        }
    }
}
