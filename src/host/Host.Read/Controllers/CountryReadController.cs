using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Queries.Country;

namespace Host.Read;

[ApiController]
[Route("api/v1/[controller]")]
public class CountryController(IMediator _mediator) : ControllerBase
{
    // POST api/v1/country
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if(result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }

    // POST api/v1/countries
    [HttpGet("countries")]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllQuery(), cancellationToken);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}