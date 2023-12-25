using API.Server.Dto;
using API.Server.Interfaces;
using API.Server.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace API.Server.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GroupController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;

        public GroupController(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }


        [HttpGet("GetAll")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Group>))]
        public async Task<IActionResult> GetGroups()
        {
            var groups = await _groupRepository.GetGroupsAsync();

            var groupsDto = _mapper.Map<List<GroupDto>>(groups);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            return Ok(groupsDto);
        }

        [HttpGet("{groupId}")]
        [ProducesResponseType(200, Type = typeof(Group))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetGroup(int groupId)
        {
            if (!await _groupRepository.GroupExistsAsync(groupId))
            {
                return NotFound();
            }

            var group = await _groupRepository.GetGroupByIdAsync(groupId);

            var groupDto = _mapper.Map<GroupDto>(group);


            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }

            return Ok(groupDto);
        }


        [HttpPost("CreateGroup")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateGroup([FromBody] GroupDto groupDto)
        {
            if (groupDto == null)
            {
                return BadRequest(ModelState);
            }

            ICollection<Group> groups = await _groupRepository.GetGroupsAsync();

            var groupsToCheck = groups.Where(g => g.Number == groupDto.Number ||
                                                 (g.StartOfTraining == groupDto.StartOfTraining &&
                                                  g.EndOfTraining == groupDto.EndOfTraining))
                                      .FirstOrDefault();

            if (groupsToCheck != null)
            {
                ModelState.AddModelError("", "Группа уже существует!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = _mapper.Map<Group>(groupDto);

            if (!await _groupRepository.AddGroupAsync(group))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время создания!");
                return StatusCode(500, ModelState);
            }

            return Ok("Группа успешно создана!");
        }


        [HttpPut("{groupId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> UpdateGroup(int groupId, [FromBody] GroupDto groupDto)
        {
            if (groupDto == null)
            {
                return BadRequest(ModelState);
            }

            if (groupId != groupDto.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var group = _mapper.Map<Group>(groupDto);

            if (!await _groupRepository.UpdateGroupAsync(group))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время обновления информации!");
                return StatusCode(500, ModelState);
            }

            return Ok("Информация о группе успешно обновлена!");
        }


        [HttpDelete("{groupId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            if (!await _groupRepository.GroupExistsAsync(groupId))
            {
                return NotFound();
            }

            var group = await _groupRepository.GetGroupByIdAsync(groupId);

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления группы!");
            }

            if (!await _groupRepository.DeleteGroupAsync(group))
            {
                ModelState.AddModelError("", "Что-то пошло не так во время удаления группы!");
                return StatusCode(500, ModelState);
            }

            return Ok("Группа успешно удалена!");
        }
    }
}
