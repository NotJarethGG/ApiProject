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
    internal class CandidatoHabilidadServicios : ICandidatoHabilidadServicios
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public CandidatoHabilidadServicios(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<List<CandidatoHabilidadVM>> GetAll()
        {
            List<CandidatoHabilidad> listaCandidatoHabilidad = await _context.CandidatoHabilidad.ToListAsync();

            List<CandidatoHabilidadVM> listaHabilidadVm = new List<CandidatoHabilidadVM>();

            foreach (CandidatoHabilidad candidatoHabilidad in listaCandidatoHabilidad)
            {
                CandidatoHabilidadVM newCandidatoHabilidadVm = new CandidatoHabilidadVM();
                newCandidatoHabilidadVm.HabilidadID = candidatoHabilidad.HabilidadID;
                newCandidatoHabilidadVm.CandidatoID = candidatoHabilidad.CandidatoID;

                

                listaHabilidadVm.Add(newCandidatoHabilidadVm);
            }

            return listaHabilidadVm;
        }

        public async Task<CandidatoHabilidad> GetById(int CandidatoID, int HabilidadID)
        {
            CandidatoHabilidad newCandidatoHabilidad = new CandidatoHabilidad();
            newCandidatoHabilidad = _context.CandidatoHabilidad.SingleOrDefault(pc => pc.CandidatoID == 
            CandidatoID && pc.HabilidadID == HabilidadID);

            return newCandidatoHabilidad;
        }
        public async Task<CandidatoHabilidad> Create(CandidatoHabilidadVM candidatohabilidadRequest)
        {
            CandidatoHabilidad newCandidatoHabilidad = new CandidatoHabilidad();
            newCandidatoHabilidad.CandidatoID = candidatohabilidadRequest.CandidatoID;
            newCandidatoHabilidad.HabilidadID = candidatohabilidadRequest.HabilidadID;

            _context.CandidatoHabilidad.Add(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

            return newCandidatoHabilidad;
        }

        public async Task Delete(int CandidatoID, int HabilidadID) 
        {
    
            CandidatoHabilidad newCandidatoHabilidad = new CandidatoHabilidad();
            newCandidatoHabilidad = _context.CandidatoHabilidad.SingleOrDefault(pc => pc.CandidatoID == 
            CandidatoID && pc.HabilidadID == HabilidadID);

            _context.CandidatoHabilidad.Remove(newCandidatoHabilidad);
            await _context.SaveChangesAsync();

        }



    }
}
