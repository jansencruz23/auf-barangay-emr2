using AUF.EMR2.Domain.Aggregates.PregnancyTrackingHhAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Services
{
    public interface IPregnancyTrackingHHService
    {
        Task<PregnancyTrackingHh> CreatePregnancyTrackingHH(Guid householdId);
    }
}
