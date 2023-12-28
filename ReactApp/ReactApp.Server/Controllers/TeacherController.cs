using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
using API.Server.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace API.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository teacherRepository, IMapper mapper)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Teacher>))]
        public async Task<IActionResult> GetTeachers()
        {
            var teachers = await _teacherRepository.GetTeachersAsync();

            var teachersDto = _mapper.Map<List<TeacherDto>>(teachers);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(teachersDto);
        }

        [HttpGet("{teacherId}")]
        [ProducesResponseType(200, Type = typeof(Teacher))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTeacher(int teacherId)
        {
            if (!await _teacherRepository.TeacherExistsAsync(teacherId))
            {
                return NotFound();
            }

            var teacher = await _teacherRepository.GetTeacherByIdAsync(teacherId);

            var teacherDto = _mapper.Map<TeacherDto>(teacher);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(teacherDto);
        }


        [HttpPost("CreateTeacher")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTeacher([FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null)
            {
                ModelState.AddModelError("", "NULL!");
                return BadRequest(ModelState);
            }

            ICollection<Teacher> teachers = await _teacherRepository.GetTeachersAsync();

            var teacherToCheck = teachers.Where(t => string.Equals(t.LastName, teacherDto.LastName) &&
                                                     string.Equals(t.FirstName, teacherDto.FirstName))
                                         .FirstOrDefault();

            if (teacherToCheck != null)
            {
                ModelState.AddModelError("", "Преподаватель уже существует!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = _mapper.Map<Teacher>(teacherDto);

            if (!await _teacherRepository.AddTeacherAsync(teacher))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
                return StatusCode(500, ModelState);
            }

            return Ok("Преподаватель успешно создан!");
        }


        [HttpPut("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateStudent(int teacherId, [FromBody] TeacherDto teacherDto)
        {
            if (teacherDto == null)
            {
                return BadRequest(ModelState);
            }

            if (teacherId != teacherDto.Id)
            {
                return NotFound();
            }

            if (!await _teacherRepository.TeacherExistsAsync(teacherId))
            {
                return BadRequest(ModelState);
            }

            var teacher = _mapper.Map<Teacher>(teacherDto);

            if (!await _teacherRepository.UpdateTeacherAsync(teacher))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время обновления информации о преподавателе!");
                return StatusCode(500, ModelState);
            }

            return Ok("Информация о преподавателе успешно обновлена!");
        }


        [HttpDelete("{teacherId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteTeacher(int teacherId)
        {
            if (!await _teacherRepository.TeacherExistsAsync(teacherId))
            {
                return NotFound();
            }

            var review = await _teacherRepository.GetTeacherByIdAsync(teacherId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _teacherRepository.DeleteTeacherAsync(review))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления преподавателя!");
                return StatusCode(500, ModelState);
            }

            return Ok("Преподаватель успешно удален!");
        }
    }
}
