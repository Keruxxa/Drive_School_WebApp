﻿using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TheoryExamController : Controller
    {
        private readonly ITheoryExamRepository _theoryExamRepository;
        private readonly IMapper _mapper;

        public TheoryExamController(ITheoryExamRepository theoryExamRepository, IMapper mapper)
        {
            _theoryExamRepository = theoryExamRepository;
            _mapper = mapper;
        }



        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<TheoryExam>))]
        public async Task<IActionResult> GetPracticalExams()
        {
            var theoryExams = await _theoryExamRepository.GetTheoryExamsAsync();

            var theoryExamsMapped = _mapper.Map<List<TheoryExamDto>>(theoryExams);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(theoryExamsMapped);
        }

        [HttpGet("{theoryExamId}")]
        [ProducesResponseType(200, Type = typeof(TheoryExam))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPracticalExam(int theoryExamId)
        {
            if (!await _theoryExamRepository.TheoryExamExistsAsync(theoryExamId))
            {
                return NotFound();
            }

            var theoryExam = await _theoryExamRepository.GetByIdAsync(theoryExamId);

            var theoryExamMapped = _mapper.Map<TheoryExamDto>(theoryExam);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(theoryExamMapped);
        }


        [HttpPost("CreateTheoryExam")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateTheoryExam([FromBody] TheoryExamDto examDto)
        {
            if (examDto == null)
            {
                BadRequest(ModelState);
            }

            ICollection<TheoryExam> exams = await _theoryExamRepository.GetTheoryExamsAsync();

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

            var exam = _mapper.Map<TheoryExam>(examDto);

            if (!await _theoryExamRepository.AddTheoryExamAsync(exam))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
            }

            return Ok("Экзамен успешно создан!");
        }
    }
}
