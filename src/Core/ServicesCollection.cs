using AutoMapper;
using Core.Db;
using Core.Db.Entities;
using Core.Dtos.auth;
using Core.Dtos.user;
using Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class ServicesCollection
    {
        public static IServiceCollection ConfigurationServices(this IServiceCollection services, Action<DbContextOptionsBuilder> contextOptionBuilder)
        {

            return services
                .AddAutoMapper(Assembly.GetExecutingAssembly())
                .AddDbContextFactory<BlogAppContext>(contextOptionBuilder)
                .AddScoped<IUserServices, UserServices>()
                .AddScoped<IAuthServices, AuthServices>();
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RegisterDto, UserEntity>();
            CreateMap<GetUserDto, UserEntity>();
        }
    }
}