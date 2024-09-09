using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Persistence.Common
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(Guid id);
        Task<T> Add(T entity);
        void Update(T entity);
        Task Delete(Guid id);
        Task<bool> Exists(Guid id);
        Task<int> TotalCount();
    }
}
