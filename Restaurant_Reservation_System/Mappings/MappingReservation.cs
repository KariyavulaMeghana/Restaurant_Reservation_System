using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Mappings
{
    public static class MappingReservation
    {
        public static ReservationDTO ToDTO(this Reservation reservation)
        {
            return new ReservationDTO
            {
                ReservationId = reservation.ReservationId,
                ReservationDate = reservation.ReservationDate,
                Status = reservation.Status,

            };
        }

        public static Reservation ToEntity(this ReservationDTO reservationDTO)
        {
            return new Reservation
            {
                ReservationId = reservationDTO.ReservationId,
                ReservationDate = reservationDTO.ReservationDate,
                Status = reservationDTO.Status,

            };
        }
        public static List<ReservationDTO> ToDTOList(this List<Reservation> reservation)
        {
            var bookDTOs = new List<ReservationDTO>();
            return reservation.Select(r => r.ToDTO()).ToList();

        }
    }
}

