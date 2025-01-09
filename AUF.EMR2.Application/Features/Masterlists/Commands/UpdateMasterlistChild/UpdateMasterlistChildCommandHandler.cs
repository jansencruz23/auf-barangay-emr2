using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace AUF.EMR2.Application.Features.Masterlists.Commands.UpdateMasterlistChild;

public class UpdateMasterlistChildCommandHandler : IRequestHandler<UpdateMasterlistChildCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateMasterlistChildCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(UpdateMasterlistChildCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            var response = new CommandResponse<Guid>();

            var result = member.UpdateAsMasterlistChild(
                lastName: request.LastName,
                firstName: request.FirstName,
                motherMaidenName: request.MotherMaidenName,
                sex: request.Sex,
                birthday: request.Birthday,
                nameOfMother: request.NameOfMother,
                nameOfFather: request.NameOfFather,
                isNhts: request.IsNhts,
                isInSchool: request.IsInSchool
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
