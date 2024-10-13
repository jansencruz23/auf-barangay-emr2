using AUF.EMR2.Application.Common.Responses;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.PregnancyTrackingHhs.Commands.UpdatePregnancyTrackingHh;

public record UpdatePregnancyTrackingHhCommand(
    Guid Id,
    int Year,
    Guid BarangayId,
    string? BirthingCenter,
    string? BirthingCenterAddress,
    string ReferralCenter,
    string? ReferralCenterAddress,
    string? BhwName,
    string? MidwifeName,
    Guid HouseholdId,
    Guid Version
) : IRequest<ErrorOr<CommandResponse<Guid>>>;