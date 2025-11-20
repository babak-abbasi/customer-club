using MediatR;
using FluentResults;
using Service.Commands.Country;
using Domain.Repository;

namespace Service.CommandHandlers.Country;

public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Result<string>>
{
    private readonly ICountryRepository repo;
    public CreateCountryCommandHandler(ICountryRepository repo)
    {
        this.repo = repo;
    }
    public async Task<Result<string>> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var result = await repo.AddCountryAsync(request.Name, request.Code, request.Order);

        return Result.Ok(result);
    }
}