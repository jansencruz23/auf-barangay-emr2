using AUF.EMR2.Application.Features.Masterlists.Queries.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Queries.GetMasterlistAdolescent;

public sealed class GetMasterlistAdolescentQueryValidator : AbstractValidator<GetMasterlistAdolescentQuery>
{
    public GetMasterlistAdolescentQueryValidator()
    {
        Include(new IMasterlistQueryValidator());
    }
}
