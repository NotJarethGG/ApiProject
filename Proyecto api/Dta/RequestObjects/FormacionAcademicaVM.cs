

namespace Dta.RequestObjects
{
    public class FormacionAcademicaVM
    {
        public int Id { get; set; }

        public string NombreTitulo { get; set; }
        public int AniosEstudio { get; set; }
        public string FechaConclusion { get; set; }

        //Relaciones
        public int CandidatoId { get; set; }
    }
}
