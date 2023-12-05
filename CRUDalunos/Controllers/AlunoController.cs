using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeAlunos.Models;

namespace SistemaDeAlunos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<AlunoModel>> BuscarTodosAlunos()
        {
            return Ok();
        }
    }
}
