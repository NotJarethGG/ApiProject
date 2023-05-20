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
    public class CandidatoServicio : ICandidatoServicio
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public CandidatoServicio(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<List<Candidato>> GetAll()
        {
            List<Candidato> listaCandidatos = await _context.Candidato
            .Include(c => c.formacionAcademica)
            .Include(c => c.CandidatoHabilidades)
            .Include(c => c.CandidatoOfertas)
            .Select(c => new Candidato
            {
                Id = c.Id,
                Nombre = c.Nombre,
                PrimerApellido = c.PrimerApellido,
                SegundoApellido = c.SegundoApellido,
                edad = c.edad,
                Direccion = c.Direccion,
                NumeroTelefono = c.NumeroTelefono,
                Descripcion = c.Descripcion,
                


                formacionAcademica = c.formacionAcademica.Select(f => new FormacionAcademica
                {
                    NombreTitulo = f.NombreTitulo,
                    AniosEstudio = f.AniosEstudio,
                    FechaConclusion = f.FechaConclusion

                }).ToList(),

                CandidatoHabilidades = c.CandidatoHabilidades.Select(f => new CandidatoHabilidad {

                    Habilidad = f.Habilidad

                }).ToList(),

                CandidatoOfertas = c.CandidatoOfertas.Select( f => new CandidatoOferta
                {
                    Oferta = f.Oferta

                }).ToList()
            
             })
                   .ToListAsync();


            return listaCandidatos;
        }

        public async Task<Candidato> GetById(int id)
        {
            var candidato = await _context.Candidato
           .Include(c => c.formacionAcademica)
           .Include(c => c.CandidatoHabilidades)
           .Include(c => c.CandidatoOfertas)
           //.Select(c => new Candidato
           // {

           //})
           //        .ToListAsync();

           .FirstOrDefaultAsync(c => c.Id == id);



            return candidato;
        }

        public async Task<Candidato> Create(CandidatoVM candidatoRequest)
        {
            Candidato newCandidato = new Candidato();
            newCandidato.Id = candidatoRequest.Id;
            newCandidato.Nombre = candidatoRequest.Nombre;
            newCandidato.PrimerApellido = candidatoRequest.PrimerApellido;
            newCandidato.SegundoApellido = candidatoRequest.SegundoApellido;
            newCandidato.edad = candidatoRequest.edad;
            newCandidato.Direccion = candidatoRequest.Direccion;
            newCandidato.NumeroTelefono = candidatoRequest.NumeroTelefono;
            newCandidato.Descripcion = candidatoRequest.Descripcion;

           

            _context.Candidato.Add(newCandidato);
            await _context.SaveChangesAsync();

            return newCandidato;

        }

        public async Task Update(int id, CandidatoVM candidatoRequest)
        {
            Candidato CandidatoEdit = await _context.Candidato.FindAsync(id);

            CandidatoEdit.Nombre = candidatoRequest.Nombre;
            CandidatoEdit.PrimerApellido = candidatoRequest.PrimerApellido;
            CandidatoEdit.SegundoApellido = candidatoRequest.SegundoApellido;
            CandidatoEdit.edad = candidatoRequest.edad;
            CandidatoEdit.Direccion = candidatoRequest.Direccion;
            CandidatoEdit.NumeroTelefono = candidatoRequest.NumeroTelefono;
            CandidatoEdit.Descripcion = candidatoRequest.Descripcion;

            _context.Entry(CandidatoEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }

        public async Task Delete(int id)
        {
            var candidato = await _context.Candidato.FindAsync(id);

            _context.Candidato.Remove(candidato);
            await _context.SaveChangesAsync();
        }

    }
}
