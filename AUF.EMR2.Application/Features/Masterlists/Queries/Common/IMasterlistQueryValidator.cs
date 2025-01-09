using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.Common;

public class IMasterlistQueryValidator : AbstractValidator<IMasterlistQuery>
{
    public IMasterlistQueryValidator()
    {
        RuleFor(x => x.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}
