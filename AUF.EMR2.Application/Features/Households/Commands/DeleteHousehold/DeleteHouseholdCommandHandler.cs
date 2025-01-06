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
        try
        {
            var household = await _unitOfWork.HouseholdRepository.Get(HouseholdId.Create(request.Id));
            if (household is null)
            {
                return Errors.Household.NotFound;
            }

            var response = new CommandResponse<Guid>();

            var householdId = household.Delete();
            if (householdId.IsError)
            {
                return householdId.FirstError;
            }

            _unitOfWork.HouseholdRepository.Update(household);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Message = "Deletion is successful";
            response.Id = request.Id;

            return response;
        }
        catch (DbUpdateConcurrencyException)
        {
            return Errors.ConcurrentIssue;
        }
        catch (Exception)
        {
            return Errors.Household.FailedToDelete;
        }
    }
}
