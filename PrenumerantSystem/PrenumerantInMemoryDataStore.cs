using PrenumerantSystem.Controllers;
using PrenumerantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenumerantSystem
{
    [Obsolete("Not used any more", true)]
    public class PrenumerantInMemoryDataStore
    {

        public List<PrenumerantDto> Prenumerants { get; set; } /* List of all prenumerants */

        public static PrenumerantInMemoryDataStore Current { get; } = new PrenumerantInMemoryDataStore();

        public PrenumerantInMemoryDataStore()
        {
            Prenumerants = new List<PrenumerantDto>()
            {
                new PrenumerantDto()
                {
                    Personnummer = "111",
                    Fornamn = "klas",
                    Efternamn = "ohlsson"
                },
                  new PrenumerantDto()
                {
                    Personnummer = "222",
                    Fornamn = "bjorn",
                    Efternamn = "bjornsson"
                },
                new PrenumerantDto()
                {
                    Personnummer = "333",
                    Fornamn = "elin",
                    Efternamn = "merlin"
                }

            };
        }

        public PrenumerantDto GetByPersonnummer(int presonnummer)
        {
            return Prenumerants.Find(x => x.Personnummer.Equals(presonnummer));
        }

    }
}
