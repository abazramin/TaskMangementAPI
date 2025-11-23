using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; 
using System.Threading.Tasks;
using TaskManagement.API.Extensions;
using TaskManagement.Application;
using TaskManagement.Domain.DTOs;
using TaskManagement.Infrasturcture;

namespace TaskManagement.API.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]

	public class TaskManagementController : ControllerBase
	{
		private readonly ITaskService _tasks;

		public TaskManagementController(ITaskService tasks)
		{
			_tasks = tasks;
		}

		[Authorize(Roles = "Admin")]
		[HttpGet("tasks")]
		public async Task<IActionResult> GetAllTasks()
		{
		
			var result = await _tasks.GetAllTasks();
			return Ok(result);
		}

		[HttpGet("task")]
		public async Task<IActionResult> GetMyTasks()
		{
			var userId = User.GetUserId();
			var tasks = await _tasks.GetTaskByIdAsync(userId);
			if (tasks == null) { return NotFound(); }

			return Ok(tasks);
		}
		[HttpPost("tasks")]	
		public async Task<IActionResult> CreateTask([FromBody] CreateTaskDto dto)
		{
			var userId = User.GetUserId();
			dto.AssignedToUserId = userId;
			var result = await _tasks.CreateTaskAsync(dto);
			return Ok(result);
		}

		[HttpPut("tasks/{id}")]
		public async Task<IActionResult?> UpdateTask(int id,  [FromBody]  UpdateTaskDto taskItemDto)
		{

			var user_id = User.GetUserId();


			var result = await _tasks.UpdateTaskAsync(id, user_id,taskItemDto);
			

			

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
