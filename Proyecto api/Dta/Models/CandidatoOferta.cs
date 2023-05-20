namespace Dta.Models
{
    public class CandidatoOferta
    {
        public int CandidatoID { get; set; }
        public Candidato Candidato { get; set; }
        public int OfertaID { get; set; }
        public Oferta Oferta { get; set; }
    }
}
