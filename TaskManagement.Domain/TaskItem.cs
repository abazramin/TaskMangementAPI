using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Enums;

namespace TaskManagement.Domain
{
	public class TaskItem
	{
		public int Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? Description { get; set; } = string.Empty;
		public Enums.TaskStatus Status { get; set; } = Enums.TaskStatus.New;
		[ForeignKey("AssignedTo")]
		public int AssignedToUserId { get; set; }
		public User AssignedTo { get; set; } 
		public DateTime CreatedAt { get; set; } = DateTime.Now;

	}
}
