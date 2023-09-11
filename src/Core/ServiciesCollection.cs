using Core.Db;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Core
{
    public static class ServiciesCollection
    {
        public static IServiceCollection ConfigurationServices(this IServiceCollection services, Action<DbContextOptionsBuilder> contextOptionBuilder)
        {
            return services
                .AddDbContextFactory<BlogAppContext>(contextOptionBuilder)
                .AddScoped<IUser, UserServices>();
        }
    }
}