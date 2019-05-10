using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Entities
{
    public class PrenumerantAnnonsor : Annonsor
    {
 
       // [Key]
        [Required]
        public string PrenumerantNummer { get; set; }

        public string Personnummer { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Utdelningsadress { get; set; }
        public string Postnummer { get; set; }
    }
}
