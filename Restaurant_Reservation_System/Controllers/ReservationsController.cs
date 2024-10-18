using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservations()
        {
            var reservations = await _reservationService.ViewAllReservations(); // Corrected method name
            return Ok(reservations);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationById(int id)
        {
            var reservation = await _reservationService.ViewById(id);

            if (reservation == null || reservation.Count == 0)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<ActionResult<string>> PostReservation(ReservationDTO reservation)
        {
            var result = await _reservationService.BookReservations(reservation);
            return Ok(result);
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteReservation(int id)
        {
            var result = await _reservationService.CancelReservation(id);

            if (result == "it is not cancelled")
            {
                return NotFound();
            }

            return Ok(result);
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateReservation(int id, ReservationDTO updatedReservation)
        {
            var result = await _reservationService.UpdateReservation(id, updatedReservation); // Corrected method name

            if (result == "Reservation not found.")
            {
                return NotFound();
            }

            return Ok(result);
        }


        // GET: api/Reservations/ByRestaurant/5
        [HttpGet("ByRestaurant/{restaurantId}")]
        public async Task<ActionResult<List<ReservationDTO>>> GetReservationsByRestaurantId(int restaurantId)
        {
            var reservations = await _reservationService.ViewByRestaurantId(restaurantId);
            if (reservations == null || reservations.Count == 0)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

        // GET: api/Reservations/ByUser/5
        [HttpGet("ByUser/{userId}")]
        public async Task<ActionResult<List<ReservationDTO>>> GetReservationsByUserId(int userId)
        {
            var reservations = await _reservationService.ViewByUserId(userId);
            if (reservations == null || reservations.Count == 0)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

        // GET: api/Reservations/ByDate
        [HttpGet("ByDate")]
        public async Task<ActionResult<List<ReservationDTO>>> GetReservationsByDate([FromQuery] DateTime reservationDate)
        {
            var reservations = await _reservationService.ViewReservationsByDate(reservationDate); // Corrected method name

            if (reservations == null || reservations.Count == 0)
            {
                return NotFound();
            }

            return Ok(reservations);
        }

    }
}

