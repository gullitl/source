using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinguagensWP.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class InitController : ControllerBase {

        [HttpGet]
        public string Get() {
            return "TP3 LinguagensWP - Asp.Net Core MVC CRUD com EF Core  ***  Autor: Parfait Mbamu";
        }
    }
}
