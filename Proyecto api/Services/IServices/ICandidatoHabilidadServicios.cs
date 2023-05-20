using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoHabilidadServicios
    {
        public Task<List<CandidatoHabilidadVM>> GetAll();
        public Task<CandidatoHabilidad> GetById(int Candidato_Id, int Habilidad_Id);
        public Task<CandidatoHabilidad> Create(CandidatoHabilidadVM candidatohabilidadRequest);
        public Task Delete(int Candidato_Id, int Habilidad_Id);
    }
}
