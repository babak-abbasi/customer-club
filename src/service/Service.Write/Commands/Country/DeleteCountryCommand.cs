using FluentResults;
using MediatR;

namespace Service.Write.Commands.Country;

public class DeleteCountryCommand : IRequest<Result>
{
    public string Id { get; set; }
}
