using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RedeSocial.Api.Services;
using RedeSocial.Infraestrutura.EntityFramework.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RedeSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly PostServices postServices;

        public PostsController(DomainDbContext context)
        {
            postServices = new PostServices(context);
        }

        // GET: api/<PostsController>
        [HttpGet]
        public ActionResult Get()
        {
            var posts = postServices.BuscarPosts();

            return Ok(posts);
        }

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok();
        }

        // POST api/<PostsController>
        [HttpPost]
        public ActionResult Post([FromBody] PostRequest request)
        {
            var result = postServices.CadastrarPost(request);

            if (result.CadastradoComSucesso)
            {
                return CreatedAtAction(nameof(Get), result.Post.Id, result.Post);
            }

            return BadRequest(result.Erros);
        }

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            return Ok();
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            postServices.ExcluirPost(id);

            //204
            return NoContent();
        }
    }



    public class PostResponse
    {

    }

    public class PostRequest
    {
        public string Texto { get; set; }
        public string Imagem { get; set; }
    }
}
