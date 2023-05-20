using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IOfertaServicios
    {
        public Task<List<Oferta>> GetAll();

        public Task<Oferta> GetById(int id);

        public Task<Oferta> Create(OfertaVM ofertaRequest);

        public Task Update(int id, OfertaVM ofertaRequest);

        public Task Delete(int id);
    }
}
