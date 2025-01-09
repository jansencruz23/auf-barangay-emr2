using AUF.EMR2.Application.Features.Masterlists.Commands.Common;
using FluentValidation;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult;

public sealed class UpdateMasterlistAdultCommandValidator : AbstractValidator<UpdateMasterlistAdultCommand>
{
    public UpdateMasterlistAdultCommandValidator()
    {
        Include(new IUpdateMasterlistCommandValidator());
    }
}
