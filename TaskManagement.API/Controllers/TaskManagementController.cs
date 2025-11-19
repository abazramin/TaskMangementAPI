using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Infrasturcture;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using TaskManagement.Domain;
using TaskManagement.API.DTOs;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskManagementController : ControllerBase
	{
		private AppDbContext _context;
		public TaskManagementController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet("tasks")]
		public async Task<IActionResult> GetTasks() // Fix: Change Tasks<> to Task<>
		{
			var tasks = await _context.TaskItems.ToListAsync(); // Fix: Use await and ToListAsync()
			return Ok(tasks);
		}

		[HttpGet("tasks/{id}")]
		public async Task<IActionResult> GetTaskById(int id)
		{
			var taskItem = await _context.TaskItems.FindAsync(id);
			if (taskItem == null)
			{
				return NotFound();
			}
			return Ok(taskItem);
		}

		[HttpPost("tasks")]
		public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto taskItem)
		{
			if(!ModelState.IsValid) return BadRequest(ModelState);

			var task = new TaskItem
			{
				Title = taskItem.Title,
				Description = taskItem.Description
			};

			_context.TaskItems.Add(task);
			await _context.SaveChangesAsync(); 
			return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
		}

		[HttpPut("tasks/{id}")]
		public async Task<IActionResult> UpdateTask(int id, [FromBody] CreateTaskDto taskItemDto)
		{
			if (!ModelState.IsValid) return BadRequest(ModelState);

			var taskItem = await _context.TaskItems.FindAsync(id);

			if (taskItem == null)
			{
				return NotFound();
			}

			taskItem.Title = taskItemDto.Title;
			taskItem.Description = taskItemDto.Description;

			await _context.SaveChangesAsync();
			return Ok(taskItem);
		}

		[HttpDelete("tasks/{id}")]
		public async Task<IActionResult> DeleteTask(int id)
		{
			var taskItem = await _context.TaskItems.FindAsync(id);
			if (taskItem == null)
			{
				return NotFound();
			}
			_context.TaskItems.Remove(taskItem);
			await _context.SaveChangesAsync(); 
			return NoContent();
		}


	}
}
