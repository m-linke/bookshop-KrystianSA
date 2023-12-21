using BookShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Context.Configurations
{
    public class AuthorEntityConfiguration : IEntityTypeConfiguration<AuthorEntity>
    {
        protected string Schema { get; set; }

        public AuthorEntityConfiguration(string schema)
        {
            Schema = schema;
        }

        public void Configure(EntityTypeBuilder<AuthorEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Surname)
                .IsRequired()
                .HasMaxLength(100);

            builder.Metadata
               .FindNavigation(nameof(AuthorEntity.Books))
               .SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.HasMany(x => x.Books)
                .WithOne(x => x.Author)
                .HasForeignKey(x => x.AuthorId);
        }
    }
}