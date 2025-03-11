using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Implements
{
    public class WayOfTourService : IWayOfTourService
    {
        private readonly IWayOfTourRepository _wayOfTourRepository;
        private readonly TourClient _tourClient;

        public WayOfTourService(IWayOfTourRepository wayOfTourRepository, TourClient tourClient)
        {
            _wayOfTourRepository = wayOfTourRepository;
            _tourClient = tourClient;
        }

        public async Task<WayOfTour> Create(int tourId, int wayId)
        {
            // Получаем данные тура через клиент
            var tour = await _tourClient.GetById(tourId);

            if (tour == null)
                throw new Exception("Тур не найден");

            // Создаем объект WayOfTour
            var wayOfTour = new WayOfTour()
            {
                WayId = wayId,
                Title = tour.Title,
                Description = tour.Description,
                Price = tour.Price,
                Town = tour.TownId.ToString(),
                Url = tour.Url
            };

            // Сохраняем в репозитории
            return await _wayOfTourRepository.Create(wayOfTour);
        }

        public async Task Delete(WayOfTour wayOfTour)
        {
            await _wayOfTourRepository.Delete(wayOfTour);
        }

        public async Task<WayOfTour> Get(int id)
        {
            return await _wayOfTourRepository.Get(id);
        }

        public async Task<IEnumerable<WayOfTour>> GetAll()
        {
            return await _wayOfTourRepository.GetAll();
        }

        public async Task<List<Tour>> GetToursByTownTitle(string townTitle)
        {
            try
            {
                var tours = await _tourClient.GetToursByTownTitle(townTitle);
                return tours;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в сервисе: {ex.Message}");
                return null;
            }
        }

        public async Task<WayOfTour> Update(WayOfTour wayOfTour)
        {
            return await _wayOfTourRepository.Update(wayOfTour);
        }

        public async Task<IEnumerable<WayOfTour>> GetByWayId(int wayId)
        {
            return await _wayOfTourRepository.GetByWayId(wayId);
        }
    }
}
