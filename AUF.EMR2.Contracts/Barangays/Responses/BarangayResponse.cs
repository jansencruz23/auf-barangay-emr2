using AUF.EMR2.Contracts.Barangays.Common.ValueObjectDtos;

namespace AUF.EMR2.Contracts.Barangays.Responses;

public sealed record BarangayResponse(
    Guid Id,
    string BarangayName,
    byte[]? Logo,
    BarangayAddressDto BarangayAddress,
    string ContactNo,
    string BarangayHealthStation,
    string RuralHealthUnit,
    string? Description
);