namespace AUF.EMR2.Application.Features.HouseholdMembers.Common;

public record QuarterlyClassificationData(
    string? FirstQtrClassification,
    string? SecondQtrClassification,
    string? ThirdQtrClassification,
    string? FourthQtrClassification
);