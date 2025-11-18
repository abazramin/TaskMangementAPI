using Microsoft.EntityFrameworkCore;
using TaskManagement.Domain;

namespace TaskManagement.Infrasturcture
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}

		public DbSet<User> Users { get; set; }
		public DbSet<TaskItem> TaskItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
				.HasMany(u => u.Tasks)
				.WithOne(t=>t.AssignedTo)
				.HasForeignKey(t=>t.AssignedToUserId);

			base.OnModelCreating(modelBuilder);
		}

	}
}
