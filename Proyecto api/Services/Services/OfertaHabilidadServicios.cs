using Dta.Data;
using Dta.Models;
using Dta.RequestObjects;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Services
{
    public class OfertaHabilidadServicios : IOfertaHabilidadServicios
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public OfertaHabilidadServicios(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<List<OfertaHabilidadVM>> GetAll()
        {

            List<OfertaHabilidad> listaOfertaHabilidad = await _context.OfertaHabilidad.ToListAsync();

            List<OfertaHabilidadVM> listaOfertaHabilidadVm = new List<OfertaHabilidadVM>();

            foreach (OfertaHabilidad ofertaHabilidad in listaOfertaHabilidad)
            {
                OfertaHabilidadVM newOfertaHabilidadVm = new OfertaHabilidadVM();
                newOfertaHabilidadVm.OfertaId = ofertaHabilidad.OfertaId;
                newOfertaHabilidadVm.HabilidadId = ofertaHabilidad.HabilidadId;
                listaOfertaHabilidadVm.Add(newOfertaHabilidadVm);
            }

            return listaOfertaHabilidadVm;
        }

        public async Task<OfertaHabilidad> GetById(int Oferta_Id, int Habilidad_Id)
        {
            OfertaHabilidad newOfertaHabilidad = new OfertaHabilidad();
            newOfertaHabilidad = _context.OfertaHabilidad.SingleOrDefault(pc => pc.OfertaId == Oferta_Id && pc.HabilidadId == Habilidad_Id);

            return newOfertaHabilidad;
        }

        public async Task<OfertaHabilidad> Create(OfertaHabilidadVM ofertahabilidadRequest)
        {
            OfertaHabilidad newOfertaHabilidad = new OfertaHabilidad();
            newOfertaHabilidad.OfertaId = ofertahabilidadRequest.OfertaId;
            newOfertaHabilidad.HabilidadId = ofertahabilidadRequest.HabilidadId;

            _context.OfertaHabilidad.Add(newOfertaHabilidad);
            await _context.SaveChangesAsync();

            return newOfertaHabilidad;
        }


        public async Task Delete(int Oferta_Id, int Habilidad_Id)
        {        

            OfertaHabilidad newOfertaHabilidad = new OfertaHabilidad();
            newOfertaHabilidad = _context.OfertaHabilidad.SingleOrDefault(pc => pc.OfertaId == Oferta_Id && pc.HabilidadId == Habilidad_Id);         

            _context.OfertaHabilidad.Remove(newOfertaHabilidad);
            await _context.SaveChangesAsync();
        }

    }
}


