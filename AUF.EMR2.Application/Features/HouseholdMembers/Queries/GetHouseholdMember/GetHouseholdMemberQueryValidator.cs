using FluentValidation;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Queries.GetHouseholdMember;

public sealed class GetHouseholdMemberQueryValidator : AbstractValidator<GetHouseholdMemberQuery>
{
    public GetHouseholdMemberQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty).WithMessage("{PropertyName} must not be empty.");
    }
}
