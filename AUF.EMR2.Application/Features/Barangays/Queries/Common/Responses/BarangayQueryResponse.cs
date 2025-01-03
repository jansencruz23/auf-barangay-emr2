namespace AUF.EMR2.Application.Features.Barangays.Queries.Common.Responses;

public sealed record BarangayQueryResponse(
    Guid Id,
    string BarangayName,
    byte[]? Logo,
    BarangayAddressDto BarangayAddress,
    string ContactNo,
    string BarangayHealthStation,
    string RuralHealthUnit,
    string? Description
);
