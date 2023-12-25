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
    public class PracticalExamController : Controller
    {
        private readonly IPracticalExamRepository _practicalExamRepository;
        private readonly IMapper _mapper;

        public PracticalExamController(IPracticalExamRepository practicalExamRepository, IMapper mapper)
        {
            _practicalExamRepository = practicalExamRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TheoryExam>))]
        public async Task<IActionResult> GetPracticalExams()
        {
            var practicalExams = await _practicalExamRepository.GetPracticalExamsAsync();

            var practicalExamsMapped = _mapper.Map<List<PracticalExamDto>>(practicalExams);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(practicalExamsMapped);
        }

        [HttpGet("{practicalExamId}")]
        [ProducesResponseType(200, Type = typeof(TheoryExam))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPracticalExam(int practicalExamId)
        {
            if (!await _practicalExamRepository.PracticalExamExistsAsync(practicalExamId))
            {
                return NotFound();
            }

            var practicalExam = await _practicalExamRepository.GetPracticalExamByIdAsync(practicalExamId);

            var practicalExamMapped = _mapper.Map<PracticalExamDto>(practicalExam);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(practicalExamMapped);
        }


        [HttpPost("CreatePracticalExam")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateParcticalExam([FromBody] PracticalExamDto examDto)
        {
            if (examDto == null)
            {
                BadRequest(ModelState);
            }

            ICollection<PracticalExam> exams = await _practicalExamRepository.GetPracticalExamsAsync();

            var examsCheck = exams.Where(e => e.Date == examDto.Date).FirstOrDefault();

            if (examsCheck != null)
            {
                ModelState.AddModelError("", "Экзамен на эту дату уже существует!");
                return StatusCode(244, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exam = _mapper.Map<PracticalExam>(examDto);

            if (!await _practicalExamRepository.AddPracticalExamAsync(exam))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания экзамена!");
            }

            return Ok("Экзамен успешно создан!");
        }


        [HttpPut("{practicalExamId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateGroup(int practicalExamId, [FromBody] PracticalExamDto practicalExamDto)
        {
            if (practicalExamDto == null)
            {
                return BadRequest(ModelState);
            }

            if (practicalExamId != practicalExamDto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var practicalExam = _mapper.Map<PracticalExam>(practicalExamDto);

            if (!await _practicalExamRepository.UpdatePracticalExamAsync(practicalExam))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время обновления информации об экзамене!");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


        [HttpDelete("{practicalExamId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeletePracticalExam(int practicalExamId)
        {
            if (!await _practicalExamRepository.PracticalExamExistsAsync(practicalExamId))
            {
                return NotFound();
            }

            var practicalExam = await _practicalExamRepository.GetPracticalExamByIdAsync(practicalExamId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await _practicalExamRepository.DeletePracticalExamAsync(practicalExam))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления экзамена!");
                return StatusCode(500, ModelState);
            }

            return Ok("Экзамен успешно удален!");
        }
    }
}
