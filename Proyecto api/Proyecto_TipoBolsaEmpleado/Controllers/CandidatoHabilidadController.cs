using Dta.Models;
using Dta.RequestObjects;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using Services.Services;

namespace ApiProjectBolsaEmpleo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoHabilidadController : Controller
    {
        private readonly ICandidatoHabilidadServicios _candidatohabilidadService;

        public CandidatoHabilidadController(ICandidatoHabilidadServicios candidatohabilidadService)
        {
            _candidatohabilidadService = candidatohabilidadService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CandidatoHabilidadVM>>> GetCandidatoHabilidad()
        {
            List<CandidatoHabilidadVM> listCandidatoHabilidadVm = await _candidatohabilidadService.GetAll();

            if (listCandidatoHabilidadVm == null)
            {
                return NotFound();
            }

            return Ok(listCandidatoHabilidadVm);
        }

        [HttpPost]
        public async Task<ActionResult<CandidatoHabilidad>> PostCandidatoHabilidad(CandidatoHabilidadVM candidatohabilidadRequest)
        {
            if (candidatohabilidadRequest == null)
            {
                return BadRequest();
            }

            CandidatoHabilidad newCandidatoHabilidad = await _candidatohabilidadService.Create(candidatohabilidadRequest);

            return CreatedAtAction("GetCandidatoHabilidad", new { id = newCandidatoHabilidad.CandidatoID }, newCandidatoHabilidad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCandidatoHabilidad(int CandidatoID, int HabilidadID)
        {
            var candidatohabilidad = await _candidatohabilidadService.GetById(CandidatoID, HabilidadID);
            if (candidatohabilidad == null)
            {
                return NotFound();
            }

            await _candidatohabilidadService.Delete(CandidatoID, HabilidadID);
            return NoContent();
        }
    }
}
