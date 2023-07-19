using UserCloneApp.Domain.Configurations;
using UserCloneApp.Domain.Repositories;
using UserCloneApp.Domain.Repositories.UserContextRepositories;
using UserCloneApp.Infrastructure.Repositories;
using UserCloneApp.Infrastructure.Repositories.UserContextRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace UserCloneApp.Infrastructure.Extensions.Registrations
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<DatabaseConfiguration>(configuration.GetSection("DatabaseSettings"));
            services.AddSingleton(serviceProvider => serviceProvider.GetRequiredService<IOptions<DatabaseConfiguration>>().Value);

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
