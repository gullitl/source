using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using RedeSocial.Api.Services;

namespace RedeSocial.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilsController : ControllerBase
    {
        private readonly IPerfilServices _services;

        public PerfilsController(IPerfilServices services)
        {
            _services = services;
        }

        // GET api/<PerfilsController>/5
        [HttpGet("{username}")]
        public ActionResult Get(string username)
        {
            var perfil = _services.BuscarPerfil(username);

            return Ok(perfil);
        }

        // POST api/<PerfilsController>
        [HttpPost]
        public ActionResult Post([FromBody] PerfilRequest perfil)
        {
            _services.Cadastrar(perfil);

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] PerfilRequest perfil)
        {
            _services.Alterar(id, perfil);

            return Ok();
        }
    }
}
