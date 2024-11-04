using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Application.Abstraction.Persistence.Common;

public interface IGenericRepository<T, TId>
    where T : AggregateRoot<TId>
    where TId : ValueObject
{
    Task<List<T>> GetAll();
    Task<T> Get(TId id);
    Task<T> Add(T entity);
    void Update(T entity);
    Task Delete(TId id);
    Task<bool> Exists(TId id);
    Task<int> TotalCount();
}
