using AUF.EMR2.Application.Features.Barangays.Common;

namespace AUF.EMR2.Application.Features.Barangays.Queries.Common.Responses;

public sealed record BarangayQueryResponse(
    Guid Id,
    string BarangayName,
    byte[]? Logo,
    BarangayAddressData BarangayAddress,
    string ContactNo,
    string BarangayHealthStation,
    string RuralHealthUnit,
    string? Description
);
