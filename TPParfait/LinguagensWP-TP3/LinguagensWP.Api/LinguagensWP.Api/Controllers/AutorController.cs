using LinguagensWP.Domain.AutorAggregate;
using LinguagensWP.Infrastructure.DataAccess.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinguagensWP.Api.Controllers 
{
    [ApiController]
    [Route("[controller]")]
    public class AutorController : ControllerBase 
    {
        private readonly AppDbContext _context;

        public AutorController(AppDbContext context) 
        {
            _context = context;
        }

        [HttpGet("getall")]
        public async Task<ActionResult<List<Autor>>> GetAll() 
        {
            return Ok(await _context.Autores.ToListAsync());
        }

        [HttpGet("getbyid/{id}")]
        public async Task<ActionResult<Autor>> GetById(int id) 
        {
            var autor = await _context.Autores
                .FirstOrDefaultAsync(m => m.AutorId == id);
            if(autor == null) {
                return NotFound();
            }

            return autor;
        }

        [HttpPost("create")]
        public async Task<ActionResult<bool>> Create(Autor autor) 
        {
            _context.Add(autor);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPut("update")]
        public async Task<ActionResult<bool>> Update(Autor autor) 
        {
            try {
                _context.Update(autor);
                await _context.SaveChangesAsync();
                return true;
            } catch(DbUpdateConcurrencyException) {
                if(!AutorExists(autor.AutorId)) {
                    return NotFound();
                } else {
                    throw;
                }
            }
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<bool>> Delete(int id) 
        {
            var autor = await _context.Autores.FindAsync(id);
            _context.Autores.Remove(autor);
            await _context.SaveChangesAsync();
            return true;
        }

        [HttpPost("exists/{id}")]
        public bool AutorExists(int id) 
        {
            return _context.Autores.Any(e => e.AutorId == id);
        }
    }
}
