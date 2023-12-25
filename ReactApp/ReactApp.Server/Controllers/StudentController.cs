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
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();

            var studentsDto = _mapper.Map<List<StudentDto>>(students);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(studentsDto);
        }


        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            if (!await _studentRepository.StudentExistsAsync(studentId))
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentByIdAsync(studentId);

            var studentDto = _mapper.Map<StudentDto>(student);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(studentDto);
        }


        [HttpPost("CreateStudent")]
        [ProducesResponseType(244)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateStudent([FromQuery] int groupId, [FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest(ModelState);
            }

            var students = await _studentRepository.GetStudentsAsync();

            var studentsToCheck = students.Where(s => s.LastName == studentDto.LastName &&
                                                      s.FirstName == studentDto.FirstName).FirstOrDefault();

            if (studentsToCheck != null)
            {
                ModelState.AddModelError("", "Студент уже существует!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentDto);

            if (!await _studentRepository.AddStudentAsync(student, groupId))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания студента!");
                return StatusCode(500, ModelState);
            }

            return Ok("Студент успешно создан!");
        }


        [HttpPut("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateStudent([FromQuery] int studentId,
                                                       [FromQuery] int groupId,
                                                       [FromBody] StudentDto studentDto)
        {
            if (studentDto == null)
            {
                return BadRequest(ModelState);
            }

            if (studentId != studentDto.Id)
            {
                return NotFound();
            }

            if (!await _studentRepository.StudentExistsAsync(studentId))
            {
                return BadRequest(ModelState);
            }

            var student = _mapper.Map<Student>(studentDto);

            if (!await _studentRepository.UpdateStudentAsync(student, groupId))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время обновления информации о студенте!");
                return StatusCode(500, ModelState);
            }

            return Ok("Информация о студенте успешно обновлена!");
        }


        [HttpDelete("{studentId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            if (!await _studentRepository.StudentExistsAsync(studentId))
            {
                return NotFound();
            }

            var student = await _studentRepository.GetStudentByIdAsync(studentId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _studentRepository.DeleteStudentAsync(student))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления студента!");
                return StatusCode(500, ModelState);
            }

            return Ok("Студент успешно удален!");
        }
    }
}
