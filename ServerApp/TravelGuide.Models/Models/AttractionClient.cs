using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Models.Models;

namespace TravelGuide.Models.Models
{
    public class AttractionClient
    {
        private readonly HttpClient _httpClient;

        public AttractionClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/attractions/");
        }

        public async Task<IEnumerable<Attraction>> GetAttractionsByTownTitle(string townTitle)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"town/{townTitle}");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Полученный контент: {content}");

                try
                {
                    var attractions = JsonConvert.DeserializeObject<List<Attraction>>(content);
                    Console.WriteLine($"Десериализованные данные: {JsonConvert.SerializeObject(attractions)}");
                    return attractions;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
                    return null;
                }
            }
            else
            {
                throw new Exception("Failed to retrieve attractions");
            }
        }

        public async Task<Attraction> GetById(int id)
        {

            var requestUrl = $"{id}";
            var response = await _httpClient.GetAsync(requestUrl);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Attraction attraction = JsonConvert.DeserializeObject<Attraction>(content);
                return attraction;
            }
            else
            {
                Console.WriteLine($"Ошибка при получении данных:{response.StatusCode}");
                return null;
            }
        }
    }
}
