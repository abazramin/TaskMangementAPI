using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.DTOs
{
	public class UpdateTaskDto
	{
		[Required]
		[MinLength(3)]
		public string? Title { get; set; }
		[MaxLength(300)]
		public string? Description { get; set; }
	}
}
