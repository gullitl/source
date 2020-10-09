
using LinguagensWP.Domain.LinguagemAggregate;
using LinguagensWP.Infrastructure.DataAccess;
using LinguagensWP.Infrastructure.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinguagensWP.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class LinguagemController : ControllerBase {
        private readonly AppDbContext _context;

        public LinguagemController(AppDbContext context) {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<IEnumerable<Linguagem>>> GetAll() {
            var iqLinguagens = _context.Linguagens.Include(l => l.Autor);
            var test = await iqLinguagens.ToListAsync();
            return test;
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<Linguagem>> GetById(int id) {
            var linguagem = await _context.Linguagens
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.LinguagemId == id);
            if(linguagem == null) {
                return NotFound();
            }

            return linguagem;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create(Linguagem linguagem) {
            _context.Add(linguagem);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update(Linguagem linguagem) {
            try {
                _context.Update(linguagem);
                await _context.SaveChangesAsync();
                return true;
            } catch(DbUpdateConcurrencyException) {
                if(!LinguagemExists(linguagem.LinguagemId)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id) {
            var autor = await _context.Linguagens.FindAsync(id);
            _context.Linguagens.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        }

        public bool LinguagemExists(int id) {
            return _context.Linguagens.Any(e => e.AutorId == id);
        }
    }
}
