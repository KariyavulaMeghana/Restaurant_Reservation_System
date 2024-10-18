using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Mappings
{
    public static class MappingReviews
    {
        public static ReviewDTO ToDTO(this Review review)
        {
            return new ReviewDTO
            {
                ReviewID = review.ReviewID,
                UserID = review.UserID,
                RestaurantID = review.RestaurantID,
                Rating = review.Rating,
                Comment = review.Comment,
                ReviewDate = review.ReviewDate
            };
        }
        public static Review ToEntity(this ReviewDTO reviewDto)
        {
            return new Review
            {
                ReviewID = reviewDto.ReviewID,
                UserID = reviewDto.UserID,
                RestaurantID = reviewDto.RestaurantID,
                Rating = reviewDto.Rating,
                Comment = reviewDto.Comment,
                ReviewDate = reviewDto.ReviewDate
            };
        }
    }

}
