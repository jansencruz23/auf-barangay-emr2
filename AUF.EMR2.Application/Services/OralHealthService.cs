using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Services
{
    public class OralHealthService : IOralHealthService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OralHealthService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HouseholdMember>> GetFiveToNineChildren(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.FiveToNineStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.FiveToNineEnd);

            return await _unitOfWork.OralHealthRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetInfants(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.InfantStart).AddDays(1);
            return await _unitOfWork.OralHealthRepository.GetListQuery(householdNo, startDate);
        }

        public async Task<List<HouseholdMember>> GetOneToFourChildren(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.OneToFourStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.OneToFourEnd);

            return await _unitOfWork.OralHealthRepository.GetListQuery(householdNo, startDate);
        }

        public async Task<List<HouseholdMember>> GetPregnantFifteenToNineteen(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.FifteenToNineteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.FifteenToNineteenEnd);

            return await _unitOfWork.OralHealthRepository.GetPregnantHouseholdMembers(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetPregnantTwentyToFourtyNine(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.TwentyToFourtynineStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.TwentyToFourtynineEnd);

            return await _unitOfWork.OralHealthRepository.GetPregnantHouseholdMembers(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetTenToFourteenChildren(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(OralHealthAgeRange.TenToFourteenStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(OralHealthAgeRange.TenToFourteenEnd);

            return await _unitOfWork.OralHealthRepository.GetListQuery(householdNo, startDate);
        }
    }
}
