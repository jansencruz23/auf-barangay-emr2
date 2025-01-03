namespace AUF.EMR2.Contracts.HouseholdMembers.Common.ValueObjectDtos;

public record QuarterlyClassificationDto(
    string? FirstQtrClassification,
    string? SecondQtrClassification,
    string? ThirdQtrClassification,
    string? FourthQtrClassification
);
