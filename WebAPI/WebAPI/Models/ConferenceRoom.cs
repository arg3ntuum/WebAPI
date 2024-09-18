namespace WebAPI.Models
{
    public class ConferenceRoom
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public decimal BasePricePerHour { get; set; }
        public List<Service> Services { get; set; } = new List<Service>();

    }
}