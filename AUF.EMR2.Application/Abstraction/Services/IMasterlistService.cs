using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;

namespace AUF.EMR2.Application.Abstraction.Services;

public interface IMasterlistService
{
    Task<List<HouseholdMember>> GetMasterlistNewborns(HouseholdId householdId);
    Task<List<HouseholdMember>> GetMasterlistInfants(string householdNo);
    Task<List<HouseholdMember>> GetMasterlistUnderFiveChildren(string householdNo);
    Task<List<HouseholdMember>> GetMasterlistSchoolAgedChildren(string householdNo);
    Task<List<HouseholdMember>> GetMasterlistAdolescents(string householdNo);
    Task<List<HouseholdMember>> GetMasterlistAdults(string householdNo);
    Task<List<HouseholdMember>> GetMasterlistSeniors(string householdNo);
}
