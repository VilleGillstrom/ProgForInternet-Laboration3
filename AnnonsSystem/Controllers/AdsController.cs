using System.Collections.Generic;
using System.Linq;
using AnnonsSystem.Entities;
using AnnonsSystem.Models;
using AnnonsSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AnnonsSystem.Controllers
{
    public class AdsController : Controller
    {
        /* Service used to talk to prenumerantsystem */
        private readonly IAnnonsRepository _annonsRepository;

        public AdsController(IAnnonsRepository annonsRepository)
        {
            _annonsRepository = annonsRepository;
        }
        // GET: Ads
        public ActionResult Index()
        {
            return View();
        }


        // GET: Ads/Display/
        public ActionResult Display()
        {
            IEnumerable<Ad> ads = _annonsRepository.GetAds();
            IEnumerable<AdDto> result = Mapper.Map<IEnumerable<AdDto>>(ads);
            for (int i = 0; i < ads.Count(); i++)
            {
                Annonsor a = ads.ElementAt(i).Annonsor;
                result.ElementAt(i).AnnonsorType = a.GetType().Name;
            }
            return View("Annonser", result);
        }
      
    }
}