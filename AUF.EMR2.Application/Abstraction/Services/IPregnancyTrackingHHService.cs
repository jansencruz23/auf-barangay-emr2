using AUF.EMR2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Services
{
    public interface IPregnancyTrackingHHService
    {
        Task<PregnancyTrackingHh> CreatePregnancyTrackingHH(int householdId);
    }
}
