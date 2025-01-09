using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSenior;

public sealed class GetMasterlistSeniorQueryValidator : AbstractValidator<GetMasterlistSeniorQuery>
{
    public GetMasterlistSeniorQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
