using MediatR;
using FluentResults;
using Service.Commands.Country;
using Repository.Write;

namespace Service.CommandHandlers.Country;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<string>>
{
    public async Task<Result<string>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        Repository.Write.CountryRepository repo = new();
        var result = await repo.AddCountryAsync(request.Name, request.Code);

        return Result.Ok(result);
    }
}