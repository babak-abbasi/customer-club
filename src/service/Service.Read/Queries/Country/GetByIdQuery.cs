using FluentResults;
using MediatR;
using Service.Response.Country;
using System.ComponentModel.DataAnnotations;

namespace Service.Queries.Country;

public class GetByIdQuery: IRequest<Result<CountryDto?>>
{
    [Required]
    public string Id { get; set; }
}