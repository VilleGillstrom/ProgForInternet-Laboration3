using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnnonsSystem.Entities;
using AnnonsSystem.Models;
using AnnonsSystem.Models.Ads;
using AnnonsSystem.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrenumerantSystem.Entities;
using PrenumerantSystem.Models;

namespace AnnonsSystem.Controllers
{
    public class AdsPrenumerantsController : Controller
    {
        /* Service used to talk to prenumerantsystem */
        private readonly IPrenumerantsCRUDService _prenumerantCRUDService;
        private readonly IAnnonsRepository _annonsRepository;

        public AdsPrenumerantsController(IPrenumerantsCRUDService prenumerantCRUDService, IAnnonsRepository annonsRepository)
        {
            _prenumerantCRUDService = prenumerantCRUDService;
            _annonsRepository = annonsRepository;
        }

        // GET: Ads
        public ActionResult Index()
        {
            return View("AdCreationGetPrenumerant");
        }

        [HttpPost]
        public ActionResult Create(AdPrenumerantDto adPrenumerantDto)
        {
          
            if (!ModelState.IsValid || !(Math.Abs(adPrenumerantDto.Ad.PrisAnnons - 0.0) < 0.0000001))
            {
                return ValidationProblem();
            }
            
            try
            {
                Ad ad = Mapper.Map<Ad>(adPrenumerantDto.Ad);
                PrenumerantAnnonsor prenumerant = Mapper.Map<PrenumerantAnnonsor>(adPrenumerantDto.prenumerantInfo);
                _annonsRepository.CreateAd(ad, prenumerant);
                if (!_annonsRepository.Save())
                {
                    return BadRequest();
                } 
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToAction("Index", "Ads");
        }

        public ActionResult PrenumerantAdCreationFetchPrenumerant()
        {
            return View("AdCreationGetPrenumerant");
        }

        public async Task<IActionResult> AdCreationEditPrenumerant(string prenumerantId)
        {
            TempData["FetchError"] = false;
            try
            {
                PrenumerantDto prenumerant = await _prenumerantCRUDService.GetPrenumerantAsync(prenumerantId);
                return View("AdCreationEditPrenumerant", prenumerant);
            }
            catch
            {
                TempData["FetchError"] = true;
                return RedirectToAction(nameof(PrenumerantAdCreationFetchPrenumerant));
            }
          
        }

        public async Task<IActionResult> AdCreationAdInfo(PrenumerantDto prenumerant)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Bad prenumerant");
            }
            
            var newAd = new AdPrenumerantDto(){ prenumerantInfo = prenumerant };
            newAd.Ad.PrisAnnons = 0.0f; /* Should not be controller's responsibility */
            try
            {
                return View("AdCreationAdInfo", newAd);
            }
            catch
            {
                return BadRequest("Unknown error");
            }
        }
    }
}