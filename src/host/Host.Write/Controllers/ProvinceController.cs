using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Commands.Province;

namespace Host.Write.Controllers;

[ApiController]
[Route("api/v1/province")]
public class ProvinceController(IMediator _mediator) : ControllerBase
{
    // POST api/v1/province
    [HttpPost]
    public async Task<IActionResult> PostProvince([FromBody] CreateProvinceCommand command, CancellationToken cancellationToken)
    {
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsFailed)
            return BadRequest(result);

        return Ok(result);
    }
}
