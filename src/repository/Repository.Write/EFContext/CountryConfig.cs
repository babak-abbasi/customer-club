using Domain.Write.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Write.EFContext;

public class CountryConfig : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ConfigureAggregateRoot<int, Country>();

        builder.HasMany(p => p.Provinces);
    }
}
