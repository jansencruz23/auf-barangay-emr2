using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate;
using AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate.ValueObjects;

namespace AUF.EMR2.Application.Abstraction.Persistence;

public interface IWraRepository : IGenericRepository<WomanOfReproductiveAge, WomanOfReproductiveAgeId>
{
    Task<List<WomanOfReproductiveAge>> GetWraList(string householdNo);
    Task<WomanOfReproductiveAge> GetWra(WomanOfReproductiveAgeId id);
}
