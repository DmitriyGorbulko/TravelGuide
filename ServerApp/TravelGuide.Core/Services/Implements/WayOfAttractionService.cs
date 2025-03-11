using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Implements
{
    public class WayOfAttractionService : IWayOfAttractionService
    {
        private readonly IWayOfAttractionRepository _wayOfAttractionRepository;
        private readonly AttractionClient _attractionClient;

        public WayOfAttractionService(IWayOfAttractionRepository wayOfAttractionRepository, AttractionClient attractionClient)
        {
            _wayOfAttractionRepository = wayOfAttractionRepository;
            _attractionClient = attractionClient;

        }

        public async Task<WayOfAttraction> Create(int wayId, int attractionId)
        {
            var attraction = await _attractionClient.GetById(attractionId);
            if (attraction == null)
                throw new Exception("Достопримечательность не найдена");

            // Создайте WayOfAttraction
            var wayOfAttraction = new WayOfAttraction()
            {
                WayId = wayId,
                Title = attraction.Title,
                Description = attraction.Description,
                Town = attraction.Town ?? "" 
            };

            return await _wayOfAttractionRepository.Create(wayOfAttraction);
        }


        public async Task Delete(WayOfAttraction wayOfAttraction)
        {
            await _wayOfAttractionRepository.Delete(wayOfAttraction);
        }

        public async Task<WayOfAttraction> Get(int id)
        {
            return await _wayOfAttractionRepository.Get(id);
        }

        public async Task<IEnumerable<WayOfAttraction>> GetAll()
        {
            return await _wayOfAttractionRepository.GetAll();
        }

        public async Task<WayOfAttraction> Update(WayOfAttraction wayOfAttraction)
        {
            return await _wayOfAttractionRepository.Update(wayOfAttraction);
        }
        public async Task<IEnumerable<Attraction>> GetAttractionsByTownTitle(string townTitle)
        {

            /*var request = await _attractionClient.GetAttractionsByTownTitle(townTitle);

            return request.ToList();
            //return await _attractionClient.GetAttractionsByTownTitle(townTitle);*/

            try
            {
                var attractions = await _attractionClient.GetAttractionsByTownTitle(townTitle);
                List<Attraction> list = attractions.ToList();
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в сервисе: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<WayOfAttraction>> GetByWayId(int wayId)
        {
            return await _wayOfAttractionRepository.GetByWayId(wayId);
        }
    }
}
