using FluentResults;
using MediatR;

namespace Service.Write.Commands.Country;

public class UpdateCountryCommand : IRequest<Result>
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Code { get; set; }
    public decimal Order { get; set; }
}
