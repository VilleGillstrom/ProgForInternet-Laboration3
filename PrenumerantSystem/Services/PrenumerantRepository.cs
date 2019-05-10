using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PrenumerantSystem.Entities;
using PrenumerantSystem.Controllers;

namespace PrenumerantSystem.Services
{
    public class PrenumerantRepository : IPrenumerantRepository
    {

        private PrenumerantContext _context;

        public PrenumerantRepository(PrenumerantContext context)
        {
            _context = context;
        }

        public void AddPrenumerant(Prenumerant prenumerant)
        {
            if (prenumerant.PrenumerantNummer == null)
            {
                prenumerant.PrenumerantNummer = _context.GeneratePrenumerantNumber();
            }
            _context.Prenumerants.Add(prenumerant);
        }

        public void UpdatePrenumerant(Prenumerant prenumerant)
        {
            _context.Prenumerants.Update(prenumerant);
        }

        public Prenumerant GetPrenumerant(string prenumerantNumber)
        {
            return _context.Prenumerants.SingleOrDefault(p => p.PrenumerantNummer.ToString() == prenumerantNumber);
        }

        public void DeletePrenumerant(Prenumerant prenumerant)
        {
            _context.Prenumerants.Remove(prenumerant);
        }

        public IEnumerable<Prenumerant> GetPrenumerants()
        {
            return _context.Prenumerants.OrderBy(p => p.Efternamn).ToList();

        }

        public bool PrenumerantExists(string prenumerantNumber)
        {
            return _context.Prenumerants.Any(o => o.PrenumerantNummer.ToString() == prenumerantNumber);
        }

        public bool Save()
        {
            return _context.SaveChanges() >= 0;
        }



   
    }
}
