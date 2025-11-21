using TaskManagement.Domain;

namespace TaskManagement.Application
{
	public interface IJwtService
	{	
			string GenerateToken(User user);	
	}
}
