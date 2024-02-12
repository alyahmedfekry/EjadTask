using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using Domain.UnitOfWork;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.Create
{
    public class CreateHorseCommandHandler : ICommandHandler<CreateHorseCommand>
    {
        private readonly IHorseRepository _horseRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateHorseCommandHandler(IHorseRepository horseRepository
             ,IUnitOfWork unitOfWork)
        {
            _horseRepository = horseRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateHorseCommand request, CancellationToken cancellationToken)
        {
            var horse = new Horse(request.Name, request.Weight, request.Color, request.Age
                 , request.Speed);

           await _horseRepository.CreateAsync(horse);

           await _unitOfWork.SaveChangesAsync();

            return Result.Ok();
        }
    }
}
