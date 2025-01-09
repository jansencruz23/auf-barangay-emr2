using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistAdult;

public sealed class UpdateMasterlistAdultCommandHandler : IRequestHandler<UpdateMasterlistAdultCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMasterlistAdultCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(UpdateMasterlistAdultCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            var response = new CommandResponse<Guid>();

            var result = member.UpdateAsMasterlistAdult(
                lastName: request.LastName,
                firstName: request.FirstName,
                motherMaidenName: request.MotherMaidenName,
                sex: request.Sex,
                birthday: request.Birthday,
                isNhts: request.IsNhts
            );

            if (result.IsError)
            {
                return result.FirstError;
            }

            _unitOfWork.HouseholdMemberRepository.Update(member);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Id = member.Id.Value;
            response.Message = "Updated successfully";

            return response;
        }
        catch (DbUpdateConcurrencyException)
        {
            return Errors.ConcurrentIssue;
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToUpdate;
        }
    }
}
