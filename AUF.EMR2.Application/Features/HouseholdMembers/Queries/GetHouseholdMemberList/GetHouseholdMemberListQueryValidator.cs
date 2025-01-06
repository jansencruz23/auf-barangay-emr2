using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMemberList;

public sealed class GetHouseholdMemberListQueryValidator : AbstractValidator<GetHouseholdMemberListQuery>
{
    public GetHouseholdMemberListQueryValidator()
    {
        RuleFor(x => x.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}