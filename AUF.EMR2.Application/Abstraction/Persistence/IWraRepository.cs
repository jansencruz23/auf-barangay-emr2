﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Aggregates;
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
        Task<WomanOfReproductiveAge> GetWra(Guid id);
    }
}
