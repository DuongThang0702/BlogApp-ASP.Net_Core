using AutoMapper;
using Core.Db;
using Core.Db.Entities;
using Core.Dtos.auth;
using Microsoft.EntityFrameworkCore;
namespace Core.Services
{
    public interface IAuthServices
    {
        public Task<int> Register(RegisterDto payload);

        public Task<int> Login();
    }
    public class AuthServices : IAuthServices
    {
        private readonly BlogAppContext _blogAppContext;
        private readonly IMapper _mapper;
        public AuthServices(BlogAppContext blogAppContext, IMapper mapper)
        {
            _blogAppContext = blogAppContext;
            _mapper = mapper;

        }
        public async Task<int> Register(RegisterDto payload)
        {
            var newUser = _mapper.Map<UserEntity>(payload);
            _blogAppContext.Add(newUser);
            return await _blogAppContext.SaveChangesAsync();
        }

        public Task<int> Login()
        {
            throw new NotImplementedException();
        }
    }
}
