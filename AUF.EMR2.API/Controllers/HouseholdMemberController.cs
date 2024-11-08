﻿using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.DTOs.HouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberListByHouseholdNo;
using AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList;
using AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HouseholdMemberController : ControllerBase
    {
        private readonly IMediator _mediator;

        public HouseholdMemberController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<HouseholdMemberController>/household/householdNo
        [HttpGet("household/{householdNo}")]
        public async Task<ActionResult<List<HouseholdMemberDto>>> GetHouseholdMembers(string householdNo)
        {
            var response = await _mediator.Send(new GetHouseholdMemberListByHouseholdNoRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<HouseholdMemberController>/wra/householdNo
        [HttpGet("wra/{householdNo}")]
        public async Task<ActionResult<List<HouseholdMemberDto>>> GetWraHouseholdMembers(string householdNo)
        {
            var response = await _mediator.Send(new GetWraHouseholdMemberListRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET api/<HouseholdMemberController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HouseholdMemberDto>> Get(Guid id)
        {
            var response = await _mediator.Send(new GetHouseholdMemberRequest { Id = id });
            return Ok(response);
        }

        // POST api/<HouseholdMemberController>
        [HttpPost]
        public async Task<ActionResult<CommandResponse<Guid>>> Post([FromBody] CreateHouseholdMemberDto dto)
        {
            var response = await _mediator.Send(new CreateHouseholdMemberCommand { HouseholdMemberDto = dto });
            return Ok(response);
        }

        // PUT api/<HouseholdMemberController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<CommandResponse<Guid>>> Put([FromBody] UpdateHouseholdMemberDto dto)
        {
            var response = await _mediator.Send(new UpdateHouseholdMemberCommand { HouseholdMemberDto = dto });
            return Ok(response);
        }

        // DELETE api/<HouseholdMemberController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CommandResponse<Guid>>> Delete(Guid id)
        {
            var response = await _mediator.Send(new DeleteHouseholdMemberCommand { Id = id });
            return Ok(response);
        }
    }
}
