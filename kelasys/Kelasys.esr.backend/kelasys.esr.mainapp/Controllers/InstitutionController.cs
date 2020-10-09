using System.Collections.Generic;
using System.Threading.Tasks;
using kelasys.esr.contrats;
using kelasys.esr.models.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kelasys.esr.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class InstitutionController : ControllerBase {
        private ILogger<InstitutionController> Logger { get; }
        private IInstitutionService InstitutionService { get; }

        public InstitutionController(ILogger<InstitutionController> logger,
            IInstitutionService institutionService) {
            Logger = logger;
            InstitutionService = institutionService;
        }

        [HttpGet("getallinstitutions")]
        public async Task<ActionResult<IEnumerable<Institution>>> GetAll() {
            return await InstitutionService.GetAll();
            ;
        }

        [HttpGet("getinstitutionbyid/{id}")]
        public async Task<ActionResult<Institution>> GetById(int id) {
            Institution Institution = await InstitutionService.GetById(id);

            if (Institution == null) {
                return NotFound();
            }

            return Institution;
        }

        [HttpPost("createinstitution")]
        public async Task<ActionResult<Institution>> Create(Institution Institution) {
            return await InstitutionService.Create(Institution);
        }

        [HttpPut("updateinstitution")]
        public async Task<ActionResult<bool>> Update(Institution Institution) {
            return await InstitutionService.Update(Institution);
        }

        [HttpDelete("deleteinstitutionbyid/{id}")]
        public async Task<ActionResult<bool>> Delete(int id) {
            return await InstitutionService.Delete(id);
        }

    }
}
