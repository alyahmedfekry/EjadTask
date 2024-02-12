using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.Delete
{
    public class DeleteHorseCommandHandler : ICommandHandler<DeleteHorseCommand>
    {
        private readonly IHorseRepository _horseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DeleteHorseCommandHandler(IHorseRepository horseRepository
            , IUnitOfWork unitOfWork)
        {
            _horseRepository = horseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(DeleteHorseCommand request, CancellationToken cancellationToken)
        {
            var horse = await _horseRepository.GetByIdAsync(request.Id);
            
            if (horse == null)
            {
                return Result.Fail(new Error("Horse not found!!"));
            }
          
            horse.IsDeleted = true;

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
