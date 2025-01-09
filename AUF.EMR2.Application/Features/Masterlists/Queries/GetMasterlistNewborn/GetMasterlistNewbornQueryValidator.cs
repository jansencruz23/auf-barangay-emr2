using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistNewborn;

public sealed class GetMasterlistNewbornQueryValidator : AbstractValidator<GetMasterlistNewbornQuery>
{
    public GetMasterlistNewbornQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
