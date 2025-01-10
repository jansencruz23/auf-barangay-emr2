using AUF.EMR2.Domain.Common.Models;
using System.IO;

namespace AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;

public sealed class HouseAddress : ValueObject
{
    public string HouseNoAndStreet { get; } = null!;
    public string Barangay { get; } = null!;
    public string City { get; } = null!;
    public string Province { get; } = null!;
    
    private HouseAddress(
        string houseNoAndStreet,
        string barangay,
        string city,
        string province)
    {
        HouseNoAndStreet = houseNoAndStreet;
        Barangay = barangay;
        City = city;
        Province = province;
    }

    public static HouseAddress Create(
        string houseNoAndStreet,
        string barangay,
        string city,
        string province)
    {
        return new HouseAddress(houseNoAndStreet, barangay, city, province);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return HouseNoAndStreet;
        yield return Barangay;
        yield return City;
        yield return Province;
    }

    public string FormatAddress()
    {
        return $"{HouseNoAndStreet}, {Barangay}, {City}, {Province}";
    }

    private HouseAddress() { }
}