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
        Task<T> Get(int id);
        Task<T> Add(T entity);
        void Update(T entity);
        Task Delete(int id);
        Task<bool> Exists(int id);
        Task<int> TotalCount();
    }
}
