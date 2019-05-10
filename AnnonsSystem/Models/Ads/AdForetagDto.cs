using System.ComponentModel.DataAnnotations;

namespace AnnonsSystem.Models
{
    public class AdForetagDto
    {
        /* Foretag information */
        [Required]
        public ForetagDto foretagDto { get; set; } = new ForetagDto();
        /* Ad information*/
        [Required]
        public AdDto Ad { get; set; } = new AdDto();
    }
}
