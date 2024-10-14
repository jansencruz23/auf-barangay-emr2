namespace AUF.EMR2.Contracts.Barangays.Requests; 

public sealed record UpdateBarangayRequest(
    Guid Id,
    string BarangayName,
    byte[]? Logo,
    string Street,
    string Municipality,
    string Province,
    string Region,
    string ContactNo,
    string BarangayHealthStation,
    string RuralHealthUnit,
    string? Description,
    Guid Version
);