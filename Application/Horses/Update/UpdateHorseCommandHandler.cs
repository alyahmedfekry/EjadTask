using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.Update
{
    public class UpdateHorseCommandHandler : ICommandHandler<UpdateHorseCommand>
    {
        private readonly IHorseRepository _horseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public UpdateHorseCommandHandler(IHorseRepository horseRepository
            , IUnitOfWork unitOfWork)
        {
            _horseRepository = horseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateHorseCommand request, CancellationToken cancellationToken)
        {
            var horse = new Domain.Entities.Horse(request.Name, request.Weight
                 , request.Color, request.Age, request.Speed);

            horse.Id = request.Id;  

            _horseRepository.Update(horse); 

            await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
