using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.DTOs
{
	public class CreateTaskDto
	{
		[Required]
		[MinLength(3)]
		public string Title { get; set; } = null;
		[MaxLength(300)]

		public string? Description { get; set; }
		[Required]
		public Domain.Enums.TaskStatus Status { get; set; } = Domain.Enums.TaskStatus.New;
		public int AssignedToUserId { get; set; }
	}
}
