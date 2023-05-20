using Microsoft.EntityFrameworkCore.Storage;

namespace Dta.Models
{
    public class Candidato
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public int edad { get; set; }
        public string Direccion { get; set; }
        public int NumeroTelefono { get; set; }
        public string Descripcion { get; set; }


        //Relaciones pertenecientes a Candidato
        public List<FormacionAcademica> formacionAcademica { get; set; }

        public List<CandidatoHabilidad> CandidatoHabilidades { get; set; }
        
        public List<CandidatoOferta> CandidatoOfertas { get; set; }
        
    }
}
