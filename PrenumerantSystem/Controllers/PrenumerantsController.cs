using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrenumerantSystem.Entities;
using PrenumerantSystem.Models;
using PrenumerantSystem.Services;

namespace PrenumerantSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrenumerantsController : ControllerBase
    {
        /* Communicates with the database (context) */
        private readonly IPrenumerantRepository _prenumerantRepository;

        public PrenumerantsController(IPrenumerantRepository prenumerantRepository)
        {
            _prenumerantRepository = prenumerantRepository;
        }


        // GET: api/Prenumerants
        [HttpGet]
        public IActionResult GetPrenumerants()
        {
            var prenumerants = _prenumerantRepository.GetPrenumerants();

            var results = new List<PrenumerantDto>();

            foreach (var p in prenumerants)
            {
                results.Add(new PrenumerantDto()
                {
                    PrenumerantNummer = p.PrenumerantNummer.ToString(),
                    Efternamn = p.Efternamn,
                    Fornamn = p.Fornamn,
                    Personnummer = p.Personnummer,
                    Postnummer = p.Postnummer,
                    Utdelningsadress = p.Utdelningsadress

                });
            }
            return Ok(results);
        }


        // GET: api/Prenumerants/5
        [HttpGet("{prenumerantNumber}")]
        public IActionResult GetPrenumerant([FromRoute] string prenumerantNumber)
        {
            if(!_prenumerantRepository.PrenumerantExists(prenumerantNumber))
            {
                return NotFound();
            }

            Prenumerant prenumerant = _prenumerantRepository.GetPrenumerant(prenumerantNumber);
            PrenumerantDto prenumerantDto = PrenumerantToPrenumerantDto(prenumerant);
            return Ok(prenumerantDto);
        }

        // PUT: api/Prenumerants/5
        [HttpPut("{prenumerantNumber}")]
        public IActionResult PutPrenumerant([FromRoute] string prenumerantNumber, [FromBody] PrenumerantDto prenumerant)
        {
            if (prenumerant == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var prenEntity = _prenumerantRepository.GetPrenumerant(prenumerantNumber);
            if (prenEntity == null) /* Not sure if i should create if not exists instead */
            {
                return NotFound();
            }
            /* The values should have been checked by model validation, so safe to overwrite */
            prenEntity.Fornamn = prenumerant.Fornamn;
            prenEntity.Efternamn = prenumerant.Efternamn;
            prenEntity.Utdelningsadress = prenumerant.Utdelningsadress;
            prenEntity.Personnummer = prenumerant.Personnummer;
            prenEntity.Postnummer = prenumerant.Postnummer;

            _prenumerantRepository.UpdatePrenumerant(prenEntity);
            if (!_prenumerantRepository.Save())
            {
                return StatusCode(500, "A problem occured!");
            }
            return NoContent();
        }



        // CREATE: api/Prenumerants
        [HttpPost]
        public IActionResult PostPrenumerant([FromBody] PrenumerantDto prenumerant)
        {
            if (prenumerant == null)
            {
                return BadRequest();
            }

            /* ModelState is a dictionary. Contains the state of the model and model binding validation
             * It represents a collection of name and value pairs that were submitted to our api, one for each 
             * property. And it also contains a collection of error messages for each value submitted.
             * 
             * Whenever a request comes in the rules we applie to our model, the Dto, are checked. If one of them
             * doesn't check out, the Modelstate Is Valid property will be false. And this property will also be false
             * if an invalid value for a property type is pasted. 
             * */
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            Prenumerant prenEntity = PrenumerantDtoToPrenumerant(prenumerant);

            _prenumerantRepository.AddPrenumerant(prenEntity);
            if(!_prenumerantRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request!");
            }


            return CreatedAtAction("GetPrenumerant", new { id = prenumerant.Personnummer }, prenumerant);
        }



        // DELETE: api/Prenumerants/5
        [HttpDelete("{personnummer}")]
        public IActionResult DeletePrenumerant([FromRoute] string personnummer)
        {
            var prenumerant = _prenumerantRepository.GetPrenumerant(personnummer);
            if(prenumerant == null)
            {
                return NotFound();
            }

            _prenumerantRepository.DeletePrenumerant(prenumerant);

            if (!_prenumerantRepository.Save())
            {
                return StatusCode(500, "A problem happened while handling your request.");
            }
            return NoContent();
        }



     


        /* Helpers to convert between entities and dtos, consider using some automapper in the future */
        private static Prenumerant PrenumerantDtoToPrenumerant(PrenumerantDto prenumerant)
        {
            return new Prenumerant()
            {
                PrenumerantNummer = prenumerant.PrenumerantNummer,
                Utdelningsadress = prenumerant.Utdelningsadress,
                Postnummer = prenumerant.Postnummer,
                Personnummer = prenumerant.Personnummer,
                Fornamn = prenumerant.Fornamn,
                Efternamn = prenumerant.Efternamn
            };
        }

        private static PrenumerantDto PrenumerantToPrenumerantDto(Prenumerant prenumerant)
        {
            return new PrenumerantDto()
            {
                PrenumerantNummer = prenumerant.PrenumerantNummer,
                Utdelningsadress = prenumerant.Utdelningsadress,
                Postnummer = prenumerant.Postnummer,
                Personnummer = prenumerant.Personnummer,
                Fornamn = prenumerant.Fornamn,
                Efternamn = prenumerant.Efternamn
            };
        }


    }
}