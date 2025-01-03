using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Features.Barangays.Common;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;

public sealed record UpdateBarangayCommand(
    Guid Id,
    string BarangayName,
    byte[]? Logo,
    BarangayAddressData BarangayAddress,
    string ContactNo,
    string BarangayHealthStation,
    string RuralHealthUnit,
    string? Description,
    Guid Version
) : IRequest<ErrorOr<CommandResponse<Guid>>>;