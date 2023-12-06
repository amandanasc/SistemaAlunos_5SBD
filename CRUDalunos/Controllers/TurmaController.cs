using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeAlunos.Models;
using SistemaDeAlunos.Repositorios.Interfaces;

namespace SistemaDeAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepositorio _turmaRepositorio;

        public TurmaController(ITurmaRepositorio turmaRepositorio)
        {
            _turmaRepositorio = turmaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<TurmaModel>>> BuscarTodasTurmas()
        {
            List<TurmaModel> turmas = await _turmaRepositorio.BuscarTodasTurmas();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TurmaModel>>> BuscarPorId(int id)
        {
            TurmaModel turma = await _turmaRepositorio.BuscarPorId(id);
            return Ok(turma);
        }

        [HttpPost]
        public async Task<ActionResult<TurmaModel>> Cadastrar([FromBody] TurmaModel turma)
        {
            TurmaModel result = await _turmaRepositorio.Adicionar(turma);
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<TurmaModel>> Atualizar([FromBody] TurmaModel turma, int id)
        {
            turma.Id = id;

            TurmaModel result = await _turmaRepositorio.Atualizar(turma, id);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<TurmaModel>> Apagar([FromBody] TurmaModel turma, int id)
        {
            bool result = await _turmaRepositorio.Apagar(id);
            return Ok(result);
        }
    }
}
