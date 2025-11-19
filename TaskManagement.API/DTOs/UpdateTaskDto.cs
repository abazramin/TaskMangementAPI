using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs
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
