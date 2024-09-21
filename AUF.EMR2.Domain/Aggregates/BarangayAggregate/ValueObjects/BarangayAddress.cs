using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.BarangayAggregate.ValueObjects;

public sealed class BarangayAddress : ValueObject
{
    public string Street { get; }
    public string Municipality { get; }
    public string Province { get; }
    public string Region { get; }

    private BarangayAddress(
        string street, 
        string municipality,
        string province, 
        string region)
    {
        Street = street;
        Municipality = municipality;
        Province = province;
        Region = region;
    }

    public static BarangayAddress Create(
        string street,
        string municipality,
        string province,
        string region)
    {
        return new BarangayAddress(
            street, 
            municipality, 
            province, 
            region);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Street;
        yield return Municipality;
        yield return Province;
        yield return Region;
    }

    private BarangayAddress() { }
}
