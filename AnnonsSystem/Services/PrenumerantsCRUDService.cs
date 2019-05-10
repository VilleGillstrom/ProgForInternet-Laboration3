using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PrenumerantSystem.Models;

namespace AnnonsSystem.Services
{


    public class PrenumerantsCRUDService : IPrenumerantsCRUDService
    {

        private static HttpClient _httpClient = new HttpClient();

        public PrenumerantsCRUDService()
        {
            
            _httpClient.BaseAddress = new Uri("https://localhost:44387"); /* SHOULD I PUT URI STRING SOMEWHERE ELSE?!?*/
            _httpClient.Timeout = new TimeSpan(0, 0, 2);
        }



        public async Task<List<PrenumerantDto>> GetPrenumerantsAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("api/Prenumerants");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<PrenumerantDto>>(content);
        }

        public async Task<PrenumerantDto> GetPrenumerantAsync(string prenumerantNumber)
        {
            string uri = String.Format("api/Prenumerants/{0}", prenumerantNumber);
            HttpResponseMessage response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var content = await response.Content.ReadAsStringAsync();
            var prenumerantDto = JsonConvert.DeserializeObject<PrenumerantDto>(content);
            return prenumerantDto;
        }



        public async void CreatePrenumerantAsync(PrenumerantDto prenumerantDto)
        {
            string uri = String.Format("api/Prenumerants/");
            string serializedDto = JsonConvert.SerializeObject(prenumerantDto);
            var content = new StringContent(serializedDto.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async void UpdatePrenumerantAsync(string prenumerantNumber, PrenumerantDto prenumerantDto)
        {
            string uri = String.Format("api/Prenumerants/{0}", prenumerantNumber);
            string serializedDto = JsonConvert.SerializeObject(prenumerantDto);
            var content = new StringContent(serializedDto.ToString(), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async void DeletePrenumerantAsync(string prenumerantNumber)
        {
            string uri = String.Format("api/Prenumerants/{0}", prenumerantNumber);
            HttpResponseMessage response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }

      
    }
}
