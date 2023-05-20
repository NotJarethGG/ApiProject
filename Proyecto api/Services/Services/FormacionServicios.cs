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
    public class FormacionServicios : IFormacionServicios
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public FormacionServicios(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<FormacionAcademica> GetById(int id)
        {
            var formacion = await _context.Formacion.FindAsync(id);

            return formacion;
        }

        public async Task<FormacionAcademica> Create(FormacionAcademicaVM formacionRequest)
        {

            FormacionAcademica newFormacion = new FormacionAcademica();
            newFormacion.Id = formacionRequest.Id;
            newFormacion.CandidatoId = formacionRequest.CandidatoId;
            newFormacion.NombreTitulo = formacionRequest.NombreTitulo;
            newFormacion.AniosEstudio = formacionRequest.AniosEstudio;
            newFormacion.FechaConclusion = formacionRequest.FechaConclusion;

            _context.Formacion.Add(newFormacion);
            await _context.SaveChangesAsync();

            return newFormacion;
        }

        public async Task Update(int id, FormacionAcademicaVM formacionRequest)
        {
            FormacionAcademica FormacionEdit = await _context.Formacion.FindAsync(id);

            FormacionEdit.NombreTitulo = formacionRequest.NombreTitulo;
            FormacionEdit.AniosEstudio = formacionRequest.AniosEstudio;
            FormacionEdit.FechaConclusion = formacionRequest.FechaConclusion;

            _context.Entry(FormacionEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();
      
        }

        public async Task Delete(int id)
        {

            var formacion = await _context.Formacion.FindAsync(id);

            _context.Formacion.Remove(formacion);
            await _context.SaveChangesAsync();
        }

    }
}
