using Domain.Write;
using Helper.Database.Postgres;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Repository.Write.EFContext;

public static class AggregateRootConfigurationExtensions
{
    public static void ConfigureAggregateRoot<TId, TRoot>(this EntityTypeBuilder<TRoot> builder) 
        where TId : struct 
        where TRoot : AggregateRoot<TId>
    {
        builder.Property(p => p.Id).HasColumnType(PostgresDataTypes.Int).UseIdentityColumn().IsRequired();
        builder.Property(p => p.Order).HasColumnType(PostgresDataTypes.Decimal3230);
        builder.Property(p => p.IsDeleted).HasColumnType(PostgresDataTypes.Bool);
        builder.Property(p => p.IsActive).HasColumnType(PostgresDataTypes.Bool);
        builder.Property(p => p.CreatedDate).HasColumnType(PostgresDataTypes.TimeStampWithZone);
        builder.Property(p => p.UpdatedDate).HasColumnType(PostgresDataTypes.TimeStampWithZone);
        builder.Property(p => p.Name).HasColumnType(PostgresDataTypes.Varchar64);
        builder.Property(p => p.Code).HasColumnType(PostgresDataTypes.Varchar64);
    }
}
