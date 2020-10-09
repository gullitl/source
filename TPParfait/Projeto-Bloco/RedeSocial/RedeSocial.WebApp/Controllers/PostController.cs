using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.WebApp.Models;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authorization;
using RedeSocial.WebApp.Models.Post;
using RedeSocial.Infraestrutura.Files;

namespace RedeSocial.WebApp.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostFileUploader _fileUploader;
        private readonly HttpClient httpClient;

        public PostController(IPostFileUploader fileUploader)
        {
            _fileUploader = fileUploader;
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:5001");
        }

        // GET: PostController
        public async Task<ActionResult> Index()
        {
            var viewModel = new PostIndexViewModel();
            
            var erros = ObterErrosDaResposta();

            viewModel.Erros = erros;

            var response = await httpClient.GetAsync("api/posts");

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var content = await response.Content.ReadAsStringAsync();

                var posts = JsonConvert.DeserializeObject<List<PostViewModel>>(content);

                viewModel.Posts = posts;
            }

            return View(viewModel);
        }

        private string[] ObterErrosDaResposta()
        {
            //var erros = JsonConvert.DeserializeObject<List<string>>(.ToString());
            if (TempData["Erros"] != null)
                return (string[])TempData["Erros"];

            return new string[0];
        }

        // GET: PostController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PostController/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PostCreateViewModel postInputModel, IFormFile file)
        {
            postInputModel.Imagem = _fileUploader.UploadFile(file, Guid.NewGuid().ToString());

            var postRequest = JsonConvert.SerializeObject(postInputModel);

            var content = new StringContent(postRequest, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("api/posts", content);

            if (!response.IsSuccessStatusCode)
            {
                var contentResponse = await response.Content.ReadAsStringAsync();
                TempData["Erros"] = JsonConvert.DeserializeObject<string[]>(contentResponse);
            }

            return RedirectToAction(nameof(Index));
        }

        // GET: PostController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PostController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: Post/Delete/5
        [HttpGet]
        public async Task<ActionResult> Delete(string id)
        {
            await httpClient.DeleteAsync("api/posts/" + id);

            return RedirectToAction(nameof(Index));
        }
    }
}
