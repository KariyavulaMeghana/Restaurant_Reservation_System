using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IServices;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Service
{
    public class ReservationService : IReservationService
    {
        private readonly RestaurantDbContext _context;

        public ReservationService(RestaurantDbContext context)
        {
            _context = context;
        }
        public async Task<string> BookReservations(ReservationDTO reservationDTO)
        {
            if (reservationDTO == null)
            {
                throw new CustomException("Reservation data cannot be null");
            }
            try
            {
                var reservationEntity = new Reservation
                {
                    ReservationId = reservationDTO.ReservationId,
                    RestaurantId = reservationDTO.RestaurantId,
                    UserId = reservationDTO.UserId,
                    ReservationDate = reservationDTO.ReservationDate,
                    Status = reservationDTO.Status
                };

                _context.Reservations.Add(reservationEntity);
                await _context.SaveChangesAsync();

                return "Booking successful";
            }
            catch (DbUpdateException ex)
            {
                return $"Database error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        public async Task<List<ReservationDTO>> ViewAllReservations()
        {
            var reservations = await _context.Reservations.ToListAsync();
            return reservations.Select(r => new ReservationDTO
            {
                ReservationId = r.ReservationId,
                RestaurantId = r.RestaurantId,
                UserId = r.UserId,
                ReservationDate = r.ReservationDate,
                Status = r.Status
            }).ToList();
        }

        public async Task<List<ReservationDTO>> ViewById(int id)
        {
            var reservations = await _context.Reservations
                .Where(r => r.ReservationId == id)
                .ToListAsync();

            return reservations.Select(r => new ReservationDTO
            {
                ReservationId = r.ReservationId,
                RestaurantId = r.RestaurantId,
                UserId = r.UserId,
                ReservationDate = r.ReservationDate,
                Status = r.Status
            }).ToList();
        }

        public async Task<string> CancelReservation(int id)
        {
            var reservation = await _context.Reservations.FindAsync(id);
            if (reservation != null)
            {
                _context.Reservations.Remove(reservation);
                await _context.SaveChangesAsync();
                return "Reservation cancelled";
            }
            return "Reservation not found";
        }

        public async Task<string> UpdateReservation(int id, ReservationDTO updatedReservation)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(r => r.ReservationId == id);
            if (reservation != null)
            {
                //reservation.RestaurantId = updatedReservation.RestaurantId;
                reservation.UserId = updatedReservation.UserId;
                reservation.ReservationDate = updatedReservation.ReservationDate;
                reservation.Status = updatedReservation.Status;

                await _context.SaveChangesAsync();
                return "Reservation updated successfully";
            }
            return "Reservation not found";
        }

        public async Task<List<ReservationDTO>> ViewByUserId(int userId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return reservations.Select(r => new ReservationDTO
            {
                ReservationId = r.ReservationId,
                RestaurantId = r.RestaurantId,
                UserId = r.UserId,
                ReservationDate = r.ReservationDate,
                Status = r.Status
            }).ToList();
        }

        public async Task<List<ReservationDTO>> ViewByRestaurantId(int restaurantId)
        {
            var reservations = await _context.Reservations
                .Where(r => r.RestaurantId == restaurantId)
                .ToListAsync();

            return reservations.Select(r => new ReservationDTO
            {
                ReservationId = r.ReservationId,
                RestaurantId = r.RestaurantId,
                UserId = r.UserId,
                ReservationDate = r.ReservationDate,
                Status = r.Status
            }).ToList();
        }

        public async Task<List<ReservationDTO>> ViewReservationsByDate(DateTime date)
        {
            var reservations = await _context.Reservations
                .Where(r => r.ReservationDate.Date == date.Date) // Date comparison
                .ToListAsync();

            return reservations.Select(r => new ReservationDTO
            {
                ReservationId = r.ReservationId,
                RestaurantId = r.RestaurantId,
                UserId = r.UserId,
                ReservationDate = r.ReservationDate,
                Status = r.Status
            }).ToList();
        }


    }

}

