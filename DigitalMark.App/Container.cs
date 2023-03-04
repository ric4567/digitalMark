using Biblioteca.Livro.Infra.Data.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Biblioteca.Livro.App
{
    public static class Container
    {
        public static IServiceCollection AddUsuarioServices(this IServiceCollection services)
        {
            services.AddDbContext<DigitalMarkContext>(ServiceLifetime.Scoped);

            return services;
        }

    }
}
