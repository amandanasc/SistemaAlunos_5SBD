using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeAlunos.Models;
using SistemaDeAlunos.Repositorios.Interfaces;

namespace SistemaDeAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunoController(IAlunoRepositorio alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoModel>>> BuscarTodosAlunos()
        {
            List<AlunoModel> alunos = await _alunoRepositorio.BuscarTodosAlunos();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<AlunoModel>>> BuscarPorId(int id)
        {
            AlunoModel aluno = await _alunoRepositorio.BuscarPorId(id);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoModel>> Cadastrar([FromBody] AlunoModel aluno)
        {
            AlunoModel result = await _alunoRepositorio.Adicionar(aluno);
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<ActionResult<AlunoModel>> Atualizar([FromBody] AlunoModel aluno, int id)
        {
            aluno.Id = id;

            AlunoModel result = await _alunoRepositorio.Atualizar(aluno, id);
            return Ok(result);
        }
        
        [HttpDelete]
        public async Task<ActionResult<AlunoModel>> Apagar([FromBody] AlunoModel aluno, int id)
        {
            bool result = await _alunoRepositorio.Apagar(id);
            return Ok(result);
        }
    }
}
