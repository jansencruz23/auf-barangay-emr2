using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Entities;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.Households.Commands.DeleteHousehold
{
    public class DeleteHouseholdCommandHandler : IRequestHandler<DeleteHouseholdCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteHouseholdCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteHouseholdCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
            {
                throw new BadRequestException("The request is invalid. Id (0).");
            }

            var response = new BaseCommandResponse<int>();
            var existing = await _unitOfWork.HouseholdRepository.Exists(request.Id);

            if (!existing)
            {
                response.Success = false;
                response.Message = $"{nameof(Household)} with id: {request.Id} is not existing. It may be deleted or it never existed.";

                throw new NotFoundException(nameof(Household), request.Id);
            }

            try
            {
                await _unitOfWork.HouseholdRepository.Delete(request.Id);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException($"The {nameof(Household)} you attempted to update was deleted by another user.", ex);
            }

            response.Success = true;
            response.Message = "Deletion is successful";
            response.Id = request.Id;

            return response;
        }
    }
}
