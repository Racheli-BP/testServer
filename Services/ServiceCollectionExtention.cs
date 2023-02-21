using Microsoft.Extensions.DependencyInjection;
using Services.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testServer;

namespace Services
{
	public static class ServiceCollectionExtention
	{
		public static IServiceCollection AddService(this IServiceCollection services)
		{
            services.AddScoped<IPerson, PersonService>();

			services.AddAutoMapper(typeof(MappingProfile));
			return services;
		}
	}
}
