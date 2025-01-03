namespace AUF.EMR2.Contracts.Households.Common.ValueObjectDtos;

public sealed record QuarterlyVisitDto(
    DateTime? FirstQtrVisit,
    DateTime? SecondQtrVisit,
    DateTime? ThirdQtrVisit,
    DateTime? FourthQtrVisit
);