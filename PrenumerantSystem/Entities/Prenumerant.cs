using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PrenumerantSystem.Entities
{
    public class Prenumerant
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] /* Database will generate an id*/
        public int Id { get; set; }

        [Required]
        public string PrenumerantNummer { get; set; }
        public string Personnummer { get; set; }
        public string Fornamn { get; set; }
        public string Efternamn { get; set; }
        public string Utdelningsadress { get; set; }
        public string Postnummer { get; set; }
    }
}
