using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LinguagensWP.Domain.AutorAggregate;
using LinguagensWP.Domain.LinguagemAggregate;
using LinguagensWP.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LinguagensWP.WebApp.Controllers
{
    [Authorize]
    public class LinguagemController : Controller
    {
        public readonly HttpClient _httpClient;
        private readonly string linguagemRoute = "linguagem";
        private readonly string autorRoute = "autor";

        public LinguagemController(IHttpClientService httpClient) 
        {
            _httpClient = httpClient.GetClient();
        }

        // GET: Linguagem
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{linguagemRoute}/getall");
            if(response.IsSuccessStatusCode)
                return View(await response.Content.ReadAsAsync<List<Linguagem>>());
            else
                return NotFound();
        }

        // GET: Linguagem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null)
                return NotFound();

            var response = await _httpClient.GetAsync($"{linguagemRoute}/getbyid/{id}");
            if(response.IsSuccessStatusCode) {
                var autor = await response.Content.ReadAsAsync<Linguagem>();
                if(autor == null)
                    return NotFound();

                return View(autor);
            } else
                return NotFound();
        }

        // GET: Linguagem/Create
        public async Task<IActionResult> Create()
        {
            var response = await _httpClient.GetAsync($"{autorRoute}/getall");
            ViewData["AutorId"] = new SelectList(await response.Content.ReadAsAsync<List<Autor>>(), "AutorId", "NomeCompleto");
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
                await _httpClient.PostAsJsonAsync($"{linguagemRoute}/create", linguagem);
                return RedirectToAction(nameof(Index));
            }
            var response = await _httpClient.GetAsync($"{autorRoute}/getall");
            ViewData["AutorId"] = new SelectList(await response.Content.ReadAsAsync<List<Autor>>(), "AutorId", "NomeCompleto", linguagem.AutorId);
            return View(linguagem);
        }

        // GET: Linguagem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"{linguagemRoute}/getbyid/{id}");
            if(response.IsSuccessStatusCode) {
                var linguagem = await response.Content.ReadAsAsync<Linguagem>();
                if(linguagem == null)
                    return NotFound();

                var response1 = await _httpClient.GetAsync($"{autorRoute}/getall");
                ViewData["AutorId"] = new SelectList(await response1.Content.ReadAsAsync<List<Autor>>(), "AutorId", "NomeCompleto", linguagem.AutorId);
                return View(linguagem);
            } else
                return NotFound();
            
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
                    await _httpClient.PutAsJsonAsync($"{linguagemRoute}/update", linguagem);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await LinguagemExists(linguagem.LinguagemId))
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
            var response = await _httpClient.GetAsync($"{autorRoute}/getall");
            ViewData["AutorId"] = new SelectList(await response.Content.ReadAsAsync<List<Autor>>(), "AutorId", "NomeCompleto", linguagem.AutorId);
            return View(linguagem);
        }

        // GET: Linguagem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"{linguagemRoute}/getbyid/{id}");
            if(response.IsSuccessStatusCode) {
                var linguagem = await response.Content.ReadAsAsync<Linguagem>();
                if(linguagem == null)
                    return NotFound();

                return View(linguagem);
            } else
                return NotFound();
        }

        // POST: Linguagem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"{linguagemRoute}/delete/{id}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> LinguagemExists(int id)
        {
            var response = await _httpClient.GetAsync($"{linguagemRoute}/exists/{id}");
            if(response.IsSuccessStatusCode) {
                return await response.Content.ReadAsAsync<bool>();
            } else
                return false;
        }
    }
}
