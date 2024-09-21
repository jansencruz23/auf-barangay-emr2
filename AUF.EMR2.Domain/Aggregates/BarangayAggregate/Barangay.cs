using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.BarangayAggregate;

public sealed class Barangay : AggregateRoot<BarangayId>
{
    public string BarangayName { get; private set; } = null!;
    public byte[]? Logo { get; private set; }
    public BarangayAddress BarangayAddress { get; private set; } = null!;
    public string ContactNo { get; private set; } = null!;
    public string BarangayHealthStation { get; private set; } = null!;  
    public string RuralHealthUnit { get; private set; } = null!;
    public string? Description { get; private set; } 

    private Barangay(
        BarangayId barangayId,
        string barangayName,
        byte[]? logo,
        BarangayAddress barangayAddress,
        string contactNo,
        string barangayHealthStation,
        string ruralHealthUnit,
        string? description)
        : base(barangayId)
    {
        BarangayName = barangayName;
        Logo = logo;
        BarangayAddress = barangayAddress;
        ContactNo = contactNo;
        BarangayHealthStation = barangayHealthStation;
        RuralHealthUnit = ruralHealthUnit;
        Description = description;
    }

    public static Barangay Create(
        string barangayName,
        byte[]? logo,
        BarangayAddress barangayAddress,
        string contactNo,
        string barangayHealthStation,
        string ruralHealthUnit,
        string? description)
    {
        return new Barangay(
            barangayId: BarangayId.Create(),
            barangayName: barangayName,
            logo: logo,
            barangayAddress: barangayAddress,
            contactNo: contactNo,
            barangayHealthStation: barangayHealthStation,
            ruralHealthUnit: ruralHealthUnit,
            description: description);
    }

    private Barangay() { }
}
