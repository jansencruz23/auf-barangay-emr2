namespace AUF.EMR2.Application.Features.Households.Common;

public sealed record PhilhealthRequest(
    bool IsHeadPhilhealthMember,
    string? PhilhealthNo,
    string? Category
);