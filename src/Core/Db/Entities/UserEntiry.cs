using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Core.Db.Entities
{
    public class UserEntity : BaseEntity
    {
        public string LastName { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string Email { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Avatar { get; set; } = default!;
    }

    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).HasMaxLength(30);
            builder.Property(x => x.FirstName).HasMaxLength(30);
            builder.Property(x => x.Password).HasMaxLength(16).IsRequired();
        }

    }
}
