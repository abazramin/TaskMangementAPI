using System.Security.Claims;

namespace TaskManagement.API.Extensions
{
	public static class ClaimsExtensions
	{
		public static int GetUserId(this ClaimsPrincipal user)
		{
			return int.Parse(user.FindFirstValue(ClaimTypes.NameIdentifier));
		}
	}
}
