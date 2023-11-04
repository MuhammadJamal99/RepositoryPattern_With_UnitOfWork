using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository_With_UOW.Application.contracts.Constants;
using Repository_With_UOW.Application.contracts.Models;

namespace Repository_With_UOW.EntityFrameworkCore.Configurations;
internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(RepositoryWithUOWDbProperties.DbTablePrefix + ".Author", RepositoryWithUOWDbProperties.DbSchema);

        builder.Property(a => a.Name).IsRequired().HasMaxLength(250);
    }
}
