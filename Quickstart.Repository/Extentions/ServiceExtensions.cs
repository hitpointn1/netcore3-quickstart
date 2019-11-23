using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quickstart.Repository.Context;

namespace Quickstart.Repository.Extentions
{
    public static partial class ServiceExtensions
    {
        public static void ConfigurePostgreContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["postgresql:connectionString"];
            services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(connectionString));
        }
        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
