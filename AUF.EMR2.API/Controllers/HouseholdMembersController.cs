using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberList;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList;
using AUF.EMR2.Contracts.Common.Responses;
using AUF.EMR2.Contracts.HouseholdMembers.Requests;
using AUF.EMR2.Contracts.HouseholdMembers.Responses;
using AUF.EMR2.Contracts.Households.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HouseholdMembersController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public HouseholdMembersController(
        IMediator mediator, 
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: api/<HouseholdMemberController>/household/householdNo
    [HttpGet("households/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HouseholdMemberResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetHouseholdMembers(Guid householdId)
    {
        var response = await _mediator.Send(new GetHouseholdMemberListQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<HouseholdMemberResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<HouseholdMemberController>/wra/householdNo
    [HttpGet("wras/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<HouseholdMemberResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetWraHouseholdMembers(Guid householdId)
    {
        var response = await _mediator.Send(new GetWraHouseholdMemberListQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<HouseholdMemberResponse>>(value)),
            error => Problem(error));
    }

    // GET api/<HouseholdMemberController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HouseholdMemberResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _mediator.Send(new GetHouseholdMemberQuery(id));
        return response.Match(
            value => Ok(_mapper.Map<HouseholdMemberResponse>(value)),
            error => Problem(error));
    }

    // POST api/<HouseholdMemberController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Post([FromBody] CreateHouseholdMemberRequest request)
    {
        var command = _mapper.Map<CreateHouseholdMemberCommand>(request);
        var response = await _mediator.Send(command);
        return response.Match(
            value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
            error => Problem(error));
    }

    // PUT api/<HouseholdMemberController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Put([FromBody] UpdateHouseholdMemberRequest request)
    {
        var command = _mapper.Map<UpdateHouseholdMemberCommand>(request);
        var response = await _mediator.Send(command);
        return response.Match(
            value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
            error => Problem(error));
    }

    // DELETE api/<HouseholdMemberController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<CommandResponse<Guid>>> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteHouseholdMemberCommand { Id = id });
        return Ok(response);
    }
}
