using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelGuide.Models.Models;

namespace TravelGuide.Models.Models
{
    public class GuideClient
    {
        private readonly HttpClient _httpClient;

        public GuideClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/guides/"); // Укажите правильный адрес API
        }

        public async Task<List<Guide>> GetGuidesByTownTitle(string townTitle)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"town/{townTitle}");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Полученный контент: {content}");

                try
                {
                    var guides = JsonConvert.DeserializeObject<List<Guide>>(content);
                    Console.WriteLine($"Десериализованные данные: {JsonConvert.SerializeObject(guides)}");
                    return guides;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
                    return null;
                }
            }
            else
            {
                throw new Exception("Failed to retrieve guides");
            }
        }

        public async Task<Guide> GetById(int id)
        {

            var requestUrl = $"{id}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                try
                {
                    Guide guide = JsonConvert.DeserializeObject<Guide>(content);

                    return guide;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при десериализации гида по ID: {ex.Message}");
                    return null;
                }

            }
            else
            {
                Console.WriteLine($"Ошибка при получении данных:{response.StatusCode}");
                return null;
            }
        }
    }
}
