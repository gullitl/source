using System;
using System.Collections.Generic;
using System.Threading;

namespace RedeSocial.Domain
{
    public class Post
    {
        public string Id { get; set; }
        public string Imagem { get; set; }
        public string Texto { get; set; }
        public DateTime DataPost { get; set; }
        public List<Comentario> Comentarios { get; set; }
        public string Usuario { get; set; }
    }

    public interface IPostRepository
    {
        void Gravar(Post post);
        void Excluir(Post post);
        IEnumerable<Post> Buscar();
        IEnumerable<Post> Buscar(string usuario);
        IEnumerable<Post> Buscar(DateTime data);
    }

    public class PostServices
    {
        private readonly IPostRepository postRepository;

        public PostServices(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public void CadastrarPost(string texto, string imagem, string usuario)
        {
            Post post = new Post();
            post.Id = Guid.NewGuid().ToString(); 
            post.Texto = texto;
            post.Imagem = imagem;
            post.Usuario = usuario;

            Gravar(post);
        }

        private void Gravar(Post post)
        {
            postRepository.Gravar(post);
        }
    }
}
