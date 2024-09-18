using WebAPI.Models;

namespace WebAPI.Service
{
    public class BookingService
    {
        private readonly List<ConferenceRoom> _rooms;

        public BookingService(List<ConferenceRoom> rooms)
        {
            _rooms = rooms;
        }

        public ConferenceRoom GetRoomById(int id)
        {
            return _rooms.FirstOrDefault(r => r.Id == id);
        }

        public decimal CalculateTotalPrice(ConferenceRoom room, DateTime startTime, int duration, List<Models.Service> selectedServices)
        {
            decimal totalPrice = 0;
            for (int i = 0; i < duration; i++)
            {
                var currentHour = startTime.AddHours(i).Hour;
                decimal priceMultiplier = GetHourMultiplier(currentHour);
                totalPrice += room.BasePricePerHour * priceMultiplier;
            }

            foreach (var service in selectedServices)
            {
                totalPrice += service.Price;
            }

            return totalPrice;
        }

        private decimal GetHourMultiplier(int hour)
        {
            if (hour >= 12 && hour < 14)
                return 1.15M;  // Пікові години
            if (hour >= 18 && hour < 23)
                return 0.80M;  // Вечірні години
            if (hour >= 6 && hour < 9)
                return 0.90M;  // Ранкові години
            return 1.00M;      // Стандартні години
        }
    }

}
