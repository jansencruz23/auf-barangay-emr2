using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Masterlist;
using AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult;
using AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistChild;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdolescent;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdultRecord;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistChildRecord;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistNewborn;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSchoolAged;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSenior;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistUnderFive;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetPrintMasterlistRecordList;
using AUF.EMR2.Contracts.Common.Responses;
using AUF.EMR2.Contracts.Masterlist.Requests;
using AUF.EMR2.Contracts.Masterlist.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MasterlistController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public MasterlistController(
        ISender mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    // GET: api/<MasterlistController>/newborns/householdId
    [HttpGet("newborns/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistChildResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetNewborns(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistNewbornQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistChildResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/infants/householdId
    [HttpGet("infants/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistChildResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetInfants(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistInfantQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistChildResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/under-five/householdNo
    [HttpGet("under-five/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistChildResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetUnderFiveChildren(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistUnderFiveQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistChildResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/school-aged/householdNo
    [HttpGet("school-aged/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistChildResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetSchoolAgedChildren(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistSchoolAgedQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistChildResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/adolescents/householdNo
    [HttpGet("adolescents/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistChildResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAdolescents(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistAdolescentQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistChildResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/adults/householdNo
    [HttpGet("adults/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistAdultResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAdults(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistAdultQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistAdultResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/seniors/householdNo
    [HttpGet("seniors/{householdId}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<MasterlistAdultResponse>))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetSeniors(Guid householdId)
    {
        var response = await _mediator.Send(new GetMasterlistSeniorQuery(householdId));
        return response.Match(
            value => Ok(_mapper.Map<List<MasterlistAdultResponse>>(value)),
            error => Problem(error));
    }

    // GET: api/<MasterlistController>/print/householdNo
    [HttpGet("print/{householdNo}")]
    public async Task<ActionResult<PrintMasterlistRecordsDto>> GetPrintMasterlistRecords(string householdNo)
    {
        var response = await _mediator.Send(new GetPrintMasterlistRecordListRequest { HouseholdNo = householdNo });
        return Ok(response);
    }

    // GET api/<MasterlistController>/child/5
    [HttpGet("child/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MasterlistChildResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetChildRecord(Guid id)
    {
        var response = await _mediator.Send(new GetMasterlistChildRecordQuery(id));
        return response.Match(
            value => Ok(_mapper.Map<MasterlistChildResponse>(value)),
            error => Problem(error));
    }

    // GET api/<MasterlistController>/adult/5
    [HttpGet("adult/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MasterlistAdultResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> GetAdultRecord(Guid id)
    {
        var response = await _mediator.Send(new GetMasterlistAdultRecordQuery(id));
        return response.Match(
            value => Ok(_mapper.Map<MasterlistAdultResponse>(value)),
            error => Problem(error));
    }

    // PUT api/<MasterlistController>/child/5
    [HttpPut("child")]
    public async Task<ActionResult<CommandResponse<Guid>>> UpdateChild([FromBody] UpdateMasterlistChildDto dto)
    {
        var response = await _mediator.Send(new UpdateMasterlistChildCommand { MasterlistDto = dto });
        return Ok(response);
    }

    // PUT api/<MasterlistController>/child/5
    [HttpPut("adult")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ApiResponse<Guid>))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
    [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
    public async Task<IActionResult> UpdateAdult([FromBody] UpdateMasterlistAdultRequest request)
    {
        var command = _mapper.Map<UpdateMasterlistAdultCommand>(request);
        var response = await _mediator.Send(command);
        return response.Match(
            value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
            error => Problem(error));
    }
}
