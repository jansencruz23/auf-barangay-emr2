using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetAllMasterlistRecords;

public sealed class GetAllMasterlistRecordsQueryValidator : AbstractValidator<GetAllMasterlistRecordsQuery>
{
    public GetAllMasterlistRecordsQueryValidator()
    {
        RuleFor(x => x.HouseholdId)
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}