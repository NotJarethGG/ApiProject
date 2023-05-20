using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoOfertaServicios
    {
        public Task<List<CandidatoOfertaVM>> GetAll();
        public Task<CandidatoOferta> GetById(int Candidato_Id, int Oferta_Id);
        public Task<CandidatoOferta> Create(CandidatoOfertaVM candidatoofertaRequest);
        public Task Delete(int Candidato_Id, int Oferta_Id);
    }
}
