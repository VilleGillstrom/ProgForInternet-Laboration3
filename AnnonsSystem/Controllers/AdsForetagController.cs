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
    public class AdsForetagController : Controller
    {
        /* Service used to talk to prenumerantsystem */
        private readonly IAnnonsRepository _annonsRepository;
        private readonly IMapper _mapper;

        public AdsForetagController(IAnnonsRepository annonsRepository, IMapper mapper)
        {
            _annonsRepository = annonsRepository;
            _mapper = mapper;
        }

        // GET: Ads
        public ActionResult Index()
        {
            return View("AdCreationEditForetag");
        }

        [HttpPost]
        public ActionResult Create(AdForetagDto adForetagDto)
        {
          
            if (!ModelState.IsValid || !(Math.Abs(adForetagDto.Ad.PrisAnnons - 40.0) < 0.0000001))
            {
                return ValidationProblem();
            }
            
            try
            {
                Ad ad = _mapper.Map<Ad>(adForetagDto.Ad);
                ForetagAnnonsor foretag = _mapper.Map<ForetagAnnonsor>(adForetagDto.foretagDto);
                _annonsRepository.CreateAd(ad, foretag);
                if (!_annonsRepository.Save())
                {
                    return BadRequest();
                } 
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }

            return RedirectToAction("Index","Ads" );
        }


        public async Task<IActionResult> AdCreationEditForetag()
        {

            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }

            try
            {
                var foretag = new ForetagDto();
                return View("AdCreationEditForetag", foretag);
            }
            catch
            {
                return BadRequest("Unknown error");
            }

        }


        public async Task<IActionResult> AdCreationAdInfo(ForetagDto foretagDto)
        {
            TempData["BadForetag"] = false;

            if (!ModelState.IsValid)
            {
                TempData["BadForetag"] = true;
                return BadRequest("Unknown error");
            }
            
            var newAd = new AdForetagDto(){ foretagDto = foretagDto};
            newAd.Ad.PrisAnnons = 40.0f; /* Should not be controller's responsibility */
            try
            {
                TempData["BadForetag"] = false;
                return View("AdCreationAdInfo", newAd);
            }
            catch
            {
                return BadRequest("Unknown error");
            }

        }

    }
}