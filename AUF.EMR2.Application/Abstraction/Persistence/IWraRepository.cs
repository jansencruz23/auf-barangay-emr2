using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Persistence
{
    public interface IWraRepository : IGenericRepository<WomanOfReproductiveAge>
    {
        Task<List<WomanOfReproductiveAge>> GetWraList(string householdNo);
        Task<WomanOfReproductiveAge> GetWra(int id);
    }
}
