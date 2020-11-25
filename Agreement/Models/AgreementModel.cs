using System.ComponentModel.DataAnnotations;

namespace Agreement.Models
{
    public class AgreementModel
    {
        [Key]
        [StringLength(maximumLength:7, MinimumLength = 7, ErrorMessage = "Codul unic are lungime invalida.")]
        public string CNPCUI { get; set; }
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string DenumireCompanie { get; set; }
        public string Judet { get; set; }
        [StringLength(maximumLength: 9, MinimumLength = 9, ErrorMessage = "Telefonul are lungime invalida.")]
        public string NrTelefon { get; set; }
        public string Email { get; set; }
        public bool AcordPrelucrareDate{ get; set; }
        public bool ComunicareMarketing { get; set; }
        public bool ComunicareEmail { get; set; }
        public bool ComunicareSMS { get; set; }
        public bool ComunicarePosta { get; set; }
    }
}
