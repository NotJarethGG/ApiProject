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
    internal class OfertaServicios : IOfertaServicios
    {
        private readonly ApiProjectBolsaEmpleo_Context _context;

        public OfertaServicios(ApiProjectBolsaEmpleo_Context context)
        {
            _context = context;
        }

        public async Task<List<Oferta>> GetAll()
        {
          
            List<Oferta> listaOfertas = await _context.Oferta
            
            //.Include(c=> c.Candidato)
            .Select(c => new Oferta
            {
                Id = c.Id,
                NombreEmpresa = c.NombreEmpresa,
                Correo = c.Correo,
                NumeroTelefono = c.NumeroTelefono,
                PaginaWebDeLaEmpresa = c.PaginaWebDeLaEmpresa,
                Descripcion = c.Descripcion,
                OfertaHabilidades = c.OfertaHabilidades,
                CandidatoOfertas = c.CandidatoOfertas,

                

            })
                   .ToListAsync();


            

            return listaOfertas;
        }

        public async Task<Oferta> GetById(int id)
        {
            var oferta = await _context.Oferta.FindAsync(id);

            return oferta;
        }

        public async Task<Oferta> Create(OfertaVM ofertaRequest)
        {

            Oferta newOferta = new Oferta();
            newOferta.Id = ofertaRequest.Id;
            newOferta.NombreEmpresa = ofertaRequest.NombreEmpresa;
            newOferta.Correo = ofertaRequest.Correo;
            newOferta.NumeroTelefono = ofertaRequest.NumeroTelefono;
            newOferta.PaginaWebDeLaEmpresa = ofertaRequest.PaginaWebDeLaEmpresa;
            newOferta.Descripcion = ofertaRequest.Descripcion;

            _context.Oferta.Add(newOferta);
            await _context.SaveChangesAsync();

            return newOferta;
        }
        public async Task Update(int id, OfertaVM ofertaRequest)
        {
            Oferta OfertaEdit = await _context.Oferta.FindAsync(id);

            OfertaEdit.NombreEmpresa = ofertaRequest.NombreEmpresa;
            OfertaEdit.Correo = ofertaRequest.Correo;
            OfertaEdit.NumeroTelefono = ofertaRequest.NumeroTelefono;
            OfertaEdit.PaginaWebDeLaEmpresa = ofertaRequest.PaginaWebDeLaEmpresa;
            OfertaEdit.Descripcion = ofertaRequest.Descripcion;

            _context.Entry(OfertaEdit).State = EntityState.Modified;

            await _context.SaveChangesAsync();
          
        }

        public async Task Delete(int id)
        {
   
            var Oferta = await _context.Oferta.FindAsync(id);

            _context.Oferta.Remove(Oferta);
            await _context.SaveChangesAsync();

        }

    }
}
