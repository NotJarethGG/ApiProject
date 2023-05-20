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
    internal class CandidatoOfertaServicios : ICandidatoOfertaServicios
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public CandidatoOfertaServicios(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<List<CandidatoOfertaVM>> GetAll()
        {
        
            List<CandidatoOferta> listaCandidatoOferta = await _context.CandidatoOferta.ToListAsync();

            List<CandidatoOfertaVM> listaCandidatoOfertaVm = new List<CandidatoOfertaVM>();

            foreach (CandidatoOferta candidatoOferta in listaCandidatoOferta)
            {
                CandidatoOfertaVM newCandidatoOfertaVm = new CandidatoOfertaVM();
                newCandidatoOfertaVm.CandidatoId = candidatoOferta.CandidatoID;
                newCandidatoOfertaVm.OfertaId = candidatoOferta.OfertaID;
                listaCandidatoOfertaVm.Add(newCandidatoOfertaVm);
            }

            return listaCandidatoOfertaVm;
        }

        public async Task<CandidatoOferta> GetById(int Candidato_Id, int Oferta_Id)
        {
            CandidatoOferta newCandidatoOferta = new CandidatoOferta();
            newCandidatoOferta = _context.CandidatoOferta.SingleOrDefault(pc => pc.CandidatoID == Candidato_Id && pc.OfertaID == Oferta_Id);

            return newCandidatoOferta;
        }

        public async Task<CandidatoOferta> Create(CandidatoOfertaVM candidatoofertaRequest)
        {
            CandidatoOferta newCandidatoOferta = new CandidatoOferta();
            newCandidatoOferta.CandidatoID = candidatoofertaRequest.CandidatoId;
            newCandidatoOferta.OfertaID = candidatoofertaRequest.OfertaId;

           // if (_context.CandidatoOferta == null)
           //{
           //    return Problem("Entity set 'BolsaEmpleo_Context.CandidatoOferta'  is null.");
           //}

            _context.CandidatoOferta.Add(newCandidatoOferta);
            await _context.SaveChangesAsync();

            return newCandidatoOferta;

        }

        public async Task Delete(int Candidato_Id, int Oferta_Id)
        {
          
            CandidatoOferta newCandidatoOferta = new CandidatoOferta();
            newCandidatoOferta = _context.CandidatoOferta.SingleOrDefault(pc => pc.CandidatoID == Candidato_Id && pc.OfertaID == Oferta_Id);

            _context.CandidatoOferta.Remove(newCandidatoOferta);
            await _context.SaveChangesAsync();
        }
    }
}
