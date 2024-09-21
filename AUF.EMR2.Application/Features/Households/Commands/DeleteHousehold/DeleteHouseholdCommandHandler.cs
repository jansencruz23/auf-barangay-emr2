using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Responses;
using MediatR;

namespace AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold;

public class DeleteHouseholdCommandHandler : IRequestHandler<DeleteHouseholdCommand, BaseCommandResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteHouseholdCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse<Guid>> Handle(DeleteHouseholdCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //if (request.Id == Guid.Empty)
        //{
        //    throw new BadRequestException("The request is invalid. Id (0).");
        //}

        //var response = new BaseCommandResponse<Guid>();
        //var existing = await _unitOfWork.HouseholdRepository.Exists(request.Id);

        //if (!existing)
        //{
        //    response.Success = false;
        //    response.Message = $"{nameof(Household)} with id: {request.Id} is not existing. It may be deleted or it never existed.";

        //    throw new NotFoundException(nameof(Household), request.Id);
        //}

        //try
        //{
        //    await _unitOfWork.HouseholdRepository.Delete(request.Id);
        //    await _unitOfWork.SaveAsync();
        //}
        //catch (DbUpdateConcurrencyException ex)
        //{
        //    throw new ConcurrencyException($"The {nameof(Household)} you attempted to update was deleted by another user.", ex);
        //}

        //response.Success = true;
        //response.Message = "Deletion is successful";
        //response.Id = request.Id;

        //return response;
    }
}
