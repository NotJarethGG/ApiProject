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
    public class HabilidadServicios : IHabilidadServicios
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public HabilidadServicios(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<List<HabilidadVM>> GetAll()
        {

            List<Habilidad> listaHabilidad = await _context.Habilidad.ToListAsync();

            List<HabilidadVM> listaHabilidadVm = new List<HabilidadVM>();

            foreach (Habilidad habilidad in listaHabilidad)
            {
                HabilidadVM newHabilidadVm = new HabilidadVM();
                newHabilidadVm.Id = habilidad.Id;
                newHabilidadVm.NombreHabilidad = habilidad.NombreHabilidad;
                listaHabilidadVm.Add(newHabilidadVm);
            }

            return listaHabilidadVm;
        }

        public async Task<Habilidad> GetById(int id)
        {
            var habilidad = await _context.Habilidad.FindAsync(id);

            return habilidad;
        }

        public async Task<Habilidad> Create(HabilidadVM habilidadRequest)
        {

            Habilidad newHabilidad = new Habilidad();
            newHabilidad.Id = habilidadRequest.Id;
            newHabilidad.NombreHabilidad = habilidadRequest.NombreHabilidad;

            _context.Habilidad.Add(newHabilidad);
            await _context.SaveChangesAsync();

            return newHabilidad;
        }

        public async Task Update(int id, HabilidadVM habilidadRequest)
        {
            Habilidad HabilidadEdit = await _context.Habilidad.FindAsync(id);

            HabilidadEdit.NombreHabilidad = habilidadRequest.NombreHabilidad;

            _context.Entry(HabilidadEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {

            var habilidad = await _context.Habilidad.FindAsync(id);

            _context.Habilidad.Remove(habilidad);
            await _context.SaveChangesAsync();
        }


    }
}
