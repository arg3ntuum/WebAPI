using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConferenceRoomController : ControllerBase
    {
        private readonly BookingService _bookingService;

        public ConferenceRoomController(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost("add")]
        public IActionResult AddRoom([FromBody] ConferenceRoom room)
        {
            return Ok(new { Message = "Room added successfully", RoomId = room.Id });
        }

        [HttpPut("edit/{id}")]
        public IActionResult EditRoom(int id, [FromBody] ConferenceRoom updatedRoom)
        {
            return Ok(new { Message = "Room updated successfully" });
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRoom(int id)
        {
            return Ok(new { Message = "Room deleted successfully" });
        }

        [HttpPost("book")]
        public IActionResult BookRoom([FromBody] Booking booking)
        {
            var room = _bookingService.GetRoomById(booking.RoomId);
            if (room == null)
                return NotFound("Room not found");

            var services = room.Services.Where(s => booking.SelectedServices.Contains(s.Name)).ToList();
            var totalPrice = _bookingService.CalculateTotalPrice(room, booking.StartTime, booking.DurationHours, services);

            return Ok(new { Message = "Booking successful", TotalPrice = totalPrice });
        }
    }

}
