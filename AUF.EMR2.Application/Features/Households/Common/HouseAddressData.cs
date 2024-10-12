namespace AUF.EMR2.Application.Features.Households.Common;

public sealed record HouseAddressData(
    string HouseNoAndStreet,
    string Barangay,
    string City,
    string Province
);