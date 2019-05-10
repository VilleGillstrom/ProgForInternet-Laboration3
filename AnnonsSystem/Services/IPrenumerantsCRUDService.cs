using PrenumerantSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AnnonsSystem.Services
{
    public interface IPrenumerantsCRUDService
    {
        Task<List<PrenumerantDto>> GetPrenumerantsAsync();
        Task<PrenumerantDto> GetPrenumerantAsync(string personnummer);
        void CreatePrenumerantAsync(PrenumerantDto prenumerantDto);
        void UpdatePrenumerantAsync(string personnummerToUpdate, PrenumerantDto prenumerantDto);
        void DeletePrenumerantAsync(string personnummerToUpdate);
    }
}
