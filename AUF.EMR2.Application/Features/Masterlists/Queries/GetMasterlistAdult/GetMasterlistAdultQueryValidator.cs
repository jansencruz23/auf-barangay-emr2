using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdult;

public sealed class GetMasterlistAdultQueryValidator : AbstractValidator<GetMasterlistAdultQuery>
{
    public GetMasterlistAdultQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
