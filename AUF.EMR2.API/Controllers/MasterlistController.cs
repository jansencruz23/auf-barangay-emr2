﻿using AUF.EMR2.Application.DTOs.Masterlist;
using AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult;
using AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistChild;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdolescent;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdultDetail;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistChildDetail;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistNewborn;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSchoolAged;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSenior;
using AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistUnderFive;
using AUF.EMR2.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AUF.EMR2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterlistController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MasterlistController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/<MasterlistController>/newborns/
        [HttpGet("newborns/{householdNo}")]
        public async Task<ActionResult<List<MasterlistChildDto>>> GetNewborns(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistNewbornRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<MasterlistController>/infants/
        [HttpGet("infants/{householdNo}")]
        public async Task<ActionResult<List<MasterlistChildDto>>> GetInfants(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistInfantRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<MasterlistController>/under-five/
        [HttpGet("under-five/{householdNo}")]
        public async Task<ActionResult<List<MasterlistChildDto>>> GetUnderFiveChildren(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistUnderFiveRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<MasterlistController>/school-aged/
        [HttpGet("school-aged/{householdNo}")]
        public async Task<ActionResult<List<MasterlistChildDto>>> GetSchoolAgedChildren(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistSchoolAgedRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<MasterlistController>/adolescents/
        [HttpGet("adolescents/{householdNo}")]
        public async Task<ActionResult<List<MasterlistChildDto>>> GetAdolescents(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistAdolescentRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<MasterlistController>/adults/
        [HttpGet("adults/{householdNo}")]
        public async Task<ActionResult<List<MasterlistAdultDto>>> GetAdults(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistAdultRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET: api/<MasterlistController>/seniors/
        [HttpGet("seniors/{householdNo}")]
        public async Task<ActionResult<List<MasterlistAdultDto>>> GetSeniors(string householdNo)
        {
            var response = await _mediator.Send(new GetMasterlistSeniorRequest { HouseholdNo = householdNo });
            return Ok(response);
        }

        // GET api/<MasterlistController>/child/5
        [HttpGet("child/{id}")]
        public async Task<ActionResult<MasterlistChildDto>> GetChildDetails(int id)
        {
            var response = await _mediator.Send(new GetMasterlistChildDetailRequest { Id = id });
            return Ok(response);
        }

        // GET api/<MasterlistController>/adult/5
        [HttpGet("adult/{id}")]
        public async Task<ActionResult<MasterlistChildDto>> GetAdultDetails(int id)
        {
            var response = await _mediator.Send(new GetMasterlistAdultDetailRequest { Id = id });
            return Ok(response);
        }


        // PUT api/<MasterlistController>/child/5
        [HttpPut("child/{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> UpdateChild([FromBody] UpdateMasterlistChildDto dto)
        {
            var response = await _mediator.Send(new UpdateMasterlistChildCommand { MasterlistDto = dto });
            return Ok(response);
        }

        // PUT api/<MasterlistController>/child/5
        [HttpPut("adult/{id}")]
        public async Task<ActionResult<BaseCommandResponse<int>>> UpdateAdult([FromBody] UpdateMasterlistAdultDto dto)
        {
            var response = await _mediator.Send(new UpdateMasterlistAdultCommand { MasterlistDto = dto });
            return Ok(response);
        }
    }
}
