using Domain.Write.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Write.EFContext;

public class ProvinceConfig : IEntityTypeConfiguration<Province>
{
    public void Configure(EntityTypeBuilder<Province> builder)
    {
        builder.ConfigureAggregateRoot<int, Province>();

        builder.HasOne(c => c.Country);
    }
}
