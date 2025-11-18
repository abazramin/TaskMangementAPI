namespace TaskManagement.Domain
{
	public class User
	{
		public int id { get; set; }
		public string name { get; set; } = null;
		public string email { get; set; } = null;
		public string passwordHash { get; set; } = null;
		public string Role { get; set; } = "Members";
		public ICollection<TaskItem> Tasks { get; set; } = new List<TaskItem>();
	}
}
