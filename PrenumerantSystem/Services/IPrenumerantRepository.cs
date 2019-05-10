using PrenumerantSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrenumerantSystem.Services
{
    public interface IPrenumerantRepository
    {

        bool PrenumerantExists(string prenumerantNumber); 
        IEnumerable<Prenumerant> GetPrenumerants();  
        Prenumerant GetPrenumerant(string prenumerantNumber);
        void AddPrenumerant(Prenumerant prenumerant);
        void UpdatePrenumerant(Prenumerant prenumerant);
        void DeletePrenumerant(Prenumerant prenumerant);

        bool Save(); /* Save changes to database */
    }
}
