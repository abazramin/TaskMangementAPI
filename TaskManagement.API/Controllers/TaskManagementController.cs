using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Application;
using TaskManagement.Domain.DTOs;
using TaskManagement.Infrasturcture;

namespace TaskManagement.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaskManagementController : ControllerBase
	{
		private readonly ITaskService _tasks;

		public TaskManagementController(ITaskService tasks)
		{
			_tasks = tasks;
		}


		[HttpGet("tasks")]
		public async Task<IActionResult> GetAllTasks()
		{
			var result = await _tasks.GetAllTasks();
			return Ok(result);
		}

		[HttpGet("tasks/{id}")]
		public async Task<IActionResult> GetTaskById(int id)
		{
			var result = await _tasks.GetTaskByIdAsync(id);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpPost("tasks")]	
		public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto taskItem)
		{
			var result = await _tasks.CreateTaskAsync(taskItem);
			return Ok(result);
		}

		[HttpPut("tasks/{id}")]
		public async Task<IActionResult> UpdateTask(int id, [FromBody] UpdateTaskDto taskItemDto)
		{
			var result = await _tasks.UpdateTaskAsync(id, taskItemDto);
			if (result == null)
			{
				return NotFound();
			}
			return Ok(result);
		}

		[HttpDelete("tasks/{id}")]
		public async Task<IActionResult> DeleteTask(int id)
		{
			var taskItem = await _tasks.DeleteTaskAsync(id);
			if (!taskItem)
			{
				return NotFound();
			}
			return NoContent();
		}
	}
}
