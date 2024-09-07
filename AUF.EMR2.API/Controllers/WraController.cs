using AUF.EMR2.Application.DTOs.WomanOfReproductiveAge;
using AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.CreateWra;
using AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.DeleteWra;
using AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.UpdateWra;
using AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetPrintWraRecords;
using AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetWra;
using AUF.EMR2.Application.Features.WomenOfReproductiveAge.Queries.GetWraList;
using AUF.EMR2.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WraController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WraController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<WraController>
        [HttpGet]
        public async Task<ActionResult<List<WraOnlyDto>>> Get(string householdNo)
        {
            var response = await _mediator.Send(new GetWraListRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<WraController>/print/householdNo
        [HttpGet("print/{householdNo}")]
        public async Task<ActionResult<List<WraOnlyDto>>> GetPrintWraRecords(string householdNo)
        {
            var response = await _mediator.Send(new GetPrintWraRecordsRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET api/<WraController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WraDto>> Get(int id)
        {
            var response = await _mediator.Send(new GetWraRequest { Id = id });
            return Ok(response);
        }

        // POST api/<WraController>
        [HttpPost]
        public async Task<ActionResult<BaseCommandResponse<int>>> Post([FromBody] CreateWraDto dto)
        {
            var response = await _mediator.Send(new CreateWraCommand { WraDto = dto });
            return Ok(response);
        }

        // PUT api/<WraController>/5
        [HttpPut]
        public async Task<ActionResult<BaseCommandResponse<int>>> Put([FromBody] UpdateWraDto dto)
        {
            var response = await _mediator.Send(new UpdateWraCommand { WraDto = dto });
            return Ok(response);
        }

        // DELETE api/<WraController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteWraCommand { Id = id });
            return Ok(response);
        }
    }
}
