using Matricula.Dados;
using Matricula.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Matricula.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatriculaController : ControllerBase
    {
        private readonly MatriculaContext _context;

        public MatriculaController(MatriculaContext context)
        {
            _context = context;
        }

        [HttpPost("Create")]
        public async Task<ActionResult<Cadastro>> CreateMatricula(string nome, int idade, string serie)
        {
            Cadastro cadastro = new Cadastro()
            {
                NomeCompleto = nome,
                Idade = idade,
                Serie = serie
            };
            
            await _context.cadastro.AddAsync(cadastro);

            await _context.SaveChangesAsync();

            return Ok(cadastro);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<Cadastro>> GetAluno(string nome)
        {
             var getAluno = await _context.cadastro.Where(n => n.NomeCompleto == nome).ToListAsync();

             if (getAluno.Count == 0)
                 return BadRequest("Aluno não encontrado!");

             foreach (var item in getAluno)
             {
                 if (item.NomeCompleto != nome)
                     return BadRequest("Aluno não encontrado!");
             }

             return Ok(getAluno);
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<Cadastro>> DeleteAluno(int id)
        {
            var getAluno = _context.cadastro.Find(id);

            if (getAluno == null)
                return BadRequest("Aluno não encontrado!");

            _context.Remove(getAluno);

            _context.SaveChanges();

            return Ok("Aluno removido com sucesso!");
        }
    }
}