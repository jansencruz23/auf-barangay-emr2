using AUF.EMR2.Application.DTOs.OralHealth;
using AUF.EMR2.Application.Features.OralHealths.Commands.UpdateOralHealth;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthFiveToNine;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthInfant;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthOneToFour;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthPregnantFifteenToNineteen;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthPregnantTwentyToFourtyNine;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthRecord;
using AUF.EMR2.Application.Features.OralHealths.Queries.GetOralHealthTenToFourteen;
using AUF.EMR2.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OralHealthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OralHealthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<OralHealthController>/infants/
        [HttpGet("infants/{householdNo}")]
        public async Task<ActionResult<List<OralHealthDto>>> GetInfants(string householdNo)
        {
            var response = await _mediator.Send(new GetOralHealthInfantRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<OralHealthController>/one-to-four/
        [HttpGet("one-to-four/{householdNo}")]
        public async Task<ActionResult<List<OralHealthDto>>> GetOneToFour(string householdNo)
        {
            var response = await _mediator.Send(new GetOralHealthOneToFourRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<OralHealthController>/five-to-nine/
        [HttpGet("five-to-nine/{householdNo}")]
        public async Task<ActionResult<List<OralHealthDto>>> GetFiveToNine(string householdNo)
        {
            var response = await _mediator.Send(new GetOralHealthFiveToNineRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<OralHealthController>/ten-to-fourteen/
        [HttpGet("ten-to-fourteen/{householdNo}")]
        public async Task<ActionResult<List<OralHealthDto>>> GetTenToFourteen(string householdNo)
        {
            var response = await _mediator.Send(new GetOralHealthTenToFourteenRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<OralHealthController>/pregnant-fifteen-to-nineteen/
        [HttpGet("pregnant-fifteen-to-nineteen/{householdNo}")]
        public async Task<ActionResult<List<OralHealthDto>>> GetPregnantFifteenToNineteen(string householdNo)
        {
            var response = await _mediator.Send(new GetOralHealthPregnantFifteenToNineteenRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<OralHealthController>/pregnant-twenty-to-fourty-nine/
        [HttpGet("pregnant-twenty-to-fourty-nine/{householdNo}")]
        public async Task<ActionResult<List<OralHealthDto>>> GetPregnantTwentyToFourtyNine(string householdNo)
        {
            var response = await _mediator.Send(new GetOralHealthPregnantTwentyToFourtyNineRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET api/<OralHealthController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OralHealthDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetOralHealthRecordRequest { Id = id });
            return Ok(response);
        }


        // PUT api/<OralHealthController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Put([FromBody] UpdateOralHealthDto dto)
        {
            var response = await _mediator.Send(new UpdateOralHealthCommand { OralHealthDto = dto });
            return Ok(response);
        }
    }
}
