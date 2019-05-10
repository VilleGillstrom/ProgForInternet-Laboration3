//using AnnonsSystem.Models;
//using AnnonsSystem.Services;
//using Microsoft.AspNetCore.Mvc;
//using PrenumerantSystem.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc.ViewComponents;

//namespace AnnonsSystem.ViewComponents
//{
//    public class PrenumerantAdCreationViewComponent : ViewComponent
//    {
//        /* Service used to talk to prenumerantsystem */
//        private readonly IPrenumerantsCRUDService _prenumerantCRUDService;

//        public PrenumerantAdCreationViewComponent(IPrenumerantsCRUDService prenumerantCRUDService)
//        {
//            _prenumerantCRUDService = prenumerantCRUDService;
//        }


//        public async Task<IViewComponentResult> InvokeAsync(string prenumerantId, bool PrenumerantIsFetched)
//        {
//            ViewViewComponentResult view;
//            if (prenumerantId != null)
//            {
//                AdCreationPrenumerantDto item = await GetPrenumerant(prenumerantId);
//                view = View("AdCreation", item);
//            } else
//            {
//                view = View("Default");
//            }
           
//            return view;
//        }


//        private async Task<AdCreationPrenumerantDto> GetPrenumerant(string prenumerantId)
//        {
//            //Task<PrenumerantDto> foo = _prenumerantCRUDService.GetPrenumerantByPrenumerantIdentifierAsync(prenumerantId);
//            AdCreationPrenumerantDto foo = new AdCreationPrenumerantDto();
//            foo.prenumerantInfo.Fornamn = "pelle";

//            return foo;
//        }

     
//    }
//}
