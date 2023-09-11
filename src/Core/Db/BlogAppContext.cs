using Core.Db.Entities;
using Microsoft.EntityFrameworkCore;
namespace Core.Db
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext(DbContextOptions<BlogAppContext> options) : base(options)
        {

        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}
