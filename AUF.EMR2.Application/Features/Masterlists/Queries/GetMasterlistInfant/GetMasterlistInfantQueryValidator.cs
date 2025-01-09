using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant;

public sealed class GetMasterlistInfantQueryValidator : AbstractValidator<GetMasterlistInfantQuery>
{
    public GetMasterlistInfantQueryValidator()
    {
        RuleFor(x => x.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}
