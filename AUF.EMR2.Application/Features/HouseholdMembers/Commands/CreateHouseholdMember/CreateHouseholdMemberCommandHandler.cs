using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate.ValueObjects;
using AUF.EMR2.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.CreateHouseholdMember;

public class CreateHouseholdMemberCommandHandler : IRequestHandler<CreateHouseholdMemberCommand, ErrorOr<CommandResponse<Guid>>>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateHouseholdMemberCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<ErrorOr<CommandResponse<Guid>>> Handle(CreateHouseholdMemberCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var response = new CommandResponse<Guid>();

            var quarterlyClassification = QuarterlyClassification.Create(
                firstQtrClassification: request.QuarterlyClassification?.FirstQtrClassification,
                secondQtrClassification: request.QuarterlyClassification?.SecondQtrClassification,
                thirdQtrClassification: request.QuarterlyClassification?.ThirdQtrClassification,
                fourthQtrClassification: request.QuarterlyClassification?.FourthQtrClassification
            );

            var member = HouseholdMember.Create(
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
                isInSchool: request.IsInSchool,
                householdId: request.HouseholdId
            );

            if (member.IsError)
            {
                return member.FirstError;
            }

            await _unitOfWork.HouseholdMemberRepository.Add(member.Value);
            await _unitOfWork.SaveAsync();

            response.Success = true;
            response.Id = member.Value.Id.Value;
            response.Message = "Created successfully";

            return response;
        }
        catch (Exception)
        {
            return Errors.HouseholdMember.FailedToCreate;
        }
    }
}
