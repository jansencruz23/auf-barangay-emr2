using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberListByHouseholdNo;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList;
using AUF.EMR2.Contracts.Common.Responses;
using AUF.EMR2.Contracts.HouseholdMembers.Requests;
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
    [HttpGet("household/{householdNo}")]
    public async Task<ActionResult<List<HouseholdMemberDto>>> GetHouseholdMembers(string householdNo)
    {
        var response = await _mediator.Send(new GetHouseholdMemberListByHouseholdNoRequest { HouseholdNo = householdNo });
        return Ok(response);
    }

    // GET: api/<HouseholdMemberController>/wra/householdNo
    [HttpGet("wra/{householdNo}")]
    public async Task<ActionResult<List<HouseholdMemberDto>>> GetWraHouseholdMembers(string householdNo)
    {
        var response = await _mediator.Send(new GetWraHouseholdMemberListRequest { HouseholdNo = householdNo });
        return Ok(response);
    }

    // GET api/<HouseholdMemberController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HouseholdMemberDto>> Get(Guid id)
    {
        var response = await _mediator.Send(new GetHouseholdMemberRequest { Id = id });
        return Ok(response);
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
    [HttpPut("{id}")]
    public async Task<ActionResult<CommandResponse<Guid>>> Put([FromBody] UpdateHouseholdMemberDto dto)
    {
        var response = await _mediator.Send(new UpdateHouseholdMemberCommand { HouseholdMemberDto = dto });
        return Ok(response);
    }

    // DELETE api/<HouseholdMemberController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult<CommandResponse<Guid>>> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteHouseholdMemberCommand { Id = id });
        return Ok(response);
    }
}
