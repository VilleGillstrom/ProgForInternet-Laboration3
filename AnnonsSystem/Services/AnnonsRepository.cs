using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnonsSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace AnnonsSystem.Services
{
    public class AnnonsRepository: IAnnonsRepository
    {

        private AnnonsContext _context;

        public AnnonsRepository(AnnonsContext context)
        {
            _context = context;
        }

        public IEnumerable<Ad> GetAds()
        {
            return _context.Ads.Include("Annonsor").OrderBy(a => a.Annonsor); 
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }

        public void CreateAd(Ad ad, PrenumerantAnnonsor prenumerant)
        {
            _context.PrenumerantAnnonsors.Add(prenumerant);
            Save();
            ad.AnnonsorId = prenumerant.Id;
            _context.Add(ad);
        }

        public void CreateAd(Ad ad, ForetagAnnonsor prenumerant)
        {
            _context.ForetagAnnonsors.Add(prenumerant);
            Save();
            ad.AnnonsorId = prenumerant.Id;
            _context.Add(ad);
        }
    }
}
