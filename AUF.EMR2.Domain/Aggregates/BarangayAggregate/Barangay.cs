using AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;
using ErrorOr;

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
        BarangayAddress barangayAddress,
        string contactNo,
        string barangayHealthStation,
        string ruralHealthUnit,
        string? description = null,
        byte[]? logo = null)
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
        BarangayAddress barangayAddress,
        string contactNo,
        string barangayHealthStation,
        string ruralHealthUnit,
        string? description = null,
        byte[]? logo = null)
    {
        return new Barangay
        {
            Id = BarangayId.Create(),
            BarangayName = barangayName,
            Logo = logo,
            BarangayAddress = barangayAddress,
            ContactNo = contactNo,
            BarangayHealthStation = barangayHealthStation,
            RuralHealthUnit = ruralHealthUnit,
            Description = description
        };
    }

    public ErrorOr<BarangayId> Update(
        string barangayName,
        byte[]? logo,
        BarangayAddress barangayAddress,
        string contactNo,
        string barangayHealthStation,
        string ruralHealthUnit,
        string? description)
    {
        BarangayName = barangayName;
        Logo = logo;
        BarangayAddress = barangayAddress;
        ContactNo = contactNo;
        BarangayHealthStation = barangayHealthStation;
        RuralHealthUnit = ruralHealthUnit;
        Description = description;

        return Id;
    }

    private Barangay() { }
}
