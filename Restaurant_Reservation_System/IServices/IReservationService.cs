using Restaurant_Reservation_System.DTO;

namespace Restaurant_Reservation_System.IServices
{
    public interface IReservationService
    {
        Task<string> BookReservations(ReservationDTO reservation);
        Task<List<ReservationDTO>> ViewAllReservations(); // Corrected spelling
        Task<List<ReservationDTO>> ViewById(int id);
        Task<string> CancelReservation(int id);
        Task<string> UpdateReservation(int id, ReservationDTO updatedReservation); // Corrected spelling
        Task<List<ReservationDTO>> ViewByUserId(int userId);
        Task<List<ReservationDTO>> ViewByRestaurantId(int restaurantId);
        Task<List<ReservationDTO>> ViewReservationsByDate(DateTime date);
    }
}
