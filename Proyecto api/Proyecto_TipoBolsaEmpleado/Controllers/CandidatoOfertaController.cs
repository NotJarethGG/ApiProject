using Dta.Models;
using Dta.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IServices;

namespace ApiProjectBolsaEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoOfertaController : Controller
    {

        private readonly ICandidatoOfertaServicios _candidatoofertaService;

        public CandidatoOfertaController(ICandidatoOfertaServicios candidatoofertaService)
        {
            _candidatoofertaService = candidatoofertaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatoOfertaVM>>> GetCandidatoOferta()
        {
            List<CandidatoOfertaVM> listCandidatoofertaVm = await _candidatoofertaService.GetAll();

            if (listCandidatoofertaVm == null)
            {
                return NotFound();
            }

            return Ok(listCandidatoofertaVm);
        }

        [HttpPost]
        public async Task<ActionResult<CandidatoOferta>> PostCandidatoOferta(CandidatoOfertaVM candidatoofertaRequest)
        {
            if (candidatoofertaRequest == null)
            {
                return BadRequest();
            }

            CandidatoOferta newCandidatoOferta = await _candidatoofertaService.Create(candidatoofertaRequest);

            return CreatedAtAction("GetCandidatoOferta", new { id = newCandidatoOferta.CandidatoID }, newCandidatoOferta);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCandidatoOferta(int Candidato_Id, int Oferta_Id)
        {
            var candidatooferta = await _candidatoofertaService.GetById(Candidato_Id, Oferta_Id);
            if (candidatooferta == null)
            {
                return NotFound();
            }

            await _candidatoofertaService.Delete(Candidato_Id, Oferta_Id);
            return NoContent();
        }


    }
}
