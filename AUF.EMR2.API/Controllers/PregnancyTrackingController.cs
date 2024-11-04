using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.PregnancyTracking;
using AUF.EMR2.Application.Features.PregnancyTrackings.Commands.CreatePregnancyTracking;
using AUF.EMR2.Application.Features.PregnancyTrackings.Commands.DeletePregnancyTracking;
using AUF.EMR2.Application.Features.PregnancyTrackings.Commands.UpdatePregnancyTracking;
using AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPregnancyTracking;
using AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPregnancyTrackingList;
using AUF.EMR2.Application.Features.PregnancyTrackings.Queries.GetPrintPregnancyTrackingRecords;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PregnancyTrackingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PregnancyTrackingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<PregnancyTrackingController>
        [HttpGet]
        public async Task<ActionResult<List<PregnancyTrackingDto>>> Get(string householdNo)
        {
            var response = await _mediator.Send(new GetPregnancyTrackingListRequest { HouseholdNo = householdNo });
            return Ok(response);
        }


        // GET: api/<PregnancyTrackingController>
        [HttpGet("print/{householdNo}")]
        public async Task<ActionResult<PrintPregnancyTrackingDto>> GetPrintPregnancyTracking(string householdNo)
        {
            var response = await _mediator.Send(new GetPrintPregnancyTrackingRecordsRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET api/<PregnancyTrackingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PregnancyTrackingDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetPregnancyTrackingRequest { Id = id });
            return Ok(response);
        }

        // POST api/<PregnancyTrackingController>
        [HttpPost]
        public async Task<ActionResult<CommandResponse<Guid>>> Post([FromBody] CreatePregnancyTrackingDto dto)
        {
            var response = await _mediator.Send(new CreatePregnancyTrackingCommand { PregnancyTrackingDto = dto });
            return Ok(response);
        }

        // PUT api/<PregnancyTrackingController>/5
        [HttpPut]
        public async Task<ActionResult<CommandResponse<Guid>>> Put([FromBody] UpdatePregnancyTrackingDto dto)
        {
            var response = await _mediator.Send(new UpdatePregnancyTrackingCommand { PregnancyTrackingDto = dto });
            return Ok(response);
        }

        // DELETE api/<PregnancyTrackingController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommandResponse<Guid>>> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeletePregnancyTrackingCommand { Id = id });
            return Ok(response);
        }
    }
}
