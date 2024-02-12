using Application.Abstractions;
using Domain.Abstractions.Repositories;
using Domain.Entities;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Horses.GetAll
{
    public class GetAllHorseQueryHandler : IQueryHandler<GetAllHorseQuery
        , List<Domain.Entities.Horse>>
    {
        private readonly IHorseRepository _horseRepository;
        public GetAllHorseQueryHandler(IHorseRepository horseRepository) 
        {
          _horseRepository = horseRepository;
        }
        public async Task<Result<List<Horse>>> Handle(GetAllHorseQuery request, CancellationToken cancellationToken)
        {
            var response = await _horseRepository.GetAllAsync();

            return Result.Ok(response);
        }
    }
}
