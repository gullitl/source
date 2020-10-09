using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedeSocial.WebApp.Models.Post
{
    public class PostIndexViewModel
    {
        public string[] Erros { get; set; }
        public List<PostViewModel> Posts { get; set; } = new List<PostViewModel>();
        public string NomeUsuario { get; set; }
    }
}
