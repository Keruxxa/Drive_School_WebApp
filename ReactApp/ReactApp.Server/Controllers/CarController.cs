using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CarController : Controller
    {
        private readonly ICarRepository _carRepository;
        private readonly IMapper _mapper;

        public CarController(ICarRepository carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carRepository.GetCarsAsync();

            var carsMapped = _mapper.Map<List<CarDto>>(cars);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carsMapped);
        }

        [HttpGet("{carId}")]
        [ProducesResponseType(200, Type = typeof(Car))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCar(int carId)
        {
            if (!await _carRepository.CarExistsAsync(carId))
            {
                return NotFound();
            }

            var car = await _carRepository.GetByIdAsync(carId);

            var carMapped = _mapper.Map<CarDto>(car);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carMapped);
        }


        [HttpPost("CreateCar")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCar([FromBody] CarDto car)
        {
            if (car == null)
            {
                return BadRequest(ModelState);
            }

            if (await _carRepository.CarExistsAsync(car.Id))
            {
                ModelState.AddModelError("", "Машина уже существует!");
                StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var carMapped = _mapper.Map<Car>(car);

            if (!await _carRepository.AddCarAsync(carMapped))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
                return StatusCode(500, ModelState);
            }

            return Ok("Машина успешно создана!");
        }
    }
}
