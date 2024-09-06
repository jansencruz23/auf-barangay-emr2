using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Exceptions;
using AUF.EMR2.Application.Responses;
using AUF.EMR2.Domain.Models;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.DeleteWra
{
    public class DeleteWraCommandHandler : IRequestHandler<DeleteWraCommand, BaseCommandResponse<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteWraCommandHandler(
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse<int>> Handle(DeleteWraCommand request, CancellationToken cancellationToken)
        {
            if (request.Id < 1)
            {
                throw new BadRequestException("The request is invalid. Id (0).");
            }

            var response = new BaseCommandResponse<int>();
            var existing = await _unitOfWork.WraRepository.Exists(request.Id);

            if (!existing)
            {
                response.Success = false;
                response.Message = $"{nameof(WomanOfReproductiveAge)} with id: {request.Id} is not existing. It may be deleted or it never existed.";

                throw new NotFoundException(nameof(WomanOfReproductiveAge), request.Id);
            }

            try
            {
                await _unitOfWork.WraRepository.Delete(request.Id);
                await _unitOfWork.SaveAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrencyException($"The {nameof(WomanOfReproductiveAge)} you attempted to update was deleted by another user.", ex);
            }

            response.Success = true;
            response.Message = "Deletion is successful";
            response.Id = request.Id;

            return response;
        }
    }
}
