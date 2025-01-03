﻿using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;
using AUF.EMR2.Contracts.Common.Responses;
using AUF.EMR2.Contracts.Households.Responses;
using AUF.EMR2.Contracts.PregnancyTrackingHhs.Requests;
using AUF.EMR2.Contracts.PregnancyTrackingHhs.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/pregnancy-tracking-hhs")]
[ApiController]
public class PregnancyTrackingHhsController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public PregnancyTrackingHhsController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET api/<PregnancyTrackingHhController>/5
    [HttpGet("{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HouseholdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Get(Guid householdId)
    {
        var response = await _mediator.Send(new GetPregnancyTrackingHhQuery(householdId));

        return response.Match(
            value => Ok(_mapper.Map<PregnancyTrackingHhResponse>(value)),
            errors => Problem(errors));
    }

    // PUT api/<PregnancyTrackingHhController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
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
