using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using LinguagensWP.Domain.AutorAggregate;
using LinguagensWP.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinguagensWP.WebApp.Controllers
{
    [Authorize]
    public class AutorController : Controller
    {
        public readonly HttpClient _httpClient;
        private readonly string autorRoute = "autor";

        public AutorController(IHttpClientService httpClient) 
        {
            _httpClient = httpClient.GetClient();
        }

        // GET: Autor
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync($"{autorRoute}/getall");
            if(response.IsSuccessStatusCode)
            {
                var test = await response.Content.ReadAsAsync<List<Autor>>();
                return View(test);
            }
            else
                return NotFound();
        }

        // GET: Autor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
                return NotFound();

            var response = await _httpClient.GetAsync($"{autorRoute}/getbyid/{id}");
            if(response.IsSuccessStatusCode) {
                var autor = await response.Content.ReadAsAsync<Autor>();
                if(autor == null)
                    return NotFound();
                
                return View(autor);
            } 
            else 
                return NotFound();
            
        }

        // GET: Autor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NomeCompleto,DataNascimento,Ativo")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                await _httpClient.PostAsJsonAsync($"{autorRoute}/create", autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"{autorRoute}/getbyid/{id}");
            if(response.IsSuccessStatusCode) {
                var autor = await response.Content.ReadAsAsync<Autor>();
                if(autor == null)
                    return NotFound();

                return View(autor);
            } else
                return NotFound();
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutorId,NomeCompleto,DataNascimento,Ativo")] Autor autor)
        {
            if (id != autor.AutorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _httpClient.PutAsJsonAsync($"{autorRoute}/update", autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await AutorExists(autor.AutorId))
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
            return View(autor);
        }

        // GET: Autor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await _httpClient.GetAsync($"{autorRoute}/getbyid/{id}");
            if(response.IsSuccessStatusCode) {
                var autor = await response.Content.ReadAsAsync<Autor>();
                if(autor == null)
                    return NotFound();

                return View(autor);
            } else
                return NotFound();
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _httpClient.DeleteAsync($"{autorRoute}/delete/{id}");
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> AutorExists(int id)
        {
            var response = await _httpClient.GetAsync($"{autorRoute}/exists/{id}");
            if(response.IsSuccessStatusCode) {
                return await response.Content.ReadAsAsync<bool>();
            } else
                return false;
        }
    }
}
