using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistInfant;

public sealed class GetMasterlistInfantQueryValidator : AbstractValidator<GetMasterlistInfantQuery>
{
    public GetMasterlistInfantQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
