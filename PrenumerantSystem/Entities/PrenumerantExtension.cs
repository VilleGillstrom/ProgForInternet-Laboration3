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
namespace PrenumerantSystem.Entities
{
    public static class PrenumerantExtension
    {
        public static void EnsureSeedDataForContext(this PrenumerantContext context)
        {
            if(context.Prenumerants.Any())
            {
                return;
            }

            var prenumerants = new List<Prenumerant>()
            {
                new Prenumerant()
                {
                    Personnummer = "19570901-5555",
                    Fornamn = "klas",
                    Efternamn = "ohlsson",
                    Utdelningsadress = "tvistevagen",
                    Postnummer = "124 52",
                    PrenumerantNummer = "00001"

                },
                  new Prenumerant()
                {
                    Personnummer = "19870214-6666",
                    Fornamn = "bjorn",
                    Efternamn = "bjornsson",
                    Utdelningsadress = "mellerstigen",
                    Postnummer = "152 11",
                    PrenumerantNummer = "00002"
                },
                new Prenumerant()
                {
                    Personnummer = "20091214-7777",
                    Fornamn = "elin",
                    Efternamn = "merlin",
                    Utdelningsadress = "råkgatan",
                    Postnummer = "114 33",
                    PrenumerantNummer = "00003"
                }
            };

            context.Prenumerants.AddRange(prenumerants);
            context.SaveChanges(); /* This executes stuff on the database */
        }
    }
}
