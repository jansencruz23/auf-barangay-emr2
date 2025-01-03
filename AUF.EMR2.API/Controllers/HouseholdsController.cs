using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;
using AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;
using AUF.EMR2.Contracts.Common.Responses;
using AUF.EMR2.Contracts.Households.Requests;
using AUF.EMR2.Contracts.Households.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/households")]
public class HouseholdsController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public HouseholdsController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: api/<HouseholdController>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiPagedResponse<HouseholdResponse>))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Get([FromQuery] RequestParams requestParams, string query = null!)
    {
        var response = await _mediator.Send(new GetHouseholdListQuery(requestParams, query));

        return response.Match(
            value => Ok(_mapper.Map<ApiPagedResponse<HouseholdResponse>>(value)),
            errors => Problem(errors));
    }

    // GET api/<HouseholdController>/5
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HouseholdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _mediator.Send(new GetHouseholdQuery(id));

        return response.Match(
            value => Ok(_mapper.Map<HouseholdResponse>(value)),
            errors => Problem(errors));
    }

    // GET api/<HouseholdController>/household-no/householdNo
    [HttpGet("household-no/{householdNo}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HouseholdResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetByHouseholdNo(string householdNo)
    {
        var response = await _mediator.Send(new GetHouseholdByHouseholdNoQuery(householdNo));

        return response.Match(
           value => Ok(_mapper.Map<HouseholdResponse>(value)),
           errors => Problem(errors));
    }

    // POST api/<HouseholdController>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Post([FromBody] CreateHouseholdRequest request)
    {
        var command = _mapper.Map<CreateHouseholdCommand>(request);
        var response = await _mediator.Send(command);

        return response.Match(
            value => Ok(_mapper.Map<ApiResponse<Guid>>(value)), 
            errors => Problem(errors));
    }

    // PUT api/<HouseholdController>/5
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Put([FromBody] UpdateHouseholdRequest request)
    {
        var command = _mapper.Map<UpdateHouseholdCommand>(request);
        var response = await _mediator.Send(command);

        return response.Match(
           value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
           errors => Problem(errors));
    }

    // DELETE api/<HouseholdController>/5
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _mediator.Send(new DeleteHouseholdCommand(id));

        return response.Match(
           value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
           errors => Problem(errors));
    }
}
