using DigitalMark.Contexts;
using DigitalMark.Domain.Handlers;
using DigitalMark.Domain.Interfaces;
using DigitalMark.Domain.Interfaces.Handlers;
using DigitalMark.Domain.Interfaces.Repositories;
using DigitalMark.Infra.Data;
using DigitalMark.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DigitalMark.App
{
    public static class Container
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection services)
        {
            services.AddScoped<IProjectHandler, ProjectHandler>();
            services.AddScoped<IClientHandler, ClientHandler>();

            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddDbContext<DigitalMarkContext>(ServiceLifetime.Scoped);

            return services;
        }
    }
}