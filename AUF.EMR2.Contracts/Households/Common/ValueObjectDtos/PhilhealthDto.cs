namespace AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

public sealed record PhilhealthDto(
    bool IsHeadPhilhealthMember,
    string? PhilhealthNo,
    string? Category
);