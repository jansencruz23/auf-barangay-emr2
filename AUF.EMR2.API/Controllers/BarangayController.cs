using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.Barangay;
using AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;
using AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BarangayController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BarangayController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<BarangayController>
        [HttpGet]
        public async Task<ActionResult<BarangayDto>> Get()
        {
            var response = await _mediator.Send(new GetBarangayRequest());
            return Ok(response);
        }

        // PUT api/<BarangayController>/5
        [HttpPut]
        public async Task<ActionResult<CommandResponse<Guid>>> Put([FromBody] UpdateBarangayDto dto)
        {
            var response = await _mediator.Send(new UpdateBarangayCommand { BarangayDto = dto });
            return Ok(response);
        }
    }
}
