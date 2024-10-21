using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IService;
using Restaurant_Reservation_System.Models;

namespace Restaurant_Reservation_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetReviews()
        {
            try
            {
                var reviews = await _reviewService.GetAllReviews();
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostReview(ReviewDTO reviewCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reviewService.AddReview(reviewCreateDto);
            if (result == "Review added successfully")
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(int id)
        {
            if(id != 0)
            {
                var review = await _reviewService.GetReviewById(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
            }
           else
            {
                throw new CustomException("Id cannot be zero");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            reviewDto.ReviewID = id;
            var result = await _reviewService.UpdateReview(reviewDto);
            if (result == "Review updated successfully")
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var result = await _reviewService.DeleteReview(id);
                if (result == "Review deleted successfully")
                {
                    return Ok(result);
                }
                return BadRequest(new { Message = result });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpGet("restaurant/{restaurantId}")]
        public async Task<IActionResult> GetReviewsByRestaurantId(int restaurantId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByRestaurantId(restaurantId);
                return Ok(reviews);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetReviewsByUserId(int userId)
        {
            try
            {
                var reviews = await _reviewService.GetReviewsByUserId(userId);
                return Ok(reviews);
			}
            catch (Exception ex)
            {
				return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
			}
		}
    }
}
