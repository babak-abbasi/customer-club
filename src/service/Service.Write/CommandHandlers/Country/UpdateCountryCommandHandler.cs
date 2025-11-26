using MediatR;
using FluentResults;
using Service.Commands.Country;
using Domain.Repository;
using Service.Write.Commands.Country;
using Helper.ExceptionHandling.Types;
using Service.Write;
using Domain.Write.ExceptionHandling.Types;

namespace Service.CommandHandlers.Country;

public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Result>
{
    private readonly ICountryRepository repo;
    public UpdateCountryCommandHandler(ICountryRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result> Handle(UpdateCountryCommand request, CancellationToken cancellationToken = default)
    {
        try
        {
            var country = await repo.GetByIdAsync(request.Id);

            if (country is null)
                throw new ResponsiveException(ExceptionMessage.WithParameter.NotFound(nameof(Domain.Write.Entities.Country)), new ArgumentNullException(nameof(country)));

            country.Update(request.Code, request.Name, request.Order);

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