using Application.Abstractions;
using Domain.Abstractions.Repositories;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Battle.GetAll
{
    public class GetAllBattleQueryHandler : IQueryHandler<GetAllBattleQuery
        , List<Domain.Entities.Battle>>
    {
        private readonly IBattleRepository _battleRepository;
        public GetAllBattleQueryHandler(IBattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }

        public async Task<Result<List<Domain.Entities.Battle>>> Handle(GetAllBattleQuery request, CancellationToken cancellationToken)
        {
            var response = await _battleRepository.GetAllAsync();

            return Result.Ok(response);
        }
    }
}
