using Application.Abstractions;
using Domain.Abstractions.Repositories;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.GetById
{
    public class GetHorseByIdQueryHandler : IQueryHandler<GetHorseByIdQuery, GetHorseByIdQueryResponse>
    {
        private readonly IHorseRepository _horseRepository;
        public GetHorseByIdQueryHandler(IHorseRepository horseRepository)
        {
            _horseRepository = horseRepository;
        }

        public async Task<Result<GetHorseByIdQueryResponse>> Handle(GetHorseByIdQuery request, CancellationToken cancellationToken)
        {
            var horse = await _horseRepository.GetByIdAsync(request.Id);
           
            if(horse is null)
            {
                return Result.Fail(new Error("horse not found!!"));
            }

            var response = new GetHorseByIdQueryResponse
            {
                Age = horse.Age,
                Color = horse.Color,
                Id = horse.Id,
                Name = horse.Name,
                Speed = horse.Speed,
                Weight = horse.Weight,
            };

            return Result.Ok(response);
        }
    }
}
