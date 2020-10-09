using RedeSocial.Api.Controllers;
using RedeSocial.Domain;
using RedeSocial.Infraestrutura.EntityFramework.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RedeSocial.Api.Services
{
    public class PostServices
    {
        public DomainDbContext Context { get; }

        public PostServices(DomainDbContext context)
        {
            Context = context;
        }

        public CadastrarPostResult CadastrarPost(PostRequest request)
        {
            var erros = new List<string>();

            if (string.IsNullOrEmpty(request.Texto))
                erros.Add("Texto é obrigatório");

            Post post = null;

            if (!erros.Any())
            {
                post = new Post();
                post.Id = Guid.NewGuid().ToString();
                post.Imagem = request.Imagem;
                post.Texto = request.Texto;

                Salvar(post);
            }

            var result = new CadastrarPostResult();
            result.Erros = erros;
            result.CadastradoComSucesso = erros.Count == 0;
            result.Post = post;
            
            return result;
        }

        public List<Post> BuscarPosts()
        {
            return Context.Posts.ToList();
        }

        private void Salvar(Post post)
        {
            Context.Posts.Add(post);
            Context.SaveChanges();
        }

        public void ExcluirPost(string id)
        {
            var post = Context.Posts.Find(id);
            Context.Posts.Remove(post);
            Context.SaveChanges();
        }
    }

    public class CadastrarPostResult
    {
        public bool CadastradoComSucesso { get; set; }
        public List<string> Erros { get; set; }
        public Post Post { get; set; }
    }
}
