using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetWraHouseholdMemberList;

public sealed class GetWraHouseholdMemberListQueryValidator : AbstractValidator<GetWraHouseholdMemberListQuery>
{
    public GetWraHouseholdMemberListQueryValidator()
    {
        RuleFor(x => x.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
