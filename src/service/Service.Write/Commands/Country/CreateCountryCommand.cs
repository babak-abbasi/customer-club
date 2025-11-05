using FluentResults;

namespace Service.Commands.Country;

public record CreateCountryCommand(string Name, string Code) : MediatR.IRequest<Result<int>>;