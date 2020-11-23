using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Agreement.Models
{
    public class AgreementModel
    {
        [Key]
        [StringLength(maximumLength:7, MinimumLength = 7, ErrorMessage = "Codul unic are lungime invalida.")]
        [JsonInclude]
        public string CNPCUI { get; set; }
        [JsonInclude]
        public string Nume { get; set; }
        [JsonInclude]
        public string Prenume { get; set; }
        [JsonInclude]
        public string DenumireCompanie { get; set; }
        [JsonInclude]
        public string Judet { get; set; }
        [JsonInclude]
        public string NrTelefon { get; set; }
        [JsonInclude]
        public string Email { get; set; }
        [JsonInclude]
        public bool AcordPrelucrareDate{ get; set; }
        [JsonInclude]
        public bool ComunicareMarketing { get; set; }
        [JsonInclude]
        public bool ComunicareEmail { get; set; }
        [JsonInclude]
        public bool ComunicareSMS { get; set; }
        [JsonInclude]
        public bool ComunicarePosta { get; set; }
    }
}
