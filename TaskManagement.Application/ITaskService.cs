using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.DTOs;
using TaskManagement.Domain;


namespace TaskManagement.Application
{
	public interface ITaskService
	{
		Task<IEnumerable<TaskItem>> GetAllTasks();
		Task<TaskItem> CreateTaskAsync(CreateTaskDto dto);
		Task<TaskItem?> GetTaskByIdAsync(int taskId);
		Task<TaskItem?> UpdateTaskAsync(int taskId, int user_id ,UpdateTaskDto dto);
		Task<bool> DeleteTaskAsync(int taskId);

	}
}
