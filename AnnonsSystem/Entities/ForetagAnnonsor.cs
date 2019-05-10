using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Entities
{
    public class ForetagAnnonsor : Annonsor
    {
        public string Namn { get; set; }

        [Required]
        public string Organisationsnummer { get; set; }

        public string Telefonnummer { get; set; }
        public string Utdelningsadress { get; set; }
        public string Postnummer { get; set; }
        public string Ort { get; set; }

        public string Faktura_Adress { get; set; }
        public string Faktura_Postnummer { get; set; }
        public string Faktura_Ort { get; set; }

    }
}
