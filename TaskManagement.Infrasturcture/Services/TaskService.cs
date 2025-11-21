using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain;

namespace TaskManagement.Infrasturcture.Services
{
	public class TaskService : ITaskService
	{
		private readonly AppDbContext _context;
		public TaskService(AppDbContext context)
		{
			_context = context;
		}


		public async Task<List<TaskItem>> GetAllTasks()
		{
			return await _context.TaskItems.ToListAsync();
		}

		public async Task<TaskItem> CreateTaskAsync(CreateTaskDto dto)
		{
			
			var task = new TaskItem
			{
				Title = dto.Title,
				Description = dto.Description,
				Status = dto.Status,
				AssignedToUserId = dto.AssignedToUserId,
				CreatedAt = DateTime.Now,
			};
			_context.TaskItems.Add(task);
			await _context.SaveChangesAsync();
			return task;
		}

		public async Task<bool> DeleteTaskAsync(int taskId)
		{
			var task = await _context.TaskItems.FindAsync(taskId);
			if (task == null) return false;
			_context.TaskItems.Remove(task);
			await _context.SaveChangesAsync();
			return true;
		}

		public async Task<TaskItem?> GetTaskByIdAsync(int taskId)
		{
			return await _context.TaskItems.FindAsync(taskId);
		}

		public async Task<TaskItem?> UpdateTaskAsync(int taskId, UpdateTaskDto dto)
		{
			var task = await _context.TaskItems.FirstOrDefaultAsync(x => x.Id == taskId);
			if (task != null)
			{
				task.Title = dto.Title;
				task.Description = dto.Description;
				await _context.SaveChangesAsync();
				return task;
			}
			return null;
		}
	}
}
