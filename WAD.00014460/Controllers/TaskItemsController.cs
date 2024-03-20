using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WAD._00014460.Data;
using WAD._00014460.DTOs;
using WAD._00014460.Interfaces;
using WAD._00014460.Models;

namespace WAD._00014460.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        private readonly ITaskRepository _taskItemRepository;
        private readonly IMapper _mapper;

        public TaskItemsController(ITaskRepository taskItemRepository, IMapper mapper)
        {
            _taskItemRepository = taskItemRepository;
            _mapper = mapper;
        }

        // GET: api/TaskItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskItemDto>>> GetTaskItems()
        {
            var taskItems = await _taskItemRepository.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<TaskItemDto>>(taskItems));
        }

        // GET: api/TaskItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItemDto>> GetTaskItem(int id)
        {
            var taskItem = await _taskItemRepository.GetByIdAsync(id);

            if (taskItem == null)
            {
                return NotFound();
            }

            return _mapper.Map<TaskItemDto>(taskItem);
        }

        // POST: api/TaskItems
        [HttpPost]
        public async Task<ActionResult<TaskItemDto>> PostTaskItem(TaskItemDto taskItemDto)
        {
            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            await _taskItemRepository.AddAsync(taskItem);

            // Assuming AddAsync now handles SaveChangesAsync
            return CreatedAtAction("GetTaskItem", new { id = taskItem.Id }, _mapper.Map<TaskItemDto>(taskItem));
        }

        // PUT: api/TaskItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskItem(int id, TaskItemDto taskItemDto)
        {
            if (id != taskItemDto.Id)
            {
                return BadRequest();
            }

            var taskItem = _mapper.Map<TaskItem>(taskItemDto);
            await _taskItemRepository.UpdateAsync(taskItem);

            // Assuming UpdateAsync now handles SaveChangesAsync
            return NoContent();
        }

        // DELETE: api/TaskItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskItem(int id)
        {
            await _taskItemRepository.DeleteAsync(id);
            // Assuming DeleteAsync now handles SaveChangesAsync
            return NoContent();
        }
    }
}
