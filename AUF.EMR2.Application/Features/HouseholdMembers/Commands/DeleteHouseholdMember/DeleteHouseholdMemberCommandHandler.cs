using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember;

public sealed class DeleteHouseholdMemberCommandHandler : IRequestHandler<DeleteHouseholdMemberCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHouseholdMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(DeleteHouseholdMemberCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            var response = new CommandResponse<Guid>();

            var householdId = member.Delete();
            if (householdId.IsError)
            {
                return householdId.FirstError;
            }

            _unitOfWork.HouseholdMemberRepository.Update(member);
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
            return Errors.HouseholdMember.FailedToDelete;
        }
    }
}
