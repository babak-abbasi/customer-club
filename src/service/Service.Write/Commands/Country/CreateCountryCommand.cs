using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Service.Commands.Country;

public record CreateCountryCommand([Required]string Name, [Required]string Code, [Required]decimal Order) : IRequest<Result<string>>;