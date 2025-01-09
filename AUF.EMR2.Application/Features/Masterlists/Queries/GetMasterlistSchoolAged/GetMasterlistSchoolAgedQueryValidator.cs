using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistSchoolAged;

public sealed class GetMasterlistSchoolAgedQueryValidator : AbstractValidator<GetMasterlistSchoolAgedQuery>
{
    public GetMasterlistSchoolAgedQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
