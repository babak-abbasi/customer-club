using Domain.Write;
using Domain.Write.Repository;
using Helper.ExceptionHandling.Types;
using Repository.Write.EFContext;

namespace Repository.Write;

public abstract class BaseRepository<TId, T>(EFDBContext eFDBContext) 
    : IBaseRepository<TId, T> 
    where TId : struct 
    where T : AggregateRoot<TId>
{
    public virtual async Task<TId> AddAsync(T input, CancellationToken cancellationToken = default)
    {
        try
        {
            await eFDBContext.Set<T>().AddAsync(input);

            var result = await eFDBContext.SaveChangesAsync();

            return input.Id;
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Create_Failure, ExceptionMessage.WithParameter.ElasticSearch_Create_Failure(exception.Message), exception);
        }
    }

    public virtual async Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await eFDBContext.Set<T>().FindAsync(id);

            return result;
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Read_Failure, ExceptionMessage.WithParameter.ElasticSearch_Read_Failure(exception.Message), exception);
        }
    }

    public virtual async Task UpdateAsync(TId id, T entity, CancellationToken cancellationToken = default)
    {
        try
        {
            eFDBContext.Set<T>().Update(entity);

            await eFDBContext.SaveChangesAsync();
        }
        catch (Exception exception)
        {
            throw new LoggableException(ExceptionMessage.NoParameter.Data_Update_Failure, ExceptionMessage.WithParameter.ElasticSearch_Update_Failure(exception.Message), exception);
        }
    }
}