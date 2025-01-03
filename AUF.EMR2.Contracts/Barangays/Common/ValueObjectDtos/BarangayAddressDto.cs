namespace AUF.EMR2.Contracts.Barangays.Common.ValueObjectDtos;

public sealed record BarangayAddressDto(
    string Street,
    string Municipality,
    string Province,
    string Region
);