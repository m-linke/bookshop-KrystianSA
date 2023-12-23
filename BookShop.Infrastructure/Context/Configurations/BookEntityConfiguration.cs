using BookShop.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookShop.Infrastructure.Context.Configurations
{
    public class BookEntityConfiguration : IEntityTypeConfiguration<BookEntity>
    {
        private readonly string schema;

        public BookEntityConfiguration(string schema)
        {
            this.schema = schema;
        }
        public void Configure(EntityTypeBuilder<BookEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Description)
                .HasMaxLength(500);

            builder.Property(e => e.ReleaseDate)
                .IsRequired();
        }
    }
}
