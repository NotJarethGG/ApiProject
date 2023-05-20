using Dta.Models;
using Dta.RequestObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.IServices
{
    public interface IFormacionServicios
    {

        public Task<FormacionAcademica> GetById(int id);

        public Task<FormacionAcademica> Create(FormacionAcademicaVM formacionRequest);

        public Task Update(int id, FormacionAcademicaVM formacionRequest);

        public Task Delete(int id);
    }
}
