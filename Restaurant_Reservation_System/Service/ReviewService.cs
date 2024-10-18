using Microsoft.EntityFrameworkCore;
using Restaurant_Reservation_System.Data;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IService;
using Restaurant_Reservation_System.Models;
using System;
    namespace Restaurant_Reservation_System.Services
    {
        public class ReviewService : IReviewService
        {
            private readonly RestaurantDbContext _context;

            public ReviewService(RestaurantDbContext context)
            {
                _context = context;
            }

            public async Task<string> AddReview(ReviewDTO reviewCreateDto)
            {
                var review = new Review
                {
                    UserID = reviewCreateDto.UserID,
                    RestaurantID = reviewCreateDto.RestaurantID,
                    Rating = reviewCreateDto.Rating,
                    Comment = reviewCreateDto.Comment,
                    ReviewDate = reviewCreateDto.ReviewDate
                };

                _context.Reviews.Add(review);
                await _context.SaveChangesAsync();
                return "Review added successfully";
            }

            public async Task<string> DeleteReview(int id)
            {
                var review = await _context.Reviews.FindAsync(id);
                if (review == null)
                {
                    return "Review not found";
                }

                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
                return "Review deleted successfully";
            }

            public async Task<IEnumerable<ReviewDTO>> GetAllReviews()
            {
                return await _context.Reviews
                    .Select(r => new ReviewDTO
                    {
                        ReviewID = r.ReviewID,
                        UserID = r.UserID,
                        RestaurantID = r.RestaurantID,
                        Rating = r.Rating,
                        Comment = r.Comment,
                        ReviewDate = r.ReviewDate
                    })
                    .ToListAsync();
            }

            public async Task<ReviewDTO> GetReviewById(int id)
            {
                var review = await _context.Reviews.FindAsync(id);
                if (review == null)
                {
                    return null;
                }

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

            public async Task<IEnumerable<ReviewDTO>> GetReviewsByRestaurantId(int restaurantId)
            {
                return await _context.Reviews
                    .Where(r => r.RestaurantID == restaurantId)
                    .Select(r => new ReviewDTO
                    {
                        ReviewID = r.ReviewID,
                        UserID = r.UserID,
                        RestaurantID = r.RestaurantID,
                        Rating = r.Rating,
                        Comment = r.Comment,
                        ReviewDate = r.ReviewDate
                    })
                    .ToListAsync();
            }

            public async Task<IEnumerable<ReviewDTO>> GetReviewsByUserId(int userId)
            {
                return await _context.Reviews
                    .Where(r => r.UserID == userId)
                    .Select(r => new ReviewDTO
                    {
                        ReviewID = r.ReviewID,
                        UserID = r.UserID,
                        RestaurantID = r.RestaurantID,
                        Rating = r.Rating,
                        Comment = r.Comment,
                        ReviewDate = r.ReviewDate
                    })
                    .ToListAsync();
            }

            public async Task<string> UpdateReview(ReviewDTO reviewDto)
            {
                var review = await _context.Reviews.FindAsync(reviewDto.ReviewID);
                if (review == null)
                {
                    return "Review not found";
                }
                review.UserID = reviewDto.UserID;
                review.RestaurantID=reviewDto.RestaurantID;
                review.Rating = reviewDto.Rating;
                review.Comment = reviewDto.Comment;
                review.ReviewDate = reviewDto.ReviewDate;

                _context.Reviews.Update(review);
                await _context.SaveChangesAsync();
                return "Review updated successfully";
            }
        }
    }

