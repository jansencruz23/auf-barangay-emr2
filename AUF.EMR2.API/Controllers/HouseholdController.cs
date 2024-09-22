using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;
using AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;
using AUF.EMR2.Contracts.Households.Request;
using ErrorOr;
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
        public async Task<ActionResult<PagedQueryResponse<HouseholdDto>>> Get([FromQuery] RequestParams requestParams, string query = null)
        {
            var response = await _mediator.Send(new GetHouseholdListRequest { RequestParams = requestParams, Query = query });
            return Ok(response);
        }

        // GET api/<HouseholdController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseholdDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetHouseholdRequest { Id = id });
            return Ok(response);
        }

        // GET api/<HouseholdController>/household-no/householdNo
        [HttpGet("household-no/{householdNo}")]
        public async Task<ActionResult<HouseholdDto>> GetByHouseholdNo(string householdNo)
        {
            var response = await _mediator.Send(new GetHouseholdByHouseholdNoRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // POST api/<HouseholdController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BaseCommandResponse<Guid>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Post([FromBody] CreateHouseholdDto dto)
        {
            var command = _mapper.Map<CreateHouseholdCommand>(dto);
            var response = await _mediator.Send(command);
            return response.Match(value => Ok(value), errors => Problem(errors));
        }

        // PUT api/<HouseholdController>/5
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse<Guid>>> Put([FromBody] UpdateHouseholdDto dto)
        {
            var response = await _mediator.Send(new UpdateHouseholdCommand { HouseholdDto = dto });
            return Ok(response);
        }

        // DELETE api/<HouseholdController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse<Guid>>> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteHouseholdCommand { Id = id });
            return Ok(response);
        }
    }
}
