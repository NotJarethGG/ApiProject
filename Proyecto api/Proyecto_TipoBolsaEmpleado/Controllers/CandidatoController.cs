using Dta.Models;
using Dta.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IServices;

namespace ApiProjectBolsaEmpleo.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoController : ControllerBase
    {
        private readonly ICandidatoServicio _candidatoService;
        

        public CandidatoController(ICandidatoServicio candidatoService)
        {
            _candidatoService = candidatoService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Candidato>>> GetAll()
        {
            List<Candidato> listCandidato = await _candidatoService.GetAll();

            if (listCandidato == null)
            {
                return NotFound();
            }

            

            return Ok(listCandidato);
        }
        

        [HttpGet("{id}")]
        public async Task<ActionResult<Candidato>> GetCandidato(int id)
        {
            var candidato = await _candidatoService.GetById(id);
            if (candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCandidato(int id, CandidatoVM candidatoRequest)
        {

            if (candidatoRequest == null)
            {
                return BadRequest();
            }

            var candidato = await _candidatoService.GetById(id);

            if (candidato == null)
            {
                return NotFound();
            }

            await _candidatoService.Update(id, candidatoRequest);
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Candidato>> PostAuthor(CandidatoVM candidatoRequest)
        {
            if (candidatoRequest == null)
            {
                return BadRequest();
            }

            Candidato newCandidato = await _candidatoService.Create(candidatoRequest);

            return CreatedAtAction("GetCandidato", new { id = newCandidato.Id }, newCandidato);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidato(int id)
        {
            var candidato = await _candidatoService.GetById(id);
            if (candidato == null)
            {
                return NotFound();
            }

            await _candidatoService.Delete(id);
            return NoContent();
        }

    }
}
