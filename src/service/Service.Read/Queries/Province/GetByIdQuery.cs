using FluentResults;
using MediatR;
using Service.Response.Province;
using System.ComponentModel.DataAnnotations;

namespace Service.Queries.Province;

public class GetByIdQuery : IRequest<Result<ProvinceDto?>>
{
    [Required]
    public string Id { get; set; }
}