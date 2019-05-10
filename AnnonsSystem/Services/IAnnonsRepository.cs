using AnnonsSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnnonsSystem.Services
{
    public interface IAnnonsRepository
    {

        IEnumerable<Ad> GetAds();
        bool Save(); /* Save changes to database */

        void CreateAd(Ad ad, PrenumerantAnnonsor prenumerant);
        void CreateAd(Ad ad, ForetagAnnonsor prenumerant);
    }
}
