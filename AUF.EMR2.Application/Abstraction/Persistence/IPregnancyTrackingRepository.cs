using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Persistence
{
    public interface IPregnancyTrackingRepository : IGenericRepository<PregnancyTracking>
    {
        Task<List<PregnancyTracking>> GetPregnancyTrackingList(string householdNo);
        Task<PregnancyTracking> GetPregnancyTracking(int id);
    }
}
