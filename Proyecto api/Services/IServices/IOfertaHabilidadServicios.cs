using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IOfertaHabilidadServicios
    {
        public Task<List<OfertaHabilidadVM>> GetAll();
        public Task<OfertaHabilidad> GetById(int Oferta_Id, int Habilidad_Id);
        public Task<OfertaHabilidad> Create(OfertaHabilidadVM ofertahabilidadRequest);
        public Task Delete(int Oferta_Id, int Habilidad_Id);
    }
}
