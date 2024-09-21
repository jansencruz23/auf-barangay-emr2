using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Domain.Aggregates.HouseholdMemberAggregate;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.HouseholdMembers.Commands.DeleteHouseholdMember
{
    public class DeleteHouseholdMemberCommandHandler : IRequestHandler<DeleteHouseholdMemberCommand, BaseCommandResponse<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHouseholdMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<Guid>> Handle(DeleteHouseholdMemberCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //if (request.Id == Guid.Empty)
            //{
            //    throw new BadRequestException("The request is invalid. Id (0).");
            //}

            //var response = new BaseCommandResponse<Guid>();
            //var existing = await _unitOfWork.HouseholdMemberRepository.Exists(request.Id);

            //if (!existing)
            //{
            //    response.Success = false;
            //    response.Message = $"{nameof(HouseholdMember)} with id: {request.Id} is not existing. It may be deleted or it never existed.";

            //    throw new NotFoundException(nameof(HouseholdMember), request.Id);
            //}

            //try
            //{
            //    await _unitOfWork.HouseholdMemberRepository.Delete(request.Id);
            //    await _unitOfWork.SaveAsync();
            //}
            //catch (DbUpdateConcurrencyException ex)
            //{
            //    throw new ConcurrencyException($"The {nameof(HouseholdMember)} you attempted to update was deleted by another user.", ex);
            //}

            //response.Success = true;
            //response.Message = "Deletion is successful";
            //response.Id = request.Id;

            //return response;
        }
    }
}
