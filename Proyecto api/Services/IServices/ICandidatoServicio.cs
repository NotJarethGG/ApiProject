using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface ICandidatoServicio
    {
        public Task<List<Candidato>> GetAll();

        public Task<Candidato> GetById(int id);

        public Task<Candidato> Create(CandidatoVM candidatoRequest);

        public Task Update(int id, CandidatoVM candidatoRequest);

        public Task Delete(int id);

    }
}
