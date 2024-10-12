namespace AUF.EMR2.Application.Features.Households.Common;

public sealed record PhilhealthData(
    bool IsHeadPhilhealthMember,
    string? PhilhealthNo,
    string? Category
);