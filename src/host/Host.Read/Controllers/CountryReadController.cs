using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Queries.Country;

namespace Host.Read;

[ApiController]
[Route("api/v1/[controller]")]
public class CountryReadController(IMediator _mediator) : ControllerBase
{
    // POST api/v1/country
    [HttpGet]
    public async Task<IActionResult> GetCountry([FromQuery] GetByIdCountryQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if(result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}