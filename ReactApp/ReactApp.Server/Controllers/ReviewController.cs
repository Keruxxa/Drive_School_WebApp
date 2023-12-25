using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
using API.Server.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ReviewController : Controller
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewController(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Review>))]
        public async Task<IActionResult> GetReviews()
        {
            var reviews = await _reviewRepository.GetReviewsAsync();

            var reviewsMapped = _mapper.Map<List<ReviewDto>>(reviews);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewsMapped);
        }

        [HttpGet("{reviewId}")]
        [ProducesResponseType(200, Type = typeof(Review))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetReview(int reviewId)
        {
            if (!await _reviewRepository.ReviewExistsAsync(reviewId))
            {
                return NotFound();
            }

            var review = await _reviewRepository.GetReviewByIdAsync(reviewId);

            var reviewMapped = _mapper.Map<ReviewDto>(review);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(reviewMapped);
        }


        [HttpPost("CreateReview")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto,
                                                      [FromQuery] int studentId,
                                                      [FromQuery] int teacherId)
        {
            if (reviewDto == null)
            {
                return BadRequest(ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var review = _mapper.Map<Review>(reviewDto);

            if (!await _reviewRepository.AddReviewAsync(review, studentId, teacherId))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
                return StatusCode(422, ModelState);
            }

            return Ok("Отзыв успешно добавлен!");
        }


        [HttpPut("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateReview([FromBody] ReviewDto reviewDto,
                                                      [FromQuery] int reviewId,
                                                      [FromQuery] int studentId,
                                                      [FromQuery] int teacherId)
        {
            if (reviewDto == null)
            {
                return BadRequest(ModelState);
            }

            if (reviewId != reviewDto.Id)
            {
                return NotFound();
            }

            var review = _mapper.Map<Review>(reviewDto);

            if (!await _reviewRepository.UpdateReviewAsync(review, studentId, teacherId))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время обновления информации об отзыве!");
                return StatusCode(500, ModelState);
            }

            return Ok("Информация об отзыве успешно обновлена!");
        }


        [HttpDelete("{reviewId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            if (!await _reviewRepository.ReviewExistsAsync(reviewId))
            {
                return NotFound();
            }

            var review = await _reviewRepository.GetReviewByIdAsync(reviewId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _reviewRepository.DeleteReviewAsync(review))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления отзыва!");
                return StatusCode(500, ModelState);
            }

            return Ok("Отзыв успешно удален!");
        }
    }
}
