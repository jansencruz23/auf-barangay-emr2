using AUF.EMR2.API.Common.Errors;
using AUF.EMR2.Application.Common.Models.Pagination;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Household;
using AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;
using AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;
using AUF.EMR2.Application.Features.Households.Commands.UpdateHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHousehold;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdByHouseholdNo;
using AUF.EMR2.Application.Features.Households.Queries.GetHouseholdList;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    public class HouseholdController : ApiController
    {
        private readonly IMediator _mediator;

        public HouseholdController(IMediator mediator)
        {
            _mediator = mediator;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ProblemDetails))]
        public async Task<IActionResult> Post([FromBody] CreateHouseholdDto dto)
        {
            var result = await _mediator.Send(new CreateHouseholdCommand(dto));
            return result.Match(response => Ok(response), errors => Problem(errors));
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
