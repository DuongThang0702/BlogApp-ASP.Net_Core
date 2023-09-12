using Core.Db;
using Core.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Core.Services
{

    public interface IUser
    {
        public Task<IEnumerable<UserEntity>> GetAll();
    }
    public class UserServices : IUser
    {
        private readonly BlogAppContext _blogAppContext;
        public UserServices(BlogAppContext blogAppContext)
        {
            _blogAppContext = blogAppContext;
        }
        public async Task<IEnumerable<UserEntity>> GetAll()
        {
            return await _blogAppContext.Users.ToListAsync();
            throw new NotImplementedException();
        }
    }
}
