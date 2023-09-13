using AutoMapper;
using Core.Db;
using Core.Db.Entities;
using Core.Dtos.user;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{

    public interface IUserServices
    {
        public Task<List<GetUserDto>?> GetAll();

        public Task<UserEntity?> FindOneByEmail(string Email);

        public Task<UserEntity?> FindById(long Id);
    }
    public class UserServices : IUserServices
    {
        private readonly BlogAppContext _blogAppContext;
        private readonly IMapper _mapper;
        public UserServices(BlogAppContext blogAppContext, IMapper mapper)
        {
            _blogAppContext = blogAppContext;
            _mapper = mapper;
        }

        public async Task<UserEntity?> FindById(long Id)
        {
            var user = await _blogAppContext.Users.FindAsync(Id);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<UserEntity?> FindOneByEmail(string Email)
        {
            var user = await _blogAppContext.Users.FirstOrDefaultAsync(x => x.Email == Email);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<List<GetUserDto>?> GetAll()
        {
            if (_blogAppContext.Users == null)
            {
                return null;
            }
            var users = await _blogAppContext.Users.ToListAsync();
            return _mapper.Map<List<GetUserDto>>(users);
        }

    }
}
