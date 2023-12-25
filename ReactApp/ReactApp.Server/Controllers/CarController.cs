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


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Car>))]
        public async Task<IActionResult> GetCars()
        {
            var cars = await _carRepository.GetCarsAsync();

            var carsDto = _mapper.Map<List<CarDto>>(cars);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carsDto);
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

            var car = await _carRepository.GetCarByIdAsync(carId);

            var carDto = _mapper.Map<CarDto>(car);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(carDto);
        }


        [HttpPost("CreateCar")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateCar([FromBody] CarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest(ModelState);
            }

            if (await _carRepository.CarExistsAsync(carDto.Id))
            {
                ModelState.AddModelError("", "Машина уже существует!");
                StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = _mapper.Map<Car>(carDto);

            if (!await _carRepository.AddCarAsync(car))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания машины!");
                return StatusCode(500, ModelState);
            }

            return Ok("Машина успешно создана!");
        }

        [HttpPut("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateCar(int carId, [FromBody] CarDto carDto)
        {
            if (carDto == null)
            {
                return BadRequest(ModelState);
            }

            if (carId != carDto.Id)
            {
                return BadRequest(ModelState);
            }

            if (!await _carRepository.CarExistsAsync(carId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var car = _mapper.Map<Car>(carDto);

            if (!await _carRepository.UpdateCarAsync(car))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время сохранения информации о машине!");
                return StatusCode(500, ModelState);
            }

            return Ok("Информация о машине успешно обновлена!");
        }


        [HttpDelete("{carId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteCar(int carId)
        {
            if (!await _carRepository.CarExistsAsync(carId))
            {
                return NotFound();
            }

            var car = await _carRepository.GetCarByIdAsync(carId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _carRepository.DeleteCarAsync(car))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления машины!");
                return StatusCode(500, ModelState);
            }

            return Ok("Машина успешно удалена!");
        }
    }
}
