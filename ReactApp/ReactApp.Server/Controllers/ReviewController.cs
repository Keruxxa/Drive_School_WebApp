using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
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


        [HttpGet]
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

            var review = await _reviewRepository.GetByIdAsync(reviewId);

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
        public async Task<IActionResult> CreateReview([FromBody] ReviewDto reviewDto)
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

            if (!await _reviewRepository.AddReviewAsync(review))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
                return StatusCode(422, ModelState);
            }

            return Ok("Отзыв успешно добавлен!");
        }
    }
}
