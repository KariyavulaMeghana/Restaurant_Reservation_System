using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;
namespace Restaurant_Reservation_System.IService
{
    public interface IReviewService
    {
        Task<string> AddReview(ReviewDTO reviewCreateDto);
        Task<string> UpdateReview(ReviewDTO reviewDto);
        Task<string> DeleteReview(int id);
        Task<IEnumerable<ReviewDTO>> GetAllReviews();
        Task<ReviewDTO> GetReviewById(int id);
        Task<IEnumerable<ReviewDTO>> GetReviewsByRestaurantId(int restaurantId);
        Task<IEnumerable<ReviewDTO>> GetReviewsByUserId(int userId);
    }

}