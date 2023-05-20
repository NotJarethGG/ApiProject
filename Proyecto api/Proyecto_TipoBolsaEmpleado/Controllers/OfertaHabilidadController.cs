using Dta.Data;
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
    public class OfertaHabilidadController : Controller
    {
        private readonly IOfertaHabilidadServicios _candidatohabilidadService;

        public OfertaHabilidadController(IOfertaHabilidadServicios candidatohabilidadService)
        {
            _candidatohabilidadService = candidatohabilidadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfertaHabilidadVM>>> GetOfertaHabilidad()
        {
            List<OfertaHabilidadVM> listOfertaHabilidadVm = await _candidatohabilidadService.GetAll();

            if (listOfertaHabilidadVm == null)
            {
                return NotFound();
            }

            return Ok(listOfertaHabilidadVm);
        }

        [HttpPost]
        public async Task<ActionResult<OfertaHabilidad>> PostOfertaHabilidad(OfertaHabilidadVM ofertahabilidadRequest)
        {
            if (ofertahabilidadRequest == null)
            {
                return BadRequest();
            }

            OfertaHabilidad newOfertaHabilidad = await _candidatohabilidadService.Create(ofertahabilidadRequest);

            return CreatedAtAction("GetOfertaHabilidad", new { id = newOfertaHabilidad.OfertaId }, newOfertaHabilidad);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteOfertaHabilidad(int Oferta_Id, int Habilidad_Id)
        {
            var ofertahabilidad = await _candidatohabilidadService.GetById(Oferta_Id, Habilidad_Id);
            if (ofertahabilidad == null)
            {
                return NotFound();
            }

            await _candidatohabilidadService.Delete(Oferta_Id, Habilidad_Id);
            return NoContent();
        }

    }
}
