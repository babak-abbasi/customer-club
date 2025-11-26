using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Service.Write.Commands.Country;

public record UpdateCountryCommand([Required]int Id, string Name, string Code, decimal Order) : IRequest<Result>
{
}
