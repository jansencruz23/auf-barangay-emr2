using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;
using AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay;
using AUF.EMR2.Contracts.Barangays.Requests;
using AUF.EMR2.Contracts.Barangays.Responses;
using AUF.EMR2.Contracts.Common.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/barangays")]
public class BarangaysController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BarangaysController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: api/<BarangayController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BarangayResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Get()
    {
        var response = await _mediator.Send(new GetBarangayQuery());
        return response.Match(
            value => Ok(_mapper.Map<BarangayResponse>(value)),
            error => Problem(error));
    }

    // PUT api/<BarangayController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Put([FromBody] UpdateBarangayRequest request)
    {
        var command = _mapper.Map<UpdateBarangayCommand>(request);
        var response = await _mediator.Send(command);

        return response.Match(
           value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
           errors => Problem(errors));
    }
}
