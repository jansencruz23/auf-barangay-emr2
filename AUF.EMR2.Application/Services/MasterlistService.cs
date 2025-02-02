﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Abstraction.Services;
using AUF.EMR2.Application.Common.Constants;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;

namespace AUF.EMR2.Application.Services;

public class MasterlistService : IMasterlistService
{
    private readonly IUnitOfWork _unitOfWork;

    public MasterlistService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<HouseholdMember>> GetMasterlistAdolescents(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentStart).AddDays(1);
        var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdolescentEnd);

        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate, endDate);
    }

    public async Task<List<HouseholdMember>> GetMasterlistAdults(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultStart).AddDays(1);
        var endDate = DateTime.Today.AddYears(MasterlistAgeRange.AdultEnd);

        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate, endDate);
    }

    public async Task<List<HouseholdMember>> GetMasterlistInfants(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddMonths(MasterlistAgeRange.InfantStart).AddDays(1);
        var endDate = DateTime.Today.AddDays(MasterlistAgeRange.InfantEnd);

        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate, endDate);
    }

    public async Task<List<HouseholdMember>> GetMasterlistNewborns(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddDays(MasterlistAgeRange.NewbornStart);
        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate);
    }

    public async Task<List<HouseholdMember>> GetMasterlistSchoolAgedChildren(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedStart).AddDays(1);
        var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SchoolAgedEnd);

        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate, endDate);
    }

    public async Task<List<HouseholdMember>> GetMasterlistSeniors(HouseholdId householdId)
    {
        var startDate = DateTime.MinValue;
        var endDate = DateTime.Today.AddYears(MasterlistAgeRange.SeniorEnd);

        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate, endDate);
    }

    public async Task<List<HouseholdMember>> GetMasterlistUnderFiveChildren(HouseholdId householdId)
    {
        var startDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveStart).AddDays(1);
        var endDate = DateTime.Today.AddYears(MasterlistAgeRange.UnderFiveEnd);

        return await _unitOfWork.HouseholdMemberRepository.GetListQuery(householdId, startDate, endDate);
    }
}
