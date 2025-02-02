﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult;

public class GetMasterlistAdultQueryHandler : IRequestHandler<GetMasterlistAdultQuery, ErrorOr<List<MasterlistAdultQueryResponse>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMasterlistService _masterlistService;
    private readonly IMapper _mapper;

    public GetMasterlistAdultQueryHandler(
        IUnitOfWork unitOfWork,
        IMasterlistService masterlistService,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _masterlistService = masterlistService;
        _mapper = mapper;
    }

    public async Task<ErrorOr<List<MasterlistAdultQueryResponse>>> Handle(GetMasterlistAdultQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var members = await _masterlistService.GetMasterlistAdults(HouseholdId.Create(request.HouseholdId));
            if (members is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            var response = _mapper.Map<List<MasterlistAdultQueryResponse>>(members);
            return response;
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
