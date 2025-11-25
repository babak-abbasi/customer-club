using Domain.Repository;
using Domain.Write.ExceptionHandling.Types;
using FluentResults;
using Helper.ExceptionHandling.Types;
using MediatR;
using Service.Write;
using Service.Write.Commands.Country;

namespace Service.CommandHandlers.Country;

public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Result>
{
    private readonly ICountryRepository repo;
    public DeleteCountryCommandHandler(ICountryRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result> Handle(DeleteCountryCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var country = await repo.GetByIdAsync<Domain.Write.Entities.Country>(request.Id);

            if (country is null)
                throw new ResponsiveException(ExceptionMessage.WithParameter.NotFound(nameof(Domain.Write.Entities.Country)), new ArgumentNullException(nameof(country)));

            country.Delete();

            await repo.UpdateAsync(request.Id, country);

            return Result.Ok();
        }
        catch (DomainResponsiveException exception)
        {
            throw new ResponsiveException(exception.Message);
        }
        catch (DomainLoggableException exception)
        {
            throw new LoggableException(exception.Message, exception.LoggableMessage);
        }
        catch (Exception)
        {
            throw;
        }
    }
}