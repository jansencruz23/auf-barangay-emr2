using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Services
{
    public class PregnancyTrackingHHService : IPregnancyTrackingHHService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PregnancyTrackingHHService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PregnancyTrackingHh> CreatePregnancyTrackingHH(Guid householdId)
        {
            var barangay = await _unitOfWork.BarangayRepository.GetBarangay();
            var pregnancyTrackingHh = new PregnancyTrackingHh
            {
                BarangayId = barangay.Id,
                HouseholdId = householdId,
                Year = DateTime.Now.Year
            };

            return pregnancyTrackingHh;
        }
    }
}
