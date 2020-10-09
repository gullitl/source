using System.Collections.Generic;
using System.Threading.Tasks;
using kelasys.esr.contrats;
using kelasys.esr.models.VO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace kelasys.esr.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class ProfesseurController : ControllerBase {
        private ILogger<ProfesseurController> Logger { get; }
        private IProfesseurService ProfesseurService { get; }

        public ProfesseurController(ILogger<ProfesseurController> logger,
            IProfesseurService professeurService) {
            Logger = logger;
            ProfesseurService = professeurService;
        }

        [HttpGet("getallprofesseurs")]
        public async Task<ActionResult<IEnumerable<Professeur>>> GetAll() {
            return await ProfesseurService.GetAll();
        }

        [HttpGet("getprofesseurbyid/{id}")]
        public async Task<ActionResult<Professeur>> GetById(int id) {
            Professeur Professeur = await ProfesseurService.GetById(id);
            if (Professeur == null) {
                return NotFound();
            }

            return Professeur;
        }

        [HttpPost("createprofesseur")]
        public async Task<ActionResult<Professeur>> Create(Professeur Professeur) {
            return await ProfesseurService.Create(Professeur);
        }

        [HttpPut("updateprofesseur")]
        public async Task<ActionResult<bool>> Update(Professeur Professeur) {
            return await ProfesseurService.Update(Professeur);
        }

        [HttpDelete("deleteprofesseurbyid/{id}")]
        public async Task<ActionResult<bool>> Delete(int id) {
            return await ProfesseurService.Delete(id);
        }

    }
}
