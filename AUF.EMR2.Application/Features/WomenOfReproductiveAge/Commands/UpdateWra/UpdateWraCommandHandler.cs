﻿using AUF.EMR2.Application.Abstraction.Persistence.Common;
using AUF.EMR2.Application.Common.Responses;
using MapsterMapper;
using MediatR;

namespace AUF.EMR2.Application.Features.WomenOfReproductiveAge.Commands.UpdateWra;

public class UpdateWraCommandHandler : IRequestHandler<UpdateWraCommand, CommandResponse<Guid>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateWraCommandHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<CommandResponse<Guid>> Handle(UpdateWraCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
        //var response = new BaseCommandResponse<Guid>();
        //var validator = new UpdateWraDtoValidator(_unitOfWork);
        //var validationResult = await validator.ValidateAsync(request.WraDto, cancellationToken);

        //if (!validationResult.IsValid)
        //{
        //    response.Success = false;
        //    response.Message = "Updation Failed";
        //    response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();

        //    throw new ValidationException(validationResult);
        //}

        //var wra = await _unitOfWork.WraRepository.GetWra(request.WraDto.Id);

        //if (wra == null)
        //{
        //    response.Success = false;
        //    response.Message = $"{nameof(WomanOfReproductiveAge)} with id: {request.WraDto.Id} is not existing";

        //    throw new NotFoundException(nameof(WomanOfReproductiveAge), request.WraDto.Id);
        //}

        //_mapper.Map(request.WraDto, wra);

        //try
        //{
        //    _unitOfWork.WraRepository.Update(wra);
        //    await _unitOfWork.SaveAsync();
        //}
        //catch (DbUpdateConcurrencyException ex)
        //{
        //    throw new ConcurrencyException("The entity you attempted to update was modified by another user.", ex);
        //}

        //response.Success = true;
        //response.Message = "Updation is successful";
        //response.Id = request.WraDto.Id;

        //return response;
    }
}
