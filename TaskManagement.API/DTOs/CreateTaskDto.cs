using System.ComponentModel.DataAnnotations;

namespace TaskManagement.API.DTOs
{
	public class CreateTaskDto
	{
		[Required]
		[MinLength(3)]
		public string Title { get; set; } = null!;
		[MaxLength(300)]
		public string? Description { get; set; }
		
	}
}
