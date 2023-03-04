using DigitalMark.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace DigitalMark.App
{
    public static class Container
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddDbContext<DigitalMarkContext>(ServiceLifetime.Scoped);

            return services;
        }

    }
}
