using Microsoft.EntityFrameworkCore;
using SistemaDeAlunos.Data;
using SistemaDeAlunos.Repositorios;
using SistemaDeAlunos.Repositorios.Interfaces;
using SistemaDeTurmas.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<SistemaAlunosDBContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase"))
    );

builder.Services.AddScoped<IAlunoRepositorio, AlunoRepositorio>();
builder.Services.AddScoped<ITurmaRepositorio, TurmaRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
