using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
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

            return Ok(students);
        }


        [HttpGet("{studentId}")]
        [ProducesResponseType(200, Type = typeof(Student))]
        public async Task<IActionResult> GetStudent(int studentId)
        {
            if (!await _studentRepository.StudentExistsAsync(studentId))
            {
                return NotFound();
            }

            var student = await _studentRepository.GetByIdAsync(studentId);

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
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
                return StatusCode(500, ModelState);
            }

            return Ok("Студент успешно создан!");
        }
    }
}
