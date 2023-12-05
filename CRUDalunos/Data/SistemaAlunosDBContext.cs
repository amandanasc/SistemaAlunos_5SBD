using Microsoft.EntityFrameworkCore;
using SistemaDeAlunos.Data.Map;
using SistemaDeAlunos.Models;

namespace SistemaDeAlunos.Data
{
    public class SistemaAlunosDBContext : DbContext
    {
        public SistemaAlunosDBContext(DbContextOptions<SistemaAlunosDBContext> options)
            :base(options)
        {
        }

        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<TurmaModel> Turmas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
