using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdultRecord;

public sealed class GetMasterlistAdultRecordQueryValidator : AbstractValidator<GetMasterlistAdultRecordQuery>
{
    public GetMasterlistAdultRecordQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}
