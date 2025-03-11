using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TravelGuide.Core.Repositories.Interfaces;
using TravelGuide.Core.Services.Interfaces;
using TravelGuide.Db.Entity;
using TravelGuide.Models;
using TravelGuide.Models.Models;

namespace TravelGuide.Core.Services.Implements
{
    public class WayOfGuideService : IWayOfGuideService
    {
        private readonly IWayOfGuideRepository _wayOfGuideRepository;
        private readonly GuideClient _guideClient;

        public WayOfGuideService(IWayOfGuideRepository wayOfGuideRepository, GuideClient guideClient)
        {
            _wayOfGuideRepository = wayOfGuideRepository;
            _guideClient = guideClient;
        }

        public async Task<WayOfGuide> Create(int guideId, int wayId)
        {
            // Получаем данные гида через клиент
            var guide = await _guideClient.GetById(guideId);

            if (guide == null)
                throw new Exception("Гид не найден");

            // Создаем объект WayOfGuide
            var wayOfGuide = new WayOfGuide()
            {
                WayId = wayId,
                FirstName = guide.FirstName,
                LastName = guide.LastName,
                Description = guide.Description,
                Town = guide.TownId.ToString(),
                // Обрабатываем случай, когда TelegramUsername равен null
                TelegramUsername = string.IsNullOrEmpty(guide.TelegramUsername) ? "" : guide.TelegramUsername,
            };

            // Сохраняем в репозитории
            return await _wayOfGuideRepository.Create(wayOfGuide);
        }

        public async Task Delete(WayOfGuide wayOfGuide)
        {
            await _wayOfGuideRepository.Delete(wayOfGuide);
        }

        public async Task<WayOfGuide> Get(int id)
        {
            return await _wayOfGuideRepository.Get(id);
        }

        public async Task<IEnumerable<WayOfGuide>> GetAll()
        {
            return await _wayOfGuideRepository.GetAll();
        }

        public async Task<WayOfGuide> Update(WayOfGuide wayOfGuide)
        {
            return await _wayOfGuideRepository.Update(wayOfGuide);
        }

        public async Task<IEnumerable<Guide>> GetGuidesByTownTitle(string townTitle)
        {
            try
            {
                var guides = await _guideClient.GetGuidesByTownTitle(townTitle);
                return guides.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка в сервисе: {ex.Message}");
                return null;
            }
        }

        public async Task<IEnumerable<WayOfGuide>> GetByWayId(int wayId)
        {
            return await _wayOfGuideRepository.GetByWayId(wayId);
        }
    }
}
