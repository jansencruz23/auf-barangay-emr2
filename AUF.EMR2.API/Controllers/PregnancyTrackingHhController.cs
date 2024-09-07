using AUF.EMR2.Application.DTOs.PregnancyTrackingHh;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh;
using AUF.EMR2.Application.Features.PregnancyTrackingHhs.Queries.GetPregnancyTrackingHh;
using AUF.EMR2.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregnancyTrackingHhController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PregnancyTrackingHhController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET api/<PregnancyTrackingHhController>/5
        [HttpGet("{householdNo}")]
        public async Task<ActionResult<PregnancyTrackingHhDto>> Get(string householdNo)
        {
            var response = await _mediator.Send(new GetPregnancyTrackingHhRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // PUT api/<PregnancyTrackingHhController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Put([FromBody] UpdatePregnancyTrackingHhDto dto)
        {
            var response = await _mediator.Send(new UpdatePregnancyTrackingHhCommand { PregnancyTrackingHHDto = dto });
            return Ok(response);
        }
    }
}
