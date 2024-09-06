using AUF.EMR2.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Abstraction.Services
{
    public interface IOralHealthService
    {
        Task<List<HouseholdMember>> GetInfants(string householdNo);
        Task<List<HouseholdMember>> GetOneToFourChildren(string householdNo);
        Task<List<HouseholdMember>> GetFiveToNineChildren(string householdNo);
        Task<List<HouseholdMember>> GetTenToFourteenChildren(string householdNo);
        Task<List<HouseholdMember>> GetPregnantFifteenToNineteen(string householdNo);
        Task<List<HouseholdMember>> GetPregnantTwentyToFourtyNine(string householdNo);
    }
}
