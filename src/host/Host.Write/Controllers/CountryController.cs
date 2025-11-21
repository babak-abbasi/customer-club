using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Commands.Country;

namespace Host.Write.Controllers;

[ApiController]
[Route("api/v1/country")]
public class CountryController(IMediator _mediator) : ControllerBase
{
    // POST api/v1/country
    [HttpPost]
    public async Task<IActionResult> PostCountry([FromBody] CreateCountryCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if(result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result.Value);
    }
}
