using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.LinguagensWP.Models;
using LinguagensWP.DataAccess;

namespace LinguagensWP.Controllers
{
    public class LinguagemController : Controller
    {
        private readonly AppDbContext _context;

        public LinguagemController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Linguagem
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Linguagens.Include(l => l.Autor);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Linguagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linguagem = await _context.Linguagens
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.LinguagemId == id);
            if (linguagem == null)
            {
                return NotFound();
            }

            return View(linguagem);
        }

        // GET: Linguagem/Create
        public IActionResult Create()
        {
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "NomeCompleto");
            return View();
        }

        // POST: Linguagem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LinguagemId,Nome,AutorId,DataCricao,Descricao")] Linguagem linguagem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(linguagem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "NomeCompleto", linguagem.AutorId);
            return View(linguagem);
        }

        // GET: Linguagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linguagem = await _context.Linguagens.FindAsync(id);
            if (linguagem == null)
            {
                return NotFound();
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "NomeCompleto", linguagem.AutorId);
            return View(linguagem);
        }

        // POST: Linguagem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LinguagemId,Nome,AutorId,DataCricao,Descricao")] Linguagem linguagem)
        {
            if (id != linguagem.LinguagemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(linguagem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LinguagemExists(linguagem.LinguagemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorId"] = new SelectList(_context.Autores, "AutorId", "NomeCompleto", linguagem.AutorId);
            return View(linguagem);
        }

        // GET: Linguagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var linguagem = await _context.Linguagens
                .Include(l => l.Autor)
                .FirstOrDefaultAsync(m => m.LinguagemId == id);
            if (linguagem == null)
            {
                return NotFound();
            }

            return View(linguagem);
        }

        // POST: Linguagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var linguagem = await _context.Linguagens.FindAsync(id);
            _context.Linguagens.Remove(linguagem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LinguagemExists(int id)
        {
            return _context.Linguagens.Any(e => e.LinguagemId == id);
        }
    }
}
