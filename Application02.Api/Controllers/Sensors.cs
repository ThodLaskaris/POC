using Application02.Application;
using Application02.Application.Query;
using Application02.Contracts;
using Application02.Contracts.Commands;
using Application02.Contracts.Query;
using Application02.Domain;
using Microsoft.AspNetCore.Mvc;

namespace Application02.Controllers;

[ApiController]
[Route("[controller]")]
public class SensorController(PostSensorHandler postHandler, GetSensorHandler getHandler): ControllerBase
{
    [HttpPost]
    [Route("/api/sensor-data")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] SensorStatusCommand request, CancellationToken cancellationToken)
    {
        var result = await postHandler.Add(request, cancellationToken);
        return Ok(result);
    }
    
    [HttpGet]
    [Route("/api/sensor-data")]
    [ProducesResponseType(typeof(IEnumerable<SensorStatusQuery>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await getHandler.GetAll(cancellationToken);
        return Ok(result);
    }
}