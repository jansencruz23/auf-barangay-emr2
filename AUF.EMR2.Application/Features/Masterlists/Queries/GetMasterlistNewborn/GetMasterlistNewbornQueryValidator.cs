using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistNewborn;

public sealed class GetMasterlistNewbornQueryValidator : AbstractValidator<GetMasterlistNewbornQuery>
{
    public GetMasterlistNewbornQueryValidator()
    {
        RuleFor(x => x.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}
