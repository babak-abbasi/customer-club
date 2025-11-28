using Host.Write.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Commands.Country;
using Service.Write.Commands.Country;
using System.ComponentModel.DataAnnotations;

namespace Host.Write.Controllers;

[ApiController]
[Route("api/v1/country")]
public class CountryController(IMediator _mediator) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> PostCountry([FromBody] CreateCountryCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if(result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }

    [HttpPut()]
    public async Task<IActionResult> PutCountry([Required] int id ,[FromBody] UpdateCountryRequest request, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new UpdateCountryCommand(id, request.Name, request.Code, request.Order), cancellationToken);

        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> PutCountry([Required] int id, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new DeleteCountryCommand(id), cancellationToken);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }
}
