using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.WebApp.ApiServices;
using RedeSocial.WebApp.Models.Perfil;

namespace RedeSocial.WebApp.Controllers
{
    [Authorize]
    public class PerfilController : Controller
    {
        public IPerfilApiService PerfilApiService { get; }
        public string UserName => this.User.Identity.Name;

        public PerfilController(IPerfilApiService perfilApiService)
        {
            PerfilApiService = perfilApiService;
        }

        // GET: PerfilController
        public async Task<ActionResult> Index()
        {
            var perfil = await PerfilApiService.GetPerfil(UserName);

            if (perfil == null)
                return RedirectToAction(nameof(Create));

            return RedirectToAction(nameof(Details));
        }

        // GET: PerfilController/Details
        public async Task<ActionResult> Details()
        {
            var perfil = await PerfilApiService.GetPerfil(UserName);
            return View(perfil);
        }

        // GET: PerfilController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PerfilController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PerfilCreateViewModel perfil)
        {
            try
            {
                perfil.UserName = UserName;

                await PerfilApiService.Create(perfil);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: PerfilController/Edit/5
        public async Task<ActionResult> Edit()
        {
            var perfil = await PerfilApiService.GetPerfilToUpdate(UserName);

            return View(perfil);
        }

        // POST: PerfilController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(PerfilEditViewModel perfil)
        {
            try
            {
                await PerfilApiService.Edit(perfil);

                return RedirectToAction(nameof(Details));
            }
            catch
            {
                return View();
            }
        }

        // GET: PerfilController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PerfilController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
