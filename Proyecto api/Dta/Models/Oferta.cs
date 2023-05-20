namespace Dta.Models
{
    public class Oferta
    {
        public int Id { get; set; }

        public string NombreEmpresa { get; set; }

        public string Correo { get; set; }

        public int NumeroTelefono { get; set; }

        public string PaginaWebDeLaEmpresa { get; set; }

        public string Descripcion { get; set; }

        

        //relaciones

        public List<OfertaHabilidad> OfertaHabilidades { get; set; }
        public List<CandidatoOferta> CandidatoOfertas { get; set; }
        
    }
}
