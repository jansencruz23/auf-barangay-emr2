using AUF.EMR2.Application.Common.Responses;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.Barangays.Commands.UpdateBarangay;

public sealed record UpdateBarangayCommand(
    Guid Id,
    string BarangayName,
    byte[]? Logo,
    string Street,
    string Municipality,
    string Province,
    string Region, 
    string ContactNo,
    string BarangayHealthStation,
    string RuralHealthUnit,
    string? Description,
    Guid Version
) : IRequest<ErrorOr<CommandResponse<Guid>>>;