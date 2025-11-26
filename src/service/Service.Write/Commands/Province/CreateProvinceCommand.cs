using FluentResults;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Service.Commands.Province;

public record CreateProvinceCommand([Required] string Name, [Required] string Code, [Required] decimal Order, [Required] int CountryId) : IRequest<Result<int>>;