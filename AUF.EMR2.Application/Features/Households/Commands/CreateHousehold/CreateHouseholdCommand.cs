using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Households.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.CreateHousehold;

public sealed record CreateHouseholdCommand(
    string HouseholdNo,
    DateTime? FirstQtrVisit,
    DateTime? SecondQtrVisit,
    DateTime? ThirdQtrVisit,
    DateTime? FourthQtrVisit,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    HouseAddressRequest HouseAddress,
    string ContactNo,
    bool IsNhts,
    PhilhealthRequest Philhealth,
    bool IsIp
) : IRequest<ErrorOr<BaseCommandResponse<Guid>>>;