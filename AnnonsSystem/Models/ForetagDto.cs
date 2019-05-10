using System.ComponentModel.DataAnnotations;

namespace AnnonsSystem.Models
{
    public class ForetagDto
    {
        /* Foretag information */
        [Required]
        public string Namn { get; set; }

        [Required]
        public string Organisationsnummer { get; set; }

        [Required]
        public string Telefonnummer { get; set; }

        [Required]
        public string Utdelningsadress { get; set; }

        [Required]
        public string Postnummer { get; set; }

        [Required]
        public string Ort { get; set; }

        [Required]
        public string Faktura_Adress { get; set; }

        [Required]
        public string Faktura_Postnummer { get; set; }

        [Required]
        public string Faktura_Ort { get; set; }

    }
}
