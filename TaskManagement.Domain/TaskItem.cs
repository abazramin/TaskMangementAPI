using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain
{
	public class TaskItem
	{
		public int Id { get; set; }
		public string Title { get; set; } = null;
		public string? Description { get; set; }
		public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.New;
		public int AssignedToUserId { get; set; }
		public User AssignedTo { get; set; } = null;

		public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

	}
}
