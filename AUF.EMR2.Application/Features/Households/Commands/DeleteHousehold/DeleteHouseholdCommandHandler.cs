using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;

public class DeleteHouseholdCommandHandler : IRequestHandler<DeleteHouseholdCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHouseholdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(DeleteHouseholdCommand request, CancellationToken cancellationToken)
    {
        var response = new CommandResponse<Guid>();
        var household = await _unitOfWork.HouseholdRepository.Get(HouseholdId.Create(request.Id));

        if (household is null)
        {
            return Errors.Household.HouseholdNotFound;
        }

        try
        {
            household.Delete();
            _unitOfWork.HouseholdRepository.Update(household);

            await _unitOfWork.SaveAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            return Errors.ConcurrentIssue;
        }

        response.Success = true;
        response.Message = "Deletion is successful";
        response.Id = request.Id;

        return response;
    }
}
