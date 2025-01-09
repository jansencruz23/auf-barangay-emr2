using AUF.EMR2.Contracts.HouseholdMembers.Common.Enums;

namespace AUF.EMR2.Contracts.Masterlist.Requests;

public sealed record UpdateMasterlistAdultRequest(
    Guid Id,
    Guid Version,
    string LastName,
    string FirstName,
    string? MotherMaidenName,
    Sex Sex,
    DateTime Birthday,
    bool IsNhts
);