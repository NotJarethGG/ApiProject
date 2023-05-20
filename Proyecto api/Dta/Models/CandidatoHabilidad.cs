namespace Dta.Models
{
    public class CandidatoHabilidad
    {
        public int CandidatoID { get; set; }
        
        public int HabilidadID { get; set; }
        
        public Habilidad Habilidad { get; set; }

        public Candidato Candidato { get; set; }

    }
}
