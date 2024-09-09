using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Constants;
using AUF.EMR2.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Services
{
    public class MasterlistService : IMasterlistService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MasterlistService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<HouseholdMember>> GetMasterlistAdolescents(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentEnd);

            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistAdults(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistInfants(string householdNo)
        {
            var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart).AddDays(1);
            var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantEnd);

            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistNewborns(string householdNo)
        {
            var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistSchoolAgedChildren(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedEnd);

            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistSeniors(string householdNo)
        {
            var startDate = DateTime.MinValue;
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SeniorEnd);

            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate, endDate);
        }

        public async Task<List<HouseholdMember>> GetMasterlistUnderFiveChildren(string householdNo)
        {
            var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
            var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

            return await _unitOfWork.MasterlistRepository.GetListQuery(householdNo, startDate, endDate);
        }
    }
}
