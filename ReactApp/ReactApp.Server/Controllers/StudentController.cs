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


        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _studentRepository.GetStudentsAsync();

            var studentsMapped = _mapper.Map<List<StudentDto>>(students);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(studentsMapped);
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

            var studentMapped = _mapper.Map<StudentDto>(student);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(studentMapped);
        }
    }
}
