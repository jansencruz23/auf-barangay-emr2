using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;

namespace AUF.EMR2.Application.Abstraction.Services;

public interface IMasterlistService
{
    Task<List<HouseholdMember>> GetMasterlistNewborns(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistInfants(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistUnderFiveChildren(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistSchoolAgedChildren(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistAdolescents(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistAdults(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistSeniors(HouseholdId householdId);
}
