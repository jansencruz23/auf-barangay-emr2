using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistChildRecord;

public sealed class GetMasterlistChildRecordQueryValidator : AbstractValidator<GetMasterlistChildRecordQuery>
{
    public GetMasterlistChildRecordQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}
