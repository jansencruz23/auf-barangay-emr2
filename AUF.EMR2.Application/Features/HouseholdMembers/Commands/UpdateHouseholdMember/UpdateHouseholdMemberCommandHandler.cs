using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MapsterMapper;
using MediatR;
using System.Data;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.UpdateHouseholdMember;

public class UpdateHouseholdMemberCommandHandler : IRequestHandler<UpdateHouseholdMemberCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateHouseholdMemberCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(UpdateHouseholdMemberCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var member = await _unitOfWork.HouseholdMemberRepository.GetHouseholdMember(HouseholdMemberId.Create(request.Id));
            if (member is null)
            {
                return Errors.HouseholdMember.NotFound;
            }

            var response = new CommandResponse<Guid>();
            var quarterlyClassification = QuarterlyClassification.Create
            (
                firstQtrClassification: request.QuarterlyClassification?.FirstQtrClassification,
                secondQtrClassification: request.QuarterlyClassification?.SecondQtrClassification,
                thirdQtrClassification: request.QuarterlyClassification?.ThirdQtrClassification,
                fourthQtrClassification: request.QuarterlyClassification?.FourthQtrClassification
            );

            var result = member.Update(
                lastName: request.LastName,
                firstName: request.FirstName,
                motherMaidenName: request.MotherMaidenName,
                relationshipToHouseholdHead: request.RelationshipToHouseholdHead,
                otherRelation: request.OtherRelation,
                sex: request.Sex,
                birthday: request.Birthday,
                quarterlyClassification: quarterlyClassification,
                remarks: request.Remarks,
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
        catch (DBConcurrencyException)
        {
            return Errors.ConcurrentIssue;
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToFetch;
        }
    }
}
