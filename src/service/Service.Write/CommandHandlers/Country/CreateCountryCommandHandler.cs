using MediatR;
using FluentResults;
using Service.Commands.Country;

namespace Service.CommandHandlers.Country;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        int newCountryId = 1;

        return Result.Ok(newCountryId);
    }
}