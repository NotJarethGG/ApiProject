using Dta.Models;

namespace Dta.RequestObjects
{
    public class OfertaVM
    {
        public int Id { get; set; }

        public string NombreEmpresa { get; set; }
        
        public string Correo { get; set; }

        public int NumeroTelefono { get; set; }

        public string PaginaWebDeLaEmpresa { get; set; }

        public string Descripcion { get; set; }

        
    }
}
