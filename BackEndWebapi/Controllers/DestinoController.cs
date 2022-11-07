using AtividadeModulo6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AtividadeModulo6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DestinoController : Controller
    {
        private readonly DestinoDBContext _context;

        public DestinoController(DestinoDBContext context)
        {
            _context = context;
        }


        //Get
        [HttpGet]
        public IEnumerable<Destino> GetDestino()
        {
            return _context.Destino;
        }

        // CRIA UM NOVO Destino
        [HttpPost]
        public IActionResult CriarCurso(Destino item)
        {
            if (item == null)
            {
                return BadRequest();
            }

            _context.Destino.Add(item);
            _context.SaveChanges();
            return new ObjectResult(item);

        }

        // GET: api/Cursos/id - LISTA CURSO POR ID
        [HttpGet("{id}")]
        public IActionResult GetCursoPorId(int id)
        {
            Destino destino = _context.Destino.SingleOrDefault(modelo => modelo.Id == id);
            if (destino == null)
            {
                return NotFound();
            }
            return new ObjectResult(destino);

        }

        // ATUALIZA UM CURSO EXISTENTE
        [HttpPut("{id}")]
        public IActionResult AtualizaCurso(int id, Destino item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();

            return new NoContentResult();
        }

        // APAGA UM CURSO POR ID
        [HttpDelete("{id}")]
        public IActionResult DeletaCurso(int id)
        {
            var curso = _context.Destino.SingleOrDefault(m => m.Id == id);



            if (curso == null)
            {
                return BadRequest();
            }
            _context.Destino.Remove(curso);
            _context.SaveChanges();
            return Ok(curso);
        }

    }
}

