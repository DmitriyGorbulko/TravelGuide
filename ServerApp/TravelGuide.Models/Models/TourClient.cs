using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TravelGuide.Models.Models;

namespace TravelGuide.Models.Models
{
    public class TourClient
    {
        private readonly HttpClient _httpClient;

        public TourClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri("http://localhost:8080/api/tours/"); // Укажите правильный адрес API
        }

        public async Task<List<Tour>> GetToursByTownTitle(string townTitle)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"town/{townTitle}");
            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Полученный контент: {content}");

                try
                {
                    var tours = JsonConvert.DeserializeObject<List<Tour>>(content);
                    Console.WriteLine($"Десериализованные данные: {JsonConvert.SerializeObject(tours)}");
                    return tours;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при десериализации: {ex.Message}");
                    return null;
                }
            }
            else
            {
                throw new Exception("Failed to retrieve tours");
            }
        }

        public async Task<Tour> GetById(int id)
        {

            var requestUrl = $"{id}";
            var response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();

                try
                {
                    Tour tourEntity = JsonConvert.DeserializeObject<Tour>(content);

                    return tourEntity;

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка при десериализации тура по ID: {ex.Message}");
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
