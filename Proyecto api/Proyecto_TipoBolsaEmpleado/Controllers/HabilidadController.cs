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

    public class HabilidadController : ControllerBase
    {

        private readonly IHabilidadServicios _habilidadService;

        public HabilidadController(IHabilidadServicios habilidadService)
        {
            _habilidadService = habilidadService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<HabilidadVM>>> GetHabilidad()
        {
            List<HabilidadVM> listHabilidad = await _habilidadService.GetAll();

            if (listHabilidad == null)
            {
                return NotFound();
            }

            return Ok(listHabilidad);
        }

        [HttpPost]
        public async Task<ActionResult<Habilidad>> PostHabilidad(HabilidadVM habilidadRequest)
        {
            if (habilidadRequest == null)
            {
                return BadRequest();
            }

            Habilidad newHabilidad = await _habilidadService.Create(habilidadRequest);

            return CreatedAtAction("GetHabilidad", new { id = newHabilidad.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabilidad(int id, HabilidadVM habilidadRequest)
        {
            if (habilidadRequest == null)
            {
                return BadRequest();
            }

            var habilidad = await _habilidadService.GetById(id);

            if (habilidad == null)
            {
                return NotFound();
            }

            await _habilidadService.Update(id, habilidadRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHabilidad(int id)
        {
            var habilidad = await _habilidadService.GetById(id);
            if (habilidad == null)
            {
                return NotFound();
            }

            await _habilidadService.Delete(id);
            return NoContent();
        }
        
    }
}
