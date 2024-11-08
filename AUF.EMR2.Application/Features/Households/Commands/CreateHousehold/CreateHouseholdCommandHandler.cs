﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public class CreateHouseholdCommandHandler(
    IUnitOfWork unitOfWork,
    IPregnancyTrackingHHService pregnancyTrackingHhService) 
    : IRequestHandler<CreateHouseholdCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IPregnancyTrackingHHService _pregnancyTrackingHhService = pregnancyTrackingHhService;

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(CreateHouseholdCommand request, CancellationToken cancellationToken)
    {
        var householdNoAvailable = await _unitOfWork.HouseholdRepository
            .IsHouseholdNoAvailable(request.HouseholdNo);

        if (!householdNoAvailable)
        {
            return Errors.Household.DuplicateHouseholdNo;
        }

        var response = new CommandResponse<Guid>();

        var philhealth = Philhealth.Create
        (
            isHeadPhilhealthMember: request.Philhealth.IsHeadPhilhealthMember,
            philhealthNo: request.Philhealth.PhilhealthNo,
            category: request.Philhealth.Category
        );

        var houseAddress = HouseAddress.Create
        (
            houseNoAndStreet: request.HouseAddress.HouseNoAndStreet,
            barangay: request.HouseAddress.Barangay,
            city: request.HouseAddress.City,
            province: request.HouseAddress.Province
        );

        var household = Household.Create
        (
            householdNo: request.HouseholdNo,
            firstQtrVisit: request.FirstQtrVisit,
            secondQtrVisit: request.SecondQtrVisit,
            thirdQtrVisit: request.ThirdQtrVisit,
            fourthQtrVisit: request.FourthQtrVisit,
            lastName: request.LastName,
            firstName: request.FirstName,
            motherMaidenName: request.MotherMaidenName,
            contactNo: request.ContactNo,
            isNhts: request.IsNhts,
            isIp: request.IsIp,
            philhealth: philhealth,
            houseAddress: houseAddress
        );

        await _unitOfWork.HouseholdRepository.Add(household);
        await _unitOfWork.SaveAsync();

        response.Success = true;
        response.Id = household.Id.Value;
        response.Message = "Created successfully";

        return response;
    }
}
