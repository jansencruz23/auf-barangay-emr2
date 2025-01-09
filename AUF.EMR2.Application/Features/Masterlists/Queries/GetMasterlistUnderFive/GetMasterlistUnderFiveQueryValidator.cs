using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistUnderFive;

public sealed class GetMasterlistUnderFiveQueryValidator : AbstractValidator<GetMasterlistUnderFiveQuery>
{
    public GetMasterlistUnderFiveQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
