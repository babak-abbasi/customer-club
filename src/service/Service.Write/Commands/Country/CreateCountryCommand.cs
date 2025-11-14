using FluentResults;
using MediatR;

namespace Service.Commands.Country;

public record CreateCountryCommand(string Name, string Code) : IRequest<Result<string>>;