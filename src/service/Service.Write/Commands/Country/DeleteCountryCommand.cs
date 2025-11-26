using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Service.Write.Commands.Country;

public record DeleteCountryCommand([Required]int Id) : IRequest<Result>
{
}
