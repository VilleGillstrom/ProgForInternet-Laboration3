using System;
using System.ComponentModel.DataAnnotations; /* Allow for annotations */
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


/* This file is linked into AnnonsSystem */
namespace PrenumerantSystem.Models
{
    public class PrenumerantDto
    {

        [MaxLength(40)]
        public string PrenumerantNummer { get; set; }

        [MaxLength(13)]
        public string Personnummer { get; set; }

        [MaxLength(40), RegularExpression("^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage ="Only allow letters")]
        public string Fornamn { get; set; }

        [MaxLength(60), RegularExpression("^[a-zA-ZåäöÅÄÖ]*$", ErrorMessage = "Only allow letters")]
        public string Efternamn { get; set; }

        [MaxLength(200)]
        public string Utdelningsadress { get; set; }

        [MaxLength(100), RegularExpression("[0-9 ]+", ErrorMessage = "Only allow numbers")]
        public string Postnummer { get; set; }
    }

}
