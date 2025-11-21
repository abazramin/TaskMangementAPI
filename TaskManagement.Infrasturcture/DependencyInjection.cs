using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Infrasturcture
{
	public static class DependencyInjection
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
		{
			services.AddDbContext<AppDbContext>(options =>
				options.UseSqlServer(config.GetConnectionString("cs")));

			return services;
		}
	}
}
