using AUF.EMR2.Application.DTOs.Barangay;
using AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;
using AUF.EMR2.Application.Features.Barangays.Queries.GetBarangay;
using AUF.EMR2.Contracts.Barangays.Requests;
using AUF.EMR2.Contracts.Common.Responses;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AUF.EMR2.API.Controllers;

[Route("api/barangays")]
public class BarangaysController : ApiController
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public BarangaysController(
        IMediator mediator,
        IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
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
    public async Task<IActionResult> Put([FromBody] UpdateBarangayRequest request)
    {
        var command = _mapper.Map<UpdateBarangayCommand>(request);
        var response = await _mediator.Send(command);

        return response.Match(
           value => Ok(_mapper.Map<ApiResponse<Guid>>(value)),
           errors => Problem(errors));
    }
}
