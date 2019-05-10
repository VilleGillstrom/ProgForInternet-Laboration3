using PrenumerantSystem.Models;

namespace AnnonsSystem.Models.Ads
{

    public class AdPrenumerantDto
    {
        /* Prenumerant information */
        public PrenumerantDto prenumerantInfo { get; set; } = new PrenumerantDto();
        /* Ad information*/
        public AdDto Ad { get; set; } = new AdDto();
    }
}
