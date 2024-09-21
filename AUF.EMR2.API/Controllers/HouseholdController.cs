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
    [ApiController]
    public class HouseholdController : ControllerBase
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
        public async Task<ActionResult<ErrorOr<Guid>>> Post([FromBody] CreateHouseholdDto dto)
        {
            var response = await _mediator.Send(new CreateHouseholdCommand(dto));
            return Ok(response);
        }

        // PUT api/<HouseholdController>/5
        [HttpPut("{id}")]
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
