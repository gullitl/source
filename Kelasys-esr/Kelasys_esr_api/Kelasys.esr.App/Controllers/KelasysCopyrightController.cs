using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Kelasys.esr.App.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class KelasysCopyrightController : ControllerBase {
        private static readonly string copyright = "Copyright © 2020 Kelasys esr";

        private readonly ILogger<KelasysCopyrightController> _logger;

        public KelasysCopyrightController(ILogger<KelasysCopyrightController> logger) {
            _logger = logger;
        }

        [HttpGet]
        public string Get() => copyright;
    }
}
