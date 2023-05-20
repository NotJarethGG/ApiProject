namespace Dta.Models
{
    public class Habilidad
    {
        public int Id { get; set; }
        public string NombreHabilidad { get; set; }

        public List<CandidatoHabilidad> CandidatoHabilidades { get; set; }
        public List<OfertaHabilidad> OfertaHabilidades { get; set; }
    }
}
