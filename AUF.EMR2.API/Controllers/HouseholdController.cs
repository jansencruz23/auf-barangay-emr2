using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;
using AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;
using AUF.EMR2.Contracts.Common.Response;
using AUF.EMR2.Contracts.Households.Request;
using AUF.EMR2.Contracts.Households.Response;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    public class HouseholdController : ApiController
    {
        private readonly ISender _mediator;
        private readonly IMapper _mapper;

        public HouseholdController(ISender mediator, IMapper mapper)
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
            var response = await _mediator.Send(new GetHouseholdListQuery { RequestParams = requestParams, Query = query });

            return response.Match(
                value => Ok(_mapper.Map<ApiPagedResponse<HouseholdResponse>>(value)),
                errors => Problem(errors));
        }

        // GET api/<HouseholdController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HouseholdResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _mediator.Send(new GetHouseholdQuery { Id = id });

            return response.Match(
                value => Ok(_mapper.Map<HouseholdResponse>(value)),
                errors => Problem(errors));
        }

        // GET api/<HouseholdController>/household-no/householdNo
        [HttpGet("household-no/{householdNo}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(HouseholdResponse))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> GetByHouseholdNo(string householdNo)
        {
            var response = await _mediator.Send(new GetHouseholdByHouseholdNoQuery { HouseholdNo = householdNo });

            return response.Match(
               value => Ok(_mapper.Map<HouseholdResponse>(value)),
               errors => Problem(errors));
        }

        // POST api/<HouseholdController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<Guid>))]
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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CommandResponse<Guid>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
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
        public async Task<ActionResult<CommandResponse<Guid>>> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteHouseholdCommand { Id = id });
            return Ok(response);
        }
    }
}
