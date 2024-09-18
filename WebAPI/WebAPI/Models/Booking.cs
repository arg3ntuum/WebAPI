namespace WebAPI.Models
{
    public class Booking
    {
        public int RoomId { get; set; }
        public DateTime StartTime { get; set; }
        public int DurationHours { get; set; }
        public List<string> SelectedServices { get; set; } = new List<string>();
        public decimal TotalPrice { get; set; }
    }
}
