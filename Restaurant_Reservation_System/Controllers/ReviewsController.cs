using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Restaurant_Reservation_System.DTO;
using Restaurant_Reservation_System.IService;

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
        public async Task<IActionResult> PostReview([FromBody] ReviewDTO reviewCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _reviewService.AddReview(reviewCreateDto);
            if (result == "Review added successfully")
            {
                return Ok(new { Message = result });
            }
            return BadRequest(new { Message = result });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReviewDTO>> GetReviewById(int id)
        {
            try
            {
                var review = await _reviewService.GetReviewById(id);
                if (review == null)
                {
                    return NotFound();
                }
                return Ok(review);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReview(int id, [FromBody] ReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            reviewDto.ReviewID = id; // Set the ReviewID from the URL parameter
            var result = await _reviewService.UpdateReview(reviewDto);
            if (result == "Review updated successfully")
            {
                return Ok(new { Message = result });
            }
            return BadRequest(new { Message = result });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReview(int id)
        {
            try
            {
                var result = await _reviewService.DeleteReview(id);
                if (result == "Review deleted successfully")
                {
                    return Ok(new { Message = result });
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
