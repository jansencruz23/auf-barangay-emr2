namespace AUF.EMR2.Application.Features.Barangays.Common;

public sealed record BarangayAddressData
(
    string Street,
    string Municipality,
    string Province,
    string Region
);