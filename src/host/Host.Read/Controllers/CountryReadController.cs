using FluentResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Queries.Country;
using Service.Response.Country;

namespace Host.Read;

[ApiController]
[Route("api/v1/country")]
public class CountryController(IMediator _mediator) : ControllerBase
{
    /// <summary>
    /// Finds a country by it's Id
    /// </summary>
    /// <param name="id">The Id of the country</param>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(Result<CountryDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetByIdAsync([FromQuery] GetByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(query, cancellationToken);

        if(result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }

    /// <summary>
    /// Finds countries by name or code
    /// </summary>
    /// <param name="code">The Code of the country</param>
    /// <param name="name">The Name of the country</param>
    /// <returns></returns>
    [HttpGet("countries")]
    [ProducesResponseType(typeof(Result<List<CountryDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllAsync(CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(new GetAllQuery(), cancellationToken);

        if (result.IsFailed)
            return BadRequest(result.Errors);

        return Ok(result);
    }
}