using Core.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Db
{
    public class BlogAppContext : DbContext
    {
        public BlogAppContext(DbContextOptions<BlogAppContext> options)
            : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public override int SaveChanges()
        {
            AddTimestamps();
            return base.SaveChanges();
        }

        //public override async Task<int> SaveChangesAsync()
        //{
        //    AddTimestamps();
        //    return await base.SaveChangesAsync();
        //}

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            AddTimestamps();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void AddTimestamps()
        {
            var entities = ChangeTracker
                .Entries()
                .Where(
                    x =>
                        x.Entity is BaseEntity
                        && (x.State == EntityState.Added || x.State == EntityState.Modified)
                );

            foreach (var entity in entities)
            {
                var now = DateTime.UtcNow;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity)entity.Entity).CreatedAt = now;
                }
                ((BaseEntity)entity.Entity).UpdatedAt = now;
            }
        }
    }
}
