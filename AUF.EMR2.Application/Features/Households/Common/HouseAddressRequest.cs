namespace AUF.EMR2.Application.Features.Households.Common;

public sealed record HouseAddressRequest(
    string HouseNoAndStreet,
    string Barangay,
    string City,
    string Province
);