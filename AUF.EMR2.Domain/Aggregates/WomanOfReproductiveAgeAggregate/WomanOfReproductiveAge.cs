using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Models;

namespace AUF.EMR2.Domain.Aggregates.WomanOfReproductiveAgeAggregate;

public class WomanOfReproductiveAge : AggregateRoot<WomanOfReproductiveAgeId>
{
    public HouseholdMemberId HouseholdMemberId { get; private set; } = null!;

    public int CivilStatus { get; private set; }
    public bool IsPlanningChildren { get; private set; }
    public bool? IsPlanChildrenNow { get; private set; }
    public bool? IsPlanChildrenSpacing { get; private set; }
    public bool? IsPlanChildrenLimiting { get; private set; }
    public bool IsFecund { get; private set; }
    public bool IsFPMethod { get; private set; }
    public bool? IsFPModern { get; private set; }
    public bool? ShiftToModern { get; private set; }
    public bool IsMFPUnmet { get; private set; }
    public bool AcceptModernFpMethod { get; private set; }
    public string? ModernFPMethod { get; private set; }
    public DateTime? FPAcceptedDate { get; private set; }

    private WomanOfReproductiveAge(
        WomanOfReproductiveAgeId womanOfReproductiveAgeId,
        HouseholdMemberId householdMemberId,
        int civilStatus,
        bool isPlanningChildren,
        bool? isPlanChildrenNow,
        bool? isPlanChildrenSpacing,
        bool? isPlanChildrenLimiting,
        bool isFecund,
        bool isFPMethod,
        bool? isFPModern,
        bool? shiftToModern,
        bool isMFPUnmet,
        bool acceptModernFpMethod,
        string? modernFPMethod,
        DateTime? fPAcceptedDate)
        : base(womanOfReproductiveAgeId)
    {
        HouseholdMemberId = householdMemberId;
        CivilStatus = civilStatus;
        IsPlanningChildren = isPlanningChildren;
        IsPlanChildrenNow = isPlanChildrenNow;
        IsPlanChildrenSpacing = isPlanChildrenSpacing;
        IsPlanChildrenLimiting = isPlanChildrenLimiting;
        IsFecund = isFecund;
        IsFPMethod = isFPMethod;
        IsFPModern = isFPModern;
        ShiftToModern = shiftToModern;
        IsMFPUnmet = isMFPUnmet;
        AcceptModernFpMethod = acceptModernFpMethod;
        ModernFPMethod = modernFPMethod;
        FPAcceptedDate = fPAcceptedDate;
    }

    public static WomanOfReproductiveAge Create(
        HouseholdMemberId householdMemberId,
        int civilStatus,
        bool isPlanningChildren,
        bool? isPlanChildrenNow,
        bool? isPlanChildrenSpacing,
        bool? isPlanChildrenLimiting,
        bool isFecund,
        bool isFPMethod,
        bool? isFPModern,
        bool? shiftToModern,
        bool isMFPUnmet,
        bool acceptModernFpMethod,
        string? modernFPMethod,
        DateTime? fPAcceptedDate)
    {
        return new WomanOfReproductiveAge(
            womanOfReproductiveAgeId: WomanOfReproductiveAgeId.Create(),
            householdMemberId: householdMemberId,
            civilStatus: civilStatus,
            isPlanningChildren: isPlanningChildren,
            isPlanChildrenNow: isPlanChildrenNow,
            isPlanChildrenSpacing: isPlanChildrenSpacing,
            isPlanChildrenLimiting: isPlanChildrenLimiting,
            isFecund: isFecund,
            isFPMethod: isFPMethod,
            isFPModern: isFPModern,
            shiftToModern: shiftToModern,
            isMFPUnmet: isMFPUnmet,
            acceptModernFpMethod: acceptModernFpMethod,
            modernFPMethod: modernFPMethod,
            fPAcceptedDate: fPAcceptedDate);
    }

    private WomanOfReproductiveAge() { }
}
