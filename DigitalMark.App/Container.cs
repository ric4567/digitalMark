using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace Biblioteca.Livro.App
{
    public static class Container
    {
        public static IServiceCollection AddUsuarioServices(this IServiceCollection services)
        {
            //Repositorios
            services.AddScoped<ILivroRepository, LivroRepository>();
          
            //Handlers
            services.AddScoped<IEditoraHandler, EditoraHandler>();

            services.AddDbContext<LivroContext>(ServiceLifetime.Scoped);

            return services;
        }

    }
}
