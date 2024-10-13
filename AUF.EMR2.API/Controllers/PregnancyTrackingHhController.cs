using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;
using AUF.EMR2.Contracts.Common.Response;
using AUF.EMR2.Contracts.PregnancyTrackingHh.Request;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PregnancyTrackingHhController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PregnancyTrackingHhController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET api/<PregnancyTrackingHhController>/5
    [HttpGet("{householdNo}")]
    public async Task<ActionResult<PregnancyTrackingHhDto>> Get(string householdNo)
    {
        var response = await _mediator.Send(new GetPregnancyTrackingHhRequest { HouseholdNo = householdNo });
        return Ok(response);
    }

    // PUT api/<PregnancyTrackingHhController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Put([FromBody] UpdatePregnancyTrackingHhRequest request)
    {
        var command = _mapper.Map<UpdatePregnancyTrackingHhCommand>(request);
        var response = await _mediator.Send(command);

        return response.Match(
           value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
           errors => Problem(errors));
    }
}
