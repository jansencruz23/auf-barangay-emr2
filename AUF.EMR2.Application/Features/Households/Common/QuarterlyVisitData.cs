namespace AUF.EMR2.Application.Features.Households.Common;

public sealed record QuarterlyVisitData(
    DateTime? FirstQtrVisit,
    DateTime? SecondQtrVisit,
    DateTime? ThirdQtrVisit,
    DateTime? FourthQtrVisit
);