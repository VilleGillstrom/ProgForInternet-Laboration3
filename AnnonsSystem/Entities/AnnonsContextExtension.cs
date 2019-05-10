using PrenumerantSystem.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/**
 * This class adds a function to fill the database with dummy data
 * during dev.
 *  
 */
namespace AnnonsSystem.Entities
{
    public static class AnnonsContextExtension
    {
        public static void EnsureSeedDataForContext(this AnnonsContext context)
        {
            if (context.ForetagAnnonsors.Any())
            {
                return;
            }


            var foretagAnnonsors = new List<ForetagAnnonsor>()
            {
                new ForetagAnnonsor
                {
                    Namn = "Foretag A",
                    Organisationsnummer = "6424",
                    Telefonnummer = "8856449",
                    Utdelningsadress = "Ingevägen 12",
                    Postnummer = "897 65",
                    Ort = "Umea",
                    Faktura_Adress = "Tingevägen 74",
                    Faktura_Postnummer = "8537 636",
                    Faktura_Ort = "Stockholm",
                    Ad = new Ad
                    {
                        Rubrik = "Rubrik A",
                        Innehall = "Innehåll A",
                        PrisVara = 333,
                        PrisAnnons = 0
                    }
                },
                new ForetagAnnonsor
                {
                    Namn = "Foretag B",
                    Organisationsnummer = "5333",
                    Telefonnummer = "8856449",
                    Utdelningsadress = "Ingevägen 12",
                    Postnummer = "897 65",
                    Ort = "Umea",
                    Faktura_Adress = "Tingevägen 74",
                    Faktura_Postnummer = "8537 636",
                    Faktura_Ort = "Stockholm",
                    Ad = new Ad
                    {
                        Rubrik = "Rubrik B",
                        Innehall = "Innehåll B",
                        PrisVara = 444,
                        PrisAnnons = 40
                    }
                },
                new ForetagAnnonsor
                {
                    Namn = "Mitt Foretag",
                    Organisationsnummer = "471874",
                    Telefonnummer = "8856449",
                    Utdelningsadress = "Ingevägen 12",
                    Postnummer = "897 65",
                    Ort = "Umea",
                    Faktura_Adress = "Tingevägen 74",
                    Faktura_Postnummer = "8537 636",
                    Faktura_Ort = "Stockholm",
                    Ad = new Ad
                    {
                        Rubrik = "Rubrik C",
                        Innehall = "Innehåll C",
                        PrisVara = 555,
                        PrisAnnons = 40
                    },
                  

            }
            };

            context.ForetagAnnonsors.AddRange(foretagAnnonsors);
            context.SaveChanges(); /* This executes stuff on the database */

        }
    }
}
