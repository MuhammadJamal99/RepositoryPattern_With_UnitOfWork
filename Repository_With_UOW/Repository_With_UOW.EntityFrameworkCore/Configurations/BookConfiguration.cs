using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository_With_UOW.Application.contracts.Constants;
using Repository_With_UOW.Application.contracts.Models;

namespace Repository_With_UOW.EntityFrameworkCore.Configurations;
internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable(RepositoryWithUOWDbProperties.DbTablePrefix + ".Book", RepositoryWithUOWDbProperties.DbSchema);

        builder.Property(a => a.Title).IsRequired().HasMaxLength(250);
    }
}
