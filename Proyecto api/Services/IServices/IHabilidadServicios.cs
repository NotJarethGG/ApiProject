using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IHabilidadServicios
    {
        public Task<List<HabilidadVM>> GetAll();

        public Task<Habilidad> GetById(int id);

        public Task<Habilidad> Create(HabilidadVM habilidadRequest);

        public Task Update(int id, HabilidadVM habilidadRequest);

        public Task Delete(int id);
    }
}
