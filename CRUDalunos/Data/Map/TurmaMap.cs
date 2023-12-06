using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeAlunos.Models;

namespace SistemaDeAlunos.Data.Map
{
    public class TurmaMap : IEntityTypeConfiguration<TurmaModel>
    {
        public void Configure(EntityTypeBuilder<TurmaModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Disciplina).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Professor).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Sala).HasMaxLength(30);
            builder.Property(x => x.AlunoId);

            builder.HasOne(x => x.Aluno);
        }
    }
}
