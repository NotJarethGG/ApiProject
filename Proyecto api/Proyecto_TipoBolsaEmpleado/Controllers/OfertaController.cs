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
    public class OfertaController : ControllerBase
    {
        private readonly IOfertaServicios _ofertaServices;

        public OfertaController(IOfertaServicios ofertaServices)
        {
            _ofertaServices = ofertaServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Oferta>>> GetOferta()
        {
            List<Oferta> listOferta = await _ofertaServices.GetAll();

            if (listOferta == null)
            {
                return NotFound();
            }

            return Ok(listOferta);
        }

        [HttpPost]
        public async Task<ActionResult<Oferta>> PostOferta(OfertaVM ofertaRequest)
        {

            if (ofertaRequest == null)
            {
                return BadRequest();
            }

            Oferta newOferta = await _ofertaServices.Create(ofertaRequest);
            return CreatedAtAction("GetOferta", new { id = newOferta.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOferta(int id, OfertaVM ofertaRequest)
        {
            if (ofertaRequest == null)
            {
                return BadRequest();
            }

            var candidato = await _ofertaServices.GetById(id);

            if (candidato == null)
            {
                return NotFound();
            }

            await _ofertaServices.Update(id, ofertaRequest);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOferta(int id)
        {
            var oferta = await _ofertaServices.GetById(id);
            if (oferta == null)
            {
                return NotFound();
            }

            await _ofertaServices.Delete(id);
            return NoContent();
        }

    }
}
