namespace AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

public sealed record HouseAddressDto(
    string HouseNoAndStreet,
    string Barangay,
    string City,
    string Province
);